using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
	public interface IInventoryService
	{
		Task<IEnumerable<InventoryEntry>> GetEntriesAsync(int pageIndex, int pageSize);
		Task<InventoryEntry> GetEntryByAlbumIdAsync(int id);
		Task<InventoryEntry> GetEntryByInventoryIdAsync(int id);
		Task CreateEntryAsync(InventoryEntry entry);
		Task EditInventoryEntryAsync(InventoryEntry entry);
	}
}
