using ListaReproduccionAudiencia.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEJE.EFCORE.Extensions;
using System;

namespace ListaReproduccionAudiencia.Infrastructure.EntityConfiguration
{
    public class AudienciaEntityConfiguration : IEntityTypeConfiguration<Audiencia>
    {
        public void Configure(EntityTypeBuilder<Audiencia> builder)
        {
            builder.ConfigurationBase<Guid, string, Audiencia>();

            builder.ToTable("Audiencia");

            builder.Property(x => x.NumeroAudiencia).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.TipoAudiencia).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.Despacho).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.Hora).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.NumeroExpediente).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.EstadoAudiencia).HasColumnType("nvarchar(500)").IsRequired();

            builder.Property(x => x.CreatedById).IsRequired(false);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.ModifiedById).IsRequired(false);
            builder.Property(x => x.ModificationDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Removed).HasDefaultValueSql("0");
        }
    }
}
