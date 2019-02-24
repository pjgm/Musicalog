using System.Collections.Generic;
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
        public async Task<IEnumerable<InventoryEntry>> Get(int pageIndex, int pageSize)
        {
			return await inventoryService.GetEntriesAsync(pageIndex, pageSize);
		}

		public async Task<InventoryEntry> GetByAlbumId(int id)
		{
			var test = await inventoryService.GetEntryByAlbumIdAsync(id);
			return test;
		}

		[HttpPost]
		public async Task Post(InventoryEntry entry)
		{
			await inventoryService.CreateEntryAsync(entry);
		}
	}
}
