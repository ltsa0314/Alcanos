using Alcanos.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alcanos.Infraestructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SeguridadDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(SeguridadDbContext context)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(id));

            TEntity entity = _dbSet.Find(id);

            if (entity is null)
                throw new ArgumentException("Entity No Found.", nameof(id));

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
        public virtual List<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return query.ToList();
        }
        public virtual TEntity GetById(int id)
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(id));

            var entity = _dbSet.Find(id);

            return entity;
        }
        public virtual void Insert(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public virtual void Update(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _dbSet.Update(entity);
            _context.SaveChanges();
        }

    }
}
