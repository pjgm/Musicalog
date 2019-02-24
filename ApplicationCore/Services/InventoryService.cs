using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Validators;

namespace ApplicationCore.Services
{
	public class InventoryService : IInventoryService
	{
		private readonly IInventoryRepository inventoryRepository;

		public InventoryService(IInventoryRepository inventoryRepository)
		{
			this.inventoryRepository = inventoryRepository;
		}

		public async Task<IEnumerable<InventoryEntry>> GetEntriesAsync(int pageIndex, int pageSize, string sortBy, string orderBy)
		{
			return await inventoryRepository.GetEntriesAsync(pageIndex, pageSize, sortBy, orderBy);
		}

		public async Task<InventoryEntry> GetEntryByAlbumIdAsync(int id)
		{
			var entry = await inventoryRepository.GetEntryByAlbumIdAsync(id);

			if (entry == null)
			{
				throw new InventoryEntryNotFoundException("Inventory entry not found");
			}

			return entry;
		}

		public async Task<InventoryEntry> GetEntryByInventoryIdAsync(int id)
		{
			var entry = await inventoryRepository.GetEntryByInventoryIdAsync(id);

			if (entry == null)
			{
				throw new InventoryEntryNotFoundException("Inventory entry not found");
			}

			return entry;
		}

		public async Task CreateEntryAsync(InventoryEntry entry)
		{
			InventoryEntryValidator.Validate(entry);
			await inventoryRepository.CreateEntryAsync(entry);
		}

		public async Task EditInventoryEntryAsync(InventoryEntry entry)
		{
			InventoryEntryValidator.Validate(entry);
			await inventoryRepository.EditEntryAsync(entry);
		}

		public async Task DeleteEntryByInventoryId(int id)
		{
			await inventoryRepository.DeleteEntryByInventoryIdAsync(id);
		}
	}
}
