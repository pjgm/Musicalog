using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
	public static class Injector
	{
		public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
		{
			string albumsConnectionString = configuration.GetConnectionString("AlbumsConnection");

			services.AddSingleton<IAlbumService, AlbumService>();
			services.AddSingleton<IAlbumRepository>(s => new AlbumRepository(albumsConnectionString));
			services.AddSingleton<IInventoryService, InventoryService>();
			services.AddSingleton<IInventoryRepository>(s => new InventoryRepository(albumsConnectionString));
		}
	}
}
