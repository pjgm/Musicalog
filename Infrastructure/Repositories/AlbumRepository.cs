using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class AlbumRepository: BaseRepository, IAlbumRepository
	{
		public AlbumRepository(string connectionString) : base(connectionString)
		{
		}

		public async Task<Album> GetAlbumAsync(int id)
		{
			using (IDbConnection conn = Connection)
			{
				string sQuery = "SELECT * FROM Albums where Albums.Id = " + id;

				conn.Open();

				var result = await conn.QueryFirstAsync<Album>(sQuery);
				return result;
			}
		}

		public async Task<IEnumerable<Album>> GetAllAlbumsAsync()
		{
			using (IDbConnection conn = Connection)
			{
				string sQuery = "SELECT * FROM Albums";

				conn.Open();

				var result = await conn.QueryAsync<Album>(sQuery);
				return result;
			}
		}

		public Album getAlbumById(int id)
		{
			throw new System.NotImplementedException();
		}

	}
}
