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

		public Album getAlbumById(int id)
		{
			throw new System.NotImplementedException();
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


	}
}
