using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
	public interface IInventoryRepository
	{
		Task<IEnumerable<InventoryEntry>> GetAllStockAsync();
	}
}
