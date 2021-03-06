﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase, IInventoryController
    {

		private readonly IInventoryService inventoryService;

		public InventoryController(IInventoryService inventoryService)
		{
			this.inventoryService = inventoryService;
		}

        [HttpGet]
        public async Task<IEnumerable<InventoryEntry>> Get(int pageIndex, int pageSize, string sortBy, string orderBy)
        {
			return await inventoryService.GetEntriesAsync(pageIndex, pageSize, sortBy, orderBy);
		}

		public async Task<InventoryEntry> GetByAlbumId(int id)
		{
			var entry = await inventoryService.GetEntryByAlbumIdAsync(id);
			return entry;
		}

		public async Task<InventoryEntry> GetByInventoryId(int id)
		{
			var entry = await inventoryService.GetEntryByAlbumIdAsync(id);
			return entry;
		}

		public async Task EditInventoryEntry(InventoryEntry entry)
		{
			await inventoryService.EditInventoryEntryAsync(entry);
		}

		[HttpPost]
		public async Task Post(InventoryEntry entry)
		{
			await inventoryService.CreateEntryAsync(entry);
		}

		[HttpDelete]
		public async Task Delete(int id)
		{
			await inventoryService.DeleteEntryByInventoryId(id);
		}
	}
}
