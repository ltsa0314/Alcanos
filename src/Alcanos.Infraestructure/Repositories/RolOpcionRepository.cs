using Alcanos.Domain.Models;
using Alcanos.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alcanos.Infraestructure.Repositories
{
    public class RolOpcionRepository : BaseRepository<RolOpcion>, IRolOpcionRepository
    {
        public RolOpcionRepository(SeguridadDbContext context) : base(context)
        {
        }

        public void Delete(int rolId, int opcionId)
        {
            if (rolId == 0)
                throw new ArgumentNullException(nameof(rolId));

            if (opcionId == 0)
                throw new ArgumentNullException(nameof(opcionId));

            RolOpcion entity = _dbSet.Find(rolId, opcionId);

            if (entity is null)
                throw new Exception("Entity No Found.");

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public bool ExistsOpciones(int rolId)
        {
            IQueryable<RolOpcion> query = _dbSet.AsNoTracking();
            return query.Any(x => x.RolId == rolId);
        }

        public List<RolOpcion> GetByRolId(int rolId)
        {
            IQueryable<RolOpcion> query = _dbSet.AsNoTracking();
            return query.Where(x => x.RolId == rolId).ToList();
        }
    }
}
