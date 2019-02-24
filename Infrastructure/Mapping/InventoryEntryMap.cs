using ApplicationCore.Entities;
using Dapper.FluentMap.Mapping;

namespace Infrastructure.Mapping
{
	class InventoryEntryMap : EntityMap<InventoryEntry>
	{
		internal InventoryEntryMap()
		{
			Map(entry => entry.Id).ToColumn("InventoryId");
		}
	}
}
