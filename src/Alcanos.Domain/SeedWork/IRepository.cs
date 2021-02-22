using System.Collections.Generic;

namespace Alcanos.Domain.SeedWork
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);       
        TEntity GetById(int id);
        List<TEntity> GetAll();
    }
}
