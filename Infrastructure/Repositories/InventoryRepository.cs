using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Infrastructure.Repositories
{
	public class InventoryRepository : BaseRepository, IInventoryRepository
	{

		public InventoryRepository(string connectionString) : base(connectionString)
		{
		}

		public async Task CreateEntry(InventoryEntry entry)
		{
			using (IDbConnection conn = Connection)
			{
				await conn.InsertAsync(entry);
				//var insertArtistSql = "INSERT INTO Artists VALUES('@artistName')";
				//var insertRecordLabelSql = "INSERT INTO RecordLabels VALUES('@recordLabelName')";
				//var insertAlbumSql = "INSERT INTO Albums (Name, AlbumType, ArtistId, RecordLabelId) VALUES('Opus Eponymous', 1, 1, 1)";
				//var insertInventorySql = "update Widget set Quantity = @quantity where WidgetId = @id";

				//var parameters = new { id = widgetId, quantity };
				//conn.ExecuteAsync(sql, parameters, tran);
			}
		}

	public async Task<IEnumerable<InventoryEntry>> GetEntriesAsync(int pageIndex, int pageSize)
	{
		using (IDbConnection conn = Connection)
		{
			string sqlQuery = "select Artists.Name as 'ArtistName', RecordLabels.Name as 'RecordLabelName', Albums.Name as 'AlbumName', Albums.AlbumType as 'Medium', Inventory.Stock as 'Stock' from Inventory inner join Albums on Inventory.AlbumId = Albums.Id inner join Artists on Albums.ArtistId = Artists.Id inner join RecordLabels on Albums.RecordLabelId = RecordLabels.Id ORDER BY Inventory.Id " +
				"OFFSET " + pageIndex + " ROWS FETCH NEXT " + pageSize + " ROWS ONLY";

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
		using (IDbConnection conn = Connection)
		{
			string sqlQuery = "select Artists.Name as 'ArtistName', RecordLabels.Name as 'RecordLabelName', Albums.Name as 'AlbumName', Albums.AlbumType as 'Medium', Inventory.Stock as 'Stock' from Inventory inner join Albums on Inventory.AlbumId = Albums.Id inner join Artists on Albums.ArtistId = Artists.Id inner join RecordLabels on Albums.RecordLabelId = RecordLabels.Id where Albums.Id = " + id;

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
}
}
