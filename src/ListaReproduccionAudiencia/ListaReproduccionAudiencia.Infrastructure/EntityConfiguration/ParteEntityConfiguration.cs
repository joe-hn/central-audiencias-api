using ListaReproduccionAudiencia.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEJE.EFCORE.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaReproduccionAudiencia.Infrastructure.EntityConfiguration
{
    public class ParteEntityConfiguration : IEntityTypeConfiguration<Parte>
    {
        public void Configure(EntityTypeBuilder<Parte> builder)
        {
            builder.ConfigurationBase<Guid, string, Parte>();

            builder.ToTable("Parte");

            builder.Property(x => x.Nombre).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.TipoParte).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.TipoPersona).HasColumnType("nvarchar(500)").IsRequired();

            builder.Property(x => x.CreatedById).IsRequired(false);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.ModifiedById).IsRequired(false);
            builder.Property(x => x.ModificationDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Removed).HasDefaultValueSql("0");

            builder.HasOne(x => x.Audiencia).WithMany(x => x.Partes).HasForeignKey(x => x.AudienciaId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
