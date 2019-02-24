using ApplicationCore.Entities;
using Dapper.FluentMap.Mapping;

namespace Infrastructure.Mapping
{
	internal class ArtistMap : EntityMap<Artist>
	{
		internal ArtistMap()
		{
			Map(artist => artist.Id).ToColumn("ArtistId");
			Map(artist => artist.Name).ToColumn("ArtistName");
		}
	}
}
