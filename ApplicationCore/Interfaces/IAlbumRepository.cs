using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
	public interface IAlbumRepository
	{
		Album getAlbumById(int id);
		Task<IEnumerable<Album>> GetAllAlbumsAsync();
	}
}
