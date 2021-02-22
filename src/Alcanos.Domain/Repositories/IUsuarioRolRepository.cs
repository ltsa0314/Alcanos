using Alcanos.Domain.Models;
using Alcanos.Domain.SeedWork;
using System.Collections.Generic;

namespace Alcanos.Domain.Repositories
{
    public interface IUsuarioRolRepository : IRepository<UsuarioRol>
    {
        bool ExistsRoles(int usuarioId);
        List<UsuarioRol> GetByUserId(int usuarioId);
        void Delete(int usuarioId, int rolId);
    }
}
