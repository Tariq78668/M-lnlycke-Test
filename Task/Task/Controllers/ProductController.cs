using Microsoft.AspNetCore.Mvc;
using TaskServices.Services.Interfaces;

namespace TaskAPI.Controllers
{
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        //
        // Get: //GetProducts
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _productService.GetProducts());
        }
    }
}