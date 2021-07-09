using ListaReproduccionAudiencia.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using SEJE.EFCORE.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace ListaReproduccionAudiencia.Infrastructure
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.RegisterEntityConfigurations<SqlServerContext>();
        }

        public DbSet<Audiencia> Audiencia { get; set; }
        public DbSet<Parte> Parte { get; set; }
    }
}
