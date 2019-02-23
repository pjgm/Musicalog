using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Dapper;

namespace Infrastructure.Repositories
{
	public class InventoryRepository : BaseRepository, IInventoryRepository
	{

		public InventoryRepository(string connectionString) : base(connectionString)
		{
		}

		public async Task<IEnumerable<InventoryEntry>> GetAllStockAsync()
		{
			using (IDbConnection conn = Connection)
			{
				string sQuery = "select Artists.Name as 'ArtistName', RecordLabels.Name as 'RecordLabelName', Albums.Name as 'AlbumName', Albums.AlbumType as 'Medium', Inventory.Stock as 'Stock' from Inventory inner join Albums on Inventory.AlbumId = Albums.AlbumId inner join Artists on Albums.ArtistId = Artists.ArtistId inner join RecordLabels on Albums.RecordLabelId = RecordLabels.RecordLabelId";

				conn.Open();

				var result = await conn.QueryAsync<Artist, RecordLabel, Album, InventoryEntry, InventoryEntry>(
					sQuery,
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
	}
}
