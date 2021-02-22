using Alcanos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alcanos.Infraestructure.Configurations
{
    public class UsuarioRolConfig : IEntityTypeConfiguration<UsuarioRol>
    {
        public void Configure(EntityTypeBuilder<UsuarioRol> builder)
        {
            builder.ToTable("UsuarioRol");
            builder.HasKey(x => new { x.UsuarioId, x.RolId });
            builder.Property(x => x.UsuarioId).IsRequired();
            builder.Property(x => x.RolId).IsRequired();
        }
    }
}
