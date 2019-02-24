using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
	public interface IAlbumsController
	{
		Task<IEnumerable<Album>> Get();
		Task<Album> Get(int id);
	}
}
