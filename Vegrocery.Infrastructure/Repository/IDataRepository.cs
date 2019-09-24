using System;
using System.Collections.Generic;
using System.Text;

namespace Vegrocery.Infrastructure.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity dbentity, TEntity entity);
        void Delete(TEntity entity);
    }
}
