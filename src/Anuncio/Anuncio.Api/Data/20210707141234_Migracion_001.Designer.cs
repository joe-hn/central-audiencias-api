// <auto-generated />
using System;
using Anuncio.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Anuncio.Api.Data
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20210707141234_Migracion_001")]
    partial class Migracion_001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Anuncio.Infrastructure.Entities.Aviso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedById")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("ModificationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("ModifiedById")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("Removed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("0");

                    b.Property<int>("duracion")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaFinalizacion")
                        .HasColumnType("date");

                    b.Property<string>("fechaFinalizacionDescripcion")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("fechaInicio")
                        .HasColumnType("date");

                    b.Property<string>("fechaInicioDescripcion")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("nombreArchivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("publicado")
                        .HasColumnType("bit");

                    b.Property<string>("tipoArchivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("tipoAviso")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Aviso");
                });
#pragma warning restore 612, 618
        }
    }
}
