using System.Threading.Tasks;
using Vegrocery.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Vegrocery.WebAPI.Contracts;
using Vegrocery.WebAPI.Parser;

namespace Vegrocery.WebAPI.Controllers
{
    [Route("api/v1/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductParser _productParser;
        private IProductService _productService;
        public ProductController(IProductParser productParser, IProductService productService)
        {
            _productParser = productParser;
            _productService = productService;
        }
        [HttpPut]
        public async Task<IActionResult> Put(ProductRequest productRequest)
        {
            var product = _productParser.ParseFrom(productRequest);
            _productService.Add(product);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("OK NOW");
        }

    }
}