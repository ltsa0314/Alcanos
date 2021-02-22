using Alcanos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alcanos.Infraestructure.Configurations
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.UsuarioId);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Contrasena).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Correo).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Fecha).HasColumnType("date");
        }
    }
}
