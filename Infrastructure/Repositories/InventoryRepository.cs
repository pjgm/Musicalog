using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Dapper;
//using Dapper.Contrib.Extensions;

namespace Infrastructure.Repositories
{
	public class InventoryRepository : BaseRepository, IInventoryRepository
	{

		public InventoryRepository(string connectionString) : base(connectionString)
		{
		}

		public async Task CreateEntryAsync(InventoryEntry entry)
		{
			using (IDbConnection conn = Connection)
			{
				var insertArtistSql = "INSERT INTO Artists VALUES(@ArtistName);" +
					"SELECT CAST(SCOPE_IDENTITY() as int)";
				var artistId = (await conn.QueryAsync<int>(insertArtistSql, new { ArtistName = entry.Album.Artist.Name })).Single();

				var insertRecordLabelSql = "INSERT INTO RecordLabels VALUES(@RecordLabelName);" +
					"SELECT CAST(SCOPE_IDENTITY() as int)";
				var recordLabelId = (await conn.QueryAsync<int>(insertRecordLabelSql, new { RecordLabelName = entry.Album.RecordLabel.Name })).Single();

				var albumType = (int)entry.Album.Type;
				var insertAlbumSql = "INSERT INTO Albums (Name, AlbumType, ArtistId, RecordLabelId) " +
					"VALUES(@AlbumName, @AlbumType, @ArtistId, @RecordLabelId);" +
					"SELECT CAST(SCOPE_IDENTITY() as int)";
				var albumId = (await conn.QueryAsync<int>(insertAlbumSql,
					new
					{
						AlbumName = entry.Album.Name,
						AlbumType = albumType,
						ArtistId = artistId,
						RecordLabelId = recordLabelId
					})).Single();

				var insertInventoryEntrySql = "INSERT INTO Inventory VALUES (@AlbumId, @Stock)";
				await conn.ExecuteAsync(insertInventoryEntrySql, new { AlbumId = albumId, entry.Stock });
			}
		}

		public async Task EditEntryAsync(InventoryEntry entry)
		{
			var updateEntrySql =
				"UPDATE Inventory SET Stock = @NewStock where Inventory.Id = @InventoryId;" +
				"UPDATE Albums SET Name = @NewAlbumName, AlbumType = @NewAlbumType where Albums.Id = @AlbumId";

			using (IDbConnection conn = Connection)
			{
				await conn.ExecuteAsync(
					updateEntrySql,
					new
					{
						NewStock = entry.Stock,
						InventoryId = entry.Id,
						AlbumId = entry.Album.Id,
						NewAlbumName = entry.Album.Name,
						NewAlbumType = (int)entry.Album.Type
					});

			}
		}

		public async Task<IEnumerable<InventoryEntry>> GetEntriesAsync(int pageIndex, int pageSize)
		{
			var sqlQuery = "select ArtistId as 'ArtistId', Artists.Name as 'ArtistName', RecordLabels.Name as 'RecordLabelName', RecordLabels.Id as 'RecordLabelId', Albums.Name as 'AlbumName', Albums.AlbumType as 'Medium', Albums.Id as 'AlbumId', Inventory.Stock as 'Stock', Inventory.Id as 'InventoryId' from Inventory inner join Albums on Inventory.AlbumId = Albums.Id inner join Artists on Albums.ArtistId = Artists.Id inner join RecordLabels on Albums.RecordLabelId = RecordLabels.Id ORDER BY Inventory.Id OFFSET " + pageIndex + " ROWS FETCH NEXT " + pageSize + " ROWS ONLY";
			using (IDbConnection conn = Connection)
			{
				var result = await conn.QueryAsync<Artist, RecordLabel, Album, InventoryEntry, InventoryEntry>(
					sqlQuery,
					map: (artist, recordLabel, album, inventoryEntry) =>
					{
						album.Artist = artist;
						album.RecordLabel = recordLabel;
						inventoryEntry.Album = album;
						return inventoryEntry;
					},
					splitOn: "RecordLabelName,AlbumName,Stock");

				return result;
			}
		}

		public async Task<InventoryEntry> GetEntryByAlbumIdAsync(int id)
		{
			var sqlQuery = "select ArtistId as 'ArtistId', Artists.Name as 'ArtistName', RecordLabels.Name as 'RecordLabelName', RecordLabels.Id as 'RecordLabelId', Albums.Name as 'AlbumName', Albums.AlbumType as 'Medium', Albums.Id as 'AlbumId', Inventory.Stock as 'Stock', Inventory.Id as 'InventoryId' from Inventory inner join Albums on Inventory.AlbumId = Albums.Id inner join Artists on Albums.ArtistId = Artists.Id inner join RecordLabels on Albums.RecordLabelId = RecordLabels.Id where Albums.Id = " + id;

			using (IDbConnection conn = Connection)
			{
				var result = await conn.QueryAsync<Artist, RecordLabel, Album, InventoryEntry, InventoryEntry>(
					sqlQuery,
					map: (artist, recordLabel, album, inventoryEntry) =>
					{
						album.Artist = artist;
						album.RecordLabel = recordLabel;
						inventoryEntry.Album = album;
						return inventoryEntry;
					},
					splitOn: "RecordLabelName,AlbumName,Stock");

				return result.ToList().FirstOrDefault();
			}
		}

		public async Task<InventoryEntry> GetEntryByInventoryIdAsync(int id)
		{
			var sqlQuery = "select Artists.Name as 'ArtistName', RecordLabels.Name as 'RecordLabelName', Albums.Name as 'AlbumName', Albums.AlbumType as 'Medium', Inventory.Stock as 'Stock', Inventory.Id as 'InventoryId' from Inventory inner join Albums on Inventory.AlbumId = Albums.Id inner join Artists on Albums.ArtistId = Artists.Id inner join RecordLabels on Albums.RecordLabelId = RecordLabels.Id where Inventory.Id = " + id;

			using (IDbConnection conn = Connection)
			{
				var result = await conn.QueryAsync<Artist, RecordLabel, Album, InventoryEntry, InventoryEntry>(
					sqlQuery,
					map: (artist, recordLabel, album, inventoryEntry) =>
					{
						album.Artist = artist;
						album.RecordLabel = recordLabel;
						inventoryEntry.Album = album;
						return inventoryEntry;
					},
					splitOn: "RecordLabelName,AlbumName,Stock");

				return result.ToList().FirstOrDefault();
			}
		}

		public async Task DeleteEntryByInventoryIdAsync(int id)
		{
			var deleteEntrySql = "DELETE FROM Inventory where Inventory.Id = @InventoryId";

			using (IDbConnection conn = Connection)
			{
				await conn.ExecuteAsync(deleteEntrySql, new { InventoryId = id });
			}
		}
	}
}
