using Microsoft.EntityFrameworkCore;
using TaskRepository.Entities;

namespace TaskRepository.Data
{
    public class TaskContext(DbContextOptions<TaskContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
    }
}