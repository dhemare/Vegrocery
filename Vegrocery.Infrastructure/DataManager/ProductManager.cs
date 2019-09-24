using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vegrocery.Infrastructure.DBContext;
using Vegrocery.Infrastructure.Entities;
using Vegrocery.Infrastructure.Repository;

namespace Vegrocery.Infrastructure.DataManager
{
    public class ProductManager : IDataRepository<Product>
    {
        private ProductContext _productContext;
        public ProductManager(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public Product Get(long id)
        {
            return _productContext.Products.FirstOrDefault(e => e.ProductId==id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productContext.Products.ToList();
        }
        public void Add(Product entity)
        {
            _productContext.Products.Add(entity);
            _productContext.SaveChanges();
        }             
        public void Update(Product dbentity, Product entity)
        {
            dbentity.Name = entity.Name;
            dbentity.Type = entity.Type;
            dbentity.IsActive = entity.IsActive;
            dbentity.UpdatedOn = entity.UpdatedOn;

            _productContext.SaveChanges();
        }
        public void Delete(Product entity)
        {
            _productContext.Products.Remove(entity);
            _productContext.SaveChanges();
        }
    }
}
