using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using System.Threading.Tasks;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var result = await _productRepository.GetProductList();
            return Ok(result);
        }

        [HttpGet("GetProductWithCategoryName")]
        public async Task<IActionResult> GetProductWithCategoryName()
        {
            var result = await _productRepository.GetProductWithCategoryList();
            return Ok(result);
        }
    }
}
