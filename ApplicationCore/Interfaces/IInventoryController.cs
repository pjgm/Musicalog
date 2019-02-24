using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
	public interface IInventoryController
	{
		Task<IEnumerable<InventoryEntry>> Get(int pageIndex, int pageSize, string sortBy, string orderBy);
		Task<InventoryEntry> GetByAlbumId(int id);
		Task<InventoryEntry> GetByInventoryId(int id);
		Task EditInventoryEntry(InventoryEntry entry);
		Task Post(InventoryEntry entry);
		Task Delete(int id);
	}
}
