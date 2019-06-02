using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using AutoFixture;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ApplicationCore.Tests.Services
{
	public class InventoryServiceTests
	{
		private const int MockAlbumId = 1;

		private Mock<IInventoryRepository> inventoryRepository;
		private IInventoryService inventoryService;
		private IFixture fixture;

		public InventoryServiceTests()
		{
			inventoryRepository = new Mock<IInventoryRepository>();
			fixture = new Fixture();
		}

		[Fact]
		public void GetEntryByAlbumIdAsync_InvalidAlbumId_ThrowsException()
		{
			// Arrange
			inventoryRepository.Setup(repo => repo.GetEntryByAlbumIdAsync(It.IsAny<int>())).Returns(Task.FromResult((InventoryEntry)null));
			inventoryService = new InventoryService(inventoryRepository.Object);

			// Act & Assert
			Assert.ThrowsAsync<InventoryEntryNotFoundException>(async () => await inventoryService.GetEntryByAlbumIdAsync(MockAlbumId));
		}

		[Fact]
		public void GetEntryByAlbumIdAsync_ValidAlbumId_ReturnsEntry()
		{
			// Arrange
			var mockEntry = fixture.Create<Task<InventoryEntry>>();
			inventoryRepository.Setup(repo => repo.GetEntryByAlbumIdAsync(1)).Returns(mockEntry);
			inventoryService = new InventoryService(inventoryRepository.Object);

			// Act
			var result = inventoryService.GetEntryByAlbumIdAsync(1);

			// Assert
			Assert.Equal(mockEntry.Result, result.Result);
		}
	}
}

