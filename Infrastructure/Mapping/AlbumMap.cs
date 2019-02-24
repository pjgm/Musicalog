using ApplicationCore.Entities;
using Dapper.FluentMap.Mapping;

namespace Infrastructure.Mapping
{
	internal class AlbumMap : EntityMap<Album>
	{
		internal AlbumMap()
		{
			Map(album => album.Id).ToColumn("AlbumId");
			Map(album => album.Name).ToColumn("AlbumName");
			Map(album => album.Type).ToColumn("Medium");
		}
	}
}
