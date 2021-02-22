using Alcanos.Domain.Models;
using Alcanos.Domain.SeedWork;
using System.Collections.Generic;

namespace Alcanos.Domain.Repositories
{
    public interface IRolOpcionRepository : IRepository<RolOpcion>
    {
        bool ExistsOpciones(int rolId);
        List<RolOpcion> GetByRolId(int rolId);
        void Delete(int rolId , int opcionId);
    }
}
