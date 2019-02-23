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

        // GET: api/Inventory
        [HttpGet]
        public async Task<IEnumerable<InventoryEntry>> Get()
        {
			var inventoryList = await inventoryService.GetAllStock();
			return inventoryList;
		}
    }
}
