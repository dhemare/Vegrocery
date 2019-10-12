using System.Threading.Tasks;
using Vegrocery.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Vegrocery.WebAPI.Contracts;
using Vegrocery.WebAPI.Parser;
using Vegrocery.Infrastructure.Entities;

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

        [HttpPost]
        public async Task<IActionResult> Update(ProductRequest productRequest)
        {           
            var product = _productParser.ParseFrom(productRequest);           
            _productService.Update(product);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ProductRequest productRequest)
        {
            var product = _productParser.ParseFrom(productRequest);
            _productService.Delete(product);

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _productService.GetAll();
            return Ok();
        }
                          
    }
}