using Alcanos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alcanos.Infraestructure
{
    public partial class SeguridadDbContext : DbContext
    {
        public SeguridadDbContext()
        {
        }

        public SeguridadDbContext(DbContextOptions<SeguridadDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Opcion> Opcion { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<RolOpcion> RolOpcion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Seguridad;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (this.Database.IsSqlServer())
            {
                modelBuilder.HasDefaultSchema("dbo");
            }
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SeguridadDbContext).Assembly);

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

    }
}
