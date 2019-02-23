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
        private static IEnumerable<Album> albumList = new List<Album>
        {
            new Album
            {
                Name = "Boom boom",
                Artist = new Artist
                {
                    Name = "Paulo Martins"
                },
                RecordLabel = new RecordLabel
                {
                   Name = "Grandes Sons Lda" 
                },
                Type = 1
            },

            new Album
            {
                Name = "Opus Eponymous",
                Artist = new Artist
                {
                    Name = "Ghost"
                },
                RecordLabel = new RecordLabel
                {
                   Name = "Grandes Sons Lda"
                },
                Type = 3
            },

            new Album
            {
                Name = "Infestissumam",
                Artist = new Artist
                {
                    Name = "Ghost"
                },
                RecordLabel = new RecordLabel
                {
                   Name = "Rise Above"
                },
                Type = 1
            },
            new Album
            {
                Name = "Meliora",
                Artist = new Artist
                {
                    Name = "Ghost"
                },
                RecordLabel = new RecordLabel
                {
                   Name = "Rise Above"
                },
                Type = 3
            }
        };

		private readonly IAlbumService albumsService;

		public AlbumsController(IAlbumService albumsService)
		{
			this.albumsService = albumsService;
		}

        // GET: api/Albums
        [HttpGet]
        public async Task<IEnumerable<Album>> Get()
        {
            var albumList = await albumsService.GetAllAlbums();
			return albumList;
        }

        // GET: api/Albums/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
