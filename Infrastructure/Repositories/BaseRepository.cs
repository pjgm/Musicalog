using Dapper.FluentMap;
using Infrastructure.Mapping;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Repositories
{
	public class BaseRepository
	{
		private readonly string connectionString;
		public IDbConnection Connection
		{
			get
			{
				return new SqlConnection(connectionString);
			}
		}

		public BaseRepository(string connectionString)
		{
			this.connectionString = connectionString;

			FluentMapper.EntityMaps.Clear();
			FluentMapper.TypeConventions.Clear();

			FluentMapper.Initialize(config =>
			{
				config.AddMap(new AlbumMap());
				config.AddMap(new ArtistMap());
				config.AddMap(new RecordLabelMap());
				config.AddMap(new InventoryEntryMap());
			});
		}
	}
}
