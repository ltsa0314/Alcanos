using Alcanos.Domain.Models;
using Alcanos.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Alcanos.Infraestructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SeguridadDbContext context) : base(context)
        {
        }
    }
}
