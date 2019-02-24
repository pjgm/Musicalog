using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase, IAlbumsController
    {
		private readonly IAlbumService albumsService;

		public AlbumsController(IAlbumService albumsService)
		{
			this.albumsService = albumsService;
		}

        [HttpGet]
        public async Task<IEnumerable<Album>> Get()
        {
            var albumList = await albumsService.GetAllAlbums();
			return albumList;
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<Album> Get(int id)
        {
			var albumInfo = await albumsService.GetAlbum(id);
			return albumInfo;
		}

        // POST: api/Albums
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Albums/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
