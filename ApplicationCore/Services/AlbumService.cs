using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
	public class AlbumService : IAlbumService
	{
		private readonly IAlbumRepository albumRepository;

		public AlbumService(IAlbumRepository albumRepository)
		{
			this.albumRepository = albumRepository;
		}

		public async Task<IEnumerable<Album>> GetAllAlbums()
		{
			var albumList = await albumRepository.GetAllAlbumsAsync();
			return albumList;
		}
	}
}
