using System;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;

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
			var inventoryEntry = await apiInventoryController.GetByInventoryId(id);
			return View(inventoryEntry);
		}

		public IActionResult Create()
        {
			var albumTypes = Enum.GetValues(typeof(AlbumType)).Cast<AlbumType>();
			return View(albumTypes);
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormCollection collection)
        {
			var albumName = collection["albumName"].First();
			var artistName = collection["artist"].First();
			var recordLabelName = collection["recordLabel"].First();
			int.TryParse(collection["stock"].First(), out int stock);
			Enum.TryParse(collection["albumType"].First(), out AlbumType albumType);

			var inventoryEntry = new InventoryEntry()
			{
				Album = new Album
				{
					Artist = new Artist
					{
						Name = artistName
					},
					Name = albumName,
					RecordLabel = new RecordLabel
					{
						Name = recordLabelName
					},
					Type = albumType
				},
				Stock = stock
			};

			await apiInventoryController.Post(inventoryEntry);

			return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(int id)
        {
			var inventoryEntry = await apiInventoryController.GetByAlbumId(id);
			var editViewModel = new EditEntryViewModel
			{
				Entry = inventoryEntry,
				AlbumTypes = Enum.GetValues(typeof(AlbumType)).Cast<AlbumType>()
			};

            return View(editViewModel);
        }

		public async Task<IActionResult> EditEntry(IFormCollection collection)
		{
			int.TryParse(collection["inventoryEntryId"].First(), out int inventoryEntryId);
			int.TryParse(collection["albumId"].First(), out int albumId);
			int.TryParse(collection["artistId"].First(), out int artistId);
			int.TryParse(collection["recordLabelId"].First(), out int recordLabelId);
			int.TryParse(collection["stock"].First(), out int stock);
			var albumName = collection["albumName"].First();
			var artistName = collection["artist"].First();
			var recordLabelName = collection["recordLabel"].First();
			Enum.TryParse(collection["albumType"].First(), out AlbumType albumType);

			var entry = new InventoryEntry
			{
				Id = inventoryEntryId,
				Album = new Album
				{
					Id = albumId,
					Name = albumName,
					Type = albumType,
					Artist = new Artist
					{
						Id = artistId,
						Name = artistName
					},
					RecordLabel = new RecordLabel
					{
						Id = recordLabelId,
						Name = recordLabelName
					}
				},
				Stock = stock
			};
			await apiInventoryController.EditInventoryEntry(entry);
			return RedirectToAction("Index", "Home");
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