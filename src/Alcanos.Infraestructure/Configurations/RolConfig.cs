using Alcanos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alcanos.Infraestructure.Configurations
{
    public class RolConfig : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol");
            builder.HasKey(x => x.RolId);
            builder.Property(e => e.RolId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(e => e.Nombre).HasMaxLength(100);
        }
    }
}
