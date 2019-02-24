using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
	public interface IInventoryController
	{
		Task<IEnumerable<InventoryEntry>> Get(int pageIndex, int pageSize);
		Task<InventoryEntry> GetByAlbumId(int id);
		Task<InventoryEntry> GetByInventoryId(int id);
		Task Post(InventoryEntry entry);
	}
}
