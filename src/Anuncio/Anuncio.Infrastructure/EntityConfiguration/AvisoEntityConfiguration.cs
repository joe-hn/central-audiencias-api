using Anuncio.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEJE.EFCORE.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anuncio.Infrastructure.EntityConfiguration
{
    public class AvisoEntityConfiguration : IEntityTypeConfiguration<Aviso>
    {
        public void Configure(EntityTypeBuilder<Aviso> builder)
        {
            builder.ConfigurationBase<Guid, string, Aviso>();

            builder.ToTable("Aviso");

            builder.Property(x => x.titulo).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.tipoArchivo).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.tipoAviso).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.fechaInicio).HasColumnType("date").IsRequired();
            builder.Property(x => x.fechaFinalizacion).HasColumnType("date").IsRequired();

            builder.Property(x => x.fechaInicioDescripcion).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.fechaFinalizacionDescripcion).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.nombreArchivo).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.duracion).IsRequired();
            builder.Property(x => x.url).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.publicado).IsRequired();

            builder.Property(x => x.CreatedById).IsRequired(false);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.ModifiedById).IsRequired(false);
            builder.Property(x => x.ModificationDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.Removed).HasDefaultValueSql("0");
            
        }
    }
}
