using Alcanos.Domain.Models;
using Alcanos.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alcanos.Infraestructure.Repositories
{
    public class UsuarioRolRepository : BaseRepository<UsuarioRol>, IUsuarioRolRepository
    {
        public UsuarioRolRepository(SeguridadDbContext context) : base(context)
        {
        }

        public void Delete(int usuarioId, int rolId)
        {
            if (usuarioId == 0)
                throw new ArgumentNullException(nameof(usuarioId));

            if (rolId == 0)
                throw new ArgumentNullException(nameof(usuarioId));

            UsuarioRol entity = _dbSet.Find(usuarioId, rolId);

            if (entity is null)
                throw new Exception("Entity No Found.");

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public bool ExistsRoles(int usuarioId)
        {
            IQueryable<UsuarioRol> query = _dbSet.AsNoTracking();
            return query.Any(x => x.UsuarioId == usuarioId);
        }

        public List<UsuarioRol> GetByUserId(int usuarioId)
        {
            IQueryable<UsuarioRol> query = _dbSet.AsNoTracking();
            return query.Where(x=> x.UsuarioId == usuarioId).ToList();
        }
    }
}
