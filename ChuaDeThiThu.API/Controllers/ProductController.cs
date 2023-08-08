using ChuaDeThiThu.API.Services.IServices;
using ChuaDeThiThu.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChuaDeThiThu.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var result = await this.productService.AddProduct(product);
            return Created("", product);
        }

        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await this.productService.GetProducts();
            return Ok(result);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await this.productService.DeleteProduct(id);
            return Ok();
        }
    }
}
