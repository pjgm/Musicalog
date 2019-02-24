using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
	public interface IAlbumService
	{
		Task<IEnumerable<Album>> GetAllAlbums();
		Task<Album> GetAlbum(int id);
	}
}
