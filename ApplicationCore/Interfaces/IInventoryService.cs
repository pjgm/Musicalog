using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
	public interface IInventoryService
	{
		Task<IEnumerable<InventoryEntry>> GetAllStock();
	}
}
