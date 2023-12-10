using TaskRepository.Entities;

namespace TaskServices.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
    }
}
