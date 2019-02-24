using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
	public class AlbumsController : Controller
    {

		private readonly IAlbumsController apiAlbumsController;
		private readonly IInventoryController apiInventoryController;

		public AlbumsController(
			IAlbumsController apiAlbumsController,
			IInventoryController apiInventoryController
			)
		{
			this.apiAlbumsController = apiAlbumsController;
			this.apiInventoryController = apiInventoryController;
		}

		public IActionResult Index()
        {
			return RedirectToAction("Index", "Home");
		}

        public async Task<IActionResult> Details(int id)
		{
			var albumInfo = await apiInventoryController.GetByAlbumId(id);
			return View(albumInfo);
		}

		// GET: Albums/Create
		public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Albums/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Albums/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}