using Alcanos.Domain.Models;
using Alcanos.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alcanos.Infraestructure.Repositories
{
    public class RolRepository : BaseRepository<Rol>, IRolRepository
    {
        public RolRepository(SeguridadDbContext context) : base(context)
        {
        }

    }
}
