using Microsoft.EntityFrameworkCore;
using TaskRepository.Data;
using TaskRepository.Entities;
using TaskRepository.Repositories.Interfaces;

namespace TaskRepository.Repositories.Implementations
{
    public class ProductRepository(TaskContext context) : IProductRepository
    {
        private readonly TaskContext _context = context;

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}