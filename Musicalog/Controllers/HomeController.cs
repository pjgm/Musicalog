using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Musicalog.Models;

namespace Musicalog.Controllers
{
	public class HomeController : Controller
    {
		private readonly IInventoryController apiInventoryController;

		public HomeController(
			IInventoryController apiInventoryController
			)
        {
            this.apiInventoryController = apiInventoryController;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<InventoryEntry> values = await apiInventoryController.Get();
            return View(values);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
