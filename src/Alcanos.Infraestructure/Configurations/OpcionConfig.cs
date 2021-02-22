using Alcanos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alcanos.Infraestructure.Configurations
{
    public class OpcionConfig : IEntityTypeConfiguration<Opcion>
    {
        public void Configure(EntityTypeBuilder<Opcion> builder)
        {
            builder.ToTable("Opcion");
            builder.HasKey(x => x.OpcionId);
            builder.Property(e => e.OpcionId).IsRequired().ValueGeneratedOnAdd();
            builder.Property(e => e.Nombre).HasMaxLength(100);
        }
    }
}
