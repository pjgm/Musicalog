using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Musicalog.Models;
using Presentation.ViewModels;

namespace Musicalog.Controllers
{
	public class HomeController : Controller
	{
		private readonly IInventoryController apiInventoryController;

		public HomeController(IInventoryController apiInventoryController)
		{
			this.apiInventoryController = apiInventoryController;
		}

		public async Task<IActionResult> Index(int pageIndex = 0, int pageSize = 10)
		{
			var entries = await apiInventoryController.Get(pageIndex, pageSize);
			var viewModel = new InventoryViewModel
			{
				InventoryEntries = entries,
				Pagination = new PaginationViewModel
				{
					CurrentPage = pageIndex,
					PageSize = pageSize,
					IsLastPage = entries.ToList().Count() < pageSize
				}
			};
			return View(viewModel);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
