using System;
using System.Collections.Generic;
using System.Text;
using Vegrocery.Infrastructure.Repository;
using Vegrocery.Infrastructure.Entities;
using Vegrocery.Domain.DTO;
using System.Linq;

namespace Vegrocery.Domain.Services
{    
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        IEnumerable<Product> GetAll();
        Product Get(long id);

    }
    public class ProductService : IProductService
    {
        private IDataRepository<ProductEntity> _dataRepository;
        public ProductService(IDataRepository<ProductEntity> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public Product Get(long id)
        {
            return ParseEntityToProduct(_dataRepository.Get(id));
        }
        public IEnumerable<Product> GetAll()
        {
             return _dataRepository.GetAll().Select(x=>ParseEntityToProduct(x)).ToList();

                      
        }
        public void Add(Product product)
        {
            _dataRepository.Add(ParseProductToEntity(product));
        }
        public void Delete(Product product)
        {
            _dataRepository.Delete(ParseProductToEntity(product));
        } 
        public void Update( Product product)
        {
            var dbproduct = Get(product.Id);
            _dataRepository.Update(ParseProductToEntity(dbproduct), ParseProductToEntity(product));
        }

        private ProductEntity ParseProductToEntity(Product product)
        {
            return new ProductEntity
            {
                IsActive = product.IsActive,
                Name = product.Name,
                ProductId = product.Id,
                Type = product.Type,
                UpdatedOn = product.UpdatedOn
            };
        }

        private Product ParseEntityToProduct(ProductEntity productEntity)
        {
            return new Product()
            {
                Id = productEntity.ProductId,
                Name = productEntity.Name,
                UpdatedOn = productEntity.UpdatedOn,
                IsActive = productEntity.IsActive,
                Type = productEntity.Type
            };
        }
    }
}
