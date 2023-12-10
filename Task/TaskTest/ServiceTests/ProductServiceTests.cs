using Moq;
using TaskRepository.Entities;
using TaskRepository.Repositories.Interfaces;
using TaskServices.Services.Implementations;

namespace TaskTest.ServiceTests
{
    [TestClass]
    public class ProductServiceTests
    {
        [TestMethod]
        public async Task GetProducts_ShouldReturnAllProductsFromRepository()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(repo => repo.GetAllProducts())
                .ReturnsAsync(new List<Product>
                {
                    new() { Id = 1, Name = "Product 1" },
                    new() { Id = 2, Name = "Product 2" },
                    new() { Id = 3, Name = "Product 3" },
                    new() { Id = 4, Name = "Product 4" },
                    new() { Id = 5, Name = "Product 5" },
                    new() { Id = 6, Name = "Product 6" },
                    new() { Id = 7, Name = "Product 7" },
                    new() { Id = 8, Name = "Product 8" },
                });

            var productService = new ProductService(mockRepository.Object);

            var result = await productService.GetProducts();

            Assert.AreEqual(8, result.Count);
            Assert.AreEqual("Product 1", result[0].Name);
            Assert.AreEqual("Product 2", result[1].Name);
        }
    }
}