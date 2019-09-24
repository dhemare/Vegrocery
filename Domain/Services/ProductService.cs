using Vegrocery.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Vegrocery.Infrastructure.Repository;

namespace Vegrocery.Domain.Services
{    
    public interface IProductService
    {
        void Add(Product product);
    }
    public class ProductService : IProductService
    {
        private IDataRepository<Product> _dataRepository;
        public ProductService(IDataRepository<Product> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public void Add(Product product)
        {
            _dataRepository.Add(product);
        }
    }
}
