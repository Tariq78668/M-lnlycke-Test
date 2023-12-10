using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskAPI.Controllers;
using TaskRepository.Entities;
using TaskServices.Services.Interfaces;

namespace TaskTest.ControllerTests
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public async Task GetProducts_ShouldReturnOkWithProductsFromService()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            mockService.Setup(service => service.GetProducts())
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

            var controller = new ProductController(mockService.Object);

            // Act
            var result = await controller.GetProducts() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            var products = result.Value as List<Product>;
            Assert.IsNotNull(products);
            Assert.AreEqual(8, products.Count);
            Assert.AreEqual("Product 1", products[0].Name);
            Assert.AreEqual("Product 2", products[1].Name);
        }
    }
}