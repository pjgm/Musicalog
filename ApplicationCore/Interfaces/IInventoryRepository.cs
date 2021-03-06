﻿using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
	public interface IInventoryRepository
	{
		Task<IEnumerable<InventoryEntry>> GetEntriesAsync(int pageIndex, int pageSize, string sortBy, string orderBy);
		Task<InventoryEntry> GetEntryByAlbumIdAsync(int id);
		Task<InventoryEntry> GetEntryByInventoryIdAsync(int id);
		Task CreateEntryAsync(InventoryEntry entry);
		Task EditEntryAsync(InventoryEntry entry);
		Task DeleteEntryByInventoryIdAsync(int id);
	}
}
