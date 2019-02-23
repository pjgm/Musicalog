using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services
{
	public class InventoryService : IInventoryService
	{
		private readonly IInventoryRepository inventoryRepository;

		public InventoryService(IInventoryRepository inventoryRepository)
		{
			this.inventoryRepository = inventoryRepository;
		}
		public async Task<IEnumerable<InventoryEntry>> GetAllStock()
		{
			var inventoryList = await inventoryRepository.GetAllStockAsync();
			return inventoryList;
		}
	}
}
