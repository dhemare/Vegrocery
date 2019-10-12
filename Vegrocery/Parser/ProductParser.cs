using System;
using Vegrocery.Domain.DTO;
using Vegrocery.WebAPI.Contracts;

namespace Vegrocery.WebAPI.Parser
{
    public interface IProductParser
    {
        Product ParseFrom(ProductRequest productRequest);
    }
    public class ProductParser : IProductParser
    {
        public Product ParseFrom(ProductRequest productRequest)
        {
            return new Product()
            {
                Name = productRequest.Name,
                IsActive = productRequest.IsActive,
                UpdatedOn = DateTime.Now
            };
        }

    }
}
