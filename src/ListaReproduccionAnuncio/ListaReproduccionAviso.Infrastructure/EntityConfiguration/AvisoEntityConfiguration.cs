using ListaReproduccionAviso.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEJE.EFCORE.Extensions;
using System;

namespace ListaReproduccionAviso.Infrastructure.EntityConfiguration
{
    public class AvisoEntityConfiguration : IEntityTypeConfiguration<Aviso>
    {
        public void Configure(EntityTypeBuilder<Aviso> builder)
        {
            builder.ConfigurationBase<Guid, string, Aviso>();

            builder.ToTable("Aviso");

            builder.Property(x => x.tipoVideo).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.titulo).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.url).HasColumnType("varchar(500)").IsRequired();
            builder.Property(x => x.duracion).IsRequired();

            builder.Property(x => x.CreatedById).IsRequired(false);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.ModifiedById).IsRequired(false);
            builder.Property(x => x.ModificationDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Removed).HasDefaultValueSql("0");
        }
    }
}
