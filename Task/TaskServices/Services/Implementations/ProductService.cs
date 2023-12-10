using TaskRepository.Entities;
using TaskRepository.Repositories.Interfaces;
using TaskServices.Services.Interfaces;

namespace TaskServices.Services.Implementations
{
    public class ProductService(IProductRepository repository) : IProductService
    {
        private readonly IProductRepository _repository = repository;

        public async Task<List<Product>> GetProducts()
        {
            return await _repository.GetAllProducts();
        }
    }
}