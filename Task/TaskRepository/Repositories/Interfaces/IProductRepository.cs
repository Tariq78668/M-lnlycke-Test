using TaskRepository.Entities;

namespace TaskRepository.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
    }
}