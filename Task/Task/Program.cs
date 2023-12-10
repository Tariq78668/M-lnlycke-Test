using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TaskRepository.Data;
using TaskRepository.Entities;
using TaskRepository.Repositories.Implementations;
using TaskRepository.Repositories.Interfaces;
using TaskServices.Services.Implementations;
using TaskServices.Services.Interfaces;

namespace TaskAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddDbContext<TaskContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddCors(option =>
            {
                option.AddPolicy(name: "AllowAnyOrigin", policy => policy.AllowAnyOrigin());
            });

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.MapControllerRoute(name: "default", pattern: "{controller=Product}/{action=GetProducts}");

            app.UseCors("AllowAnyOrigin");

            SeedData(app);

            app.Run();
        }

        public static void SeedData(WebApplication? app)
        {
            using var scope = app?.Services.CreateScope();
            var context = scope?.ServiceProvider.GetRequiredService<TaskContext>();

            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "data.json");
            var products = JsonConvert.DeserializeObject<List<Product>>(json);
            context?.Products.AddRange(products ?? []);
            context?.SaveChanges();
        }
    }
}