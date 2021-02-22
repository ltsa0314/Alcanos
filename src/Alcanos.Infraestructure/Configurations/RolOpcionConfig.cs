using Alcanos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alcanos.Infraestructure.Configurations
{
    public class RolOpcionConfig : IEntityTypeConfiguration<RolOpcion>
    {
        public void Configure(EntityTypeBuilder<RolOpcion> builder)
        {
            builder.ToTable("RolOpcion");
            builder.HasKey(x => new { x.RolId, x.OpcionId });
            builder.Property(e => e.RolId).IsRequired();
            builder.Property(e => e.OpcionId).IsRequired();
        }
    }
}
