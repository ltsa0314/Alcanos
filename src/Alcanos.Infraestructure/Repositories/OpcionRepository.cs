using Alcanos.Domain.Models;
using Alcanos.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Alcanos.Infraestructure.Repositories
{
    public class OpcionRepository : BaseRepository<Opcion>, IOpcionRepository
    {
        public OpcionRepository(SeguridadDbContext context) : base(context)
        {
        }
    }
}
