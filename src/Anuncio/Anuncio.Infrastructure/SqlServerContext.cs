using Anuncio.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using SEJE.EFCORE.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Anuncio.Infrastructure
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

        public DbSet<Aviso> Aviso { get; set; }        
    }
}
