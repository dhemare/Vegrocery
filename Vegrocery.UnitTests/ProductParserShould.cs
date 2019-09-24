using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Vegrocery.Domain.DTO;
using Vegrocery.WebAPI.Contracts;
using Vegrocery.WebAPI.Parser;
using Xunit;

namespace Vegrocery.UnitTests
{
    public class ProductParserShould
    {
        private readonly ProductParser _productParser;
        public ProductParserShould()
        {
            _productParser = new ProductParser();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ParseFromProductRequestToProductDTO(ProductRequest productRequest,Product product)
        {
            var result = _productParser.ParseFrom(productRequest);

            result.Name.ShouldBe(product.Name);
            result.IsActive.ShouldBe(product.IsActive);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] {
              new ProductRequest()
            {
                Name = "Coriander",
                IsActive = true
            },
              new Product()
            {
                Name = "Coriander",
                IsActive = true,
                UpdatedOn = DateTime.Now
            }
            },
            new object[] {
                 new ProductRequest()
            {
                Name = "Dill",
                IsActive = false
            },
              new Product()
            {
                Name = "Dill",
                IsActive = false,
                UpdatedOn = DateTime.Now
            }
            },
            new object[] {
                 new ProductRequest()
            {
                Name = "Tomato",
                IsActive = true
            },
              new Product()
            {
                Name = "Tomato",
                IsActive = true,
                UpdatedOn = DateTime.Now
            }
            },

        };
    }
}
