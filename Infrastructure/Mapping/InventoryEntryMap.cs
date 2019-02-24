using ApplicationCore.Entities;
using Dapper.FluentMap.Mapping;

namespace Infrastructure.Mapping
{
	class InventoryEntryMap : EntityMap<InventoryEntry>
	{
		internal InventoryEntryMap()
		{
			//Map(artist => artist.Name).ToColumn("ArtistName");
			//Map(entry => entry.Album).
		}
	}
}
