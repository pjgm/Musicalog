using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoFixture;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace WebApi.Tests.Controllers
{
	public class AlbumsControllerTests
	{
		private const int MockAlbumId = 1;

		private Mock<IAlbumsController> albumsController;

		public AlbumsControllerTests()
		{
			albumsController = new Mock<IAlbumsController>();
		}

		[Fact]
		public void GetAlbumById_ValidId_ReturnsEntity()
		{
			// Arrange
			var fixture = new Fixture();
			var mockAlbum = fixture.Create<Task<Album>>();
			albumsController.Setup(controller => controller.Get(MockAlbumId)).Returns(mockAlbum);

			// Act
			var result = albumsController.Object.Get(MockAlbumId);

			// Assert
			Assert.Equal(mockAlbum, result);
		}
	}
}
