using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vegrocery.Infrastructure.DBContext;
using Vegrocery.Infrastructure.Entities;
using Vegrocery.Infrastructure.Repository;

namespace Vegrocery.Infrastructure.DataManager
{
    public class ProductManager : IDataRepository<ProductEntity>
    {
        private ProductContext _productContext;
        public ProductManager(ProductContext productContext)
        {
            _productContext = productContext;
        }
        public ProductEntity Get(long id)
        {
            return _productContext.Products.FirstOrDefault(e => e.ProductId==id);
        }

        public IEnumerable<ProductEntity> GetAll()
        {
            return _productContext.Products.ToList();
        }
        public void Add(ProductEntity entity)
        {
            _productContext.Products.Add(entity);
            _productContext.SaveChanges();
        }             
        public void Update(ProductEntity dbentity, ProductEntity entity)
        {
            dbentity.Name = entity.Name;
            dbentity.Type = entity.Type;
            dbentity.IsActive = entity.IsActive;
            dbentity.UpdatedOn = entity.UpdatedOn;

            _productContext.SaveChanges();
        }
        public void Delete(ProductEntity entity)
        {
            _productContext.Products.Remove(entity);
            _productContext.SaveChanges();
        }
    }
}
