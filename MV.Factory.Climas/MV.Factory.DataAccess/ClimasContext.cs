using Microsoft.EntityFrameworkCore;
using MV.Factory.Domain.Implementaciones;

namespace MV.Factory.DataAccess
{
    public class ClimasContext: DbContext
    {
        public ClimasContext(DbContextOptions<ClimasContext> options) : base(options)
        {
        }

        public DbSet<ZonaClima> ZonasClimas { get; set; }
        public DbSet<HistorialConsultaClima> HistorialConsultaClimas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZonaClima>().ToTable("ZonaClima").HasKey(p => p.ID);
            
            modelBuilder.Entity<HistorialConsultaClima>()
                .ToTable("HistorialConsultaClima").HasKey(p => p.ID);

            modelBuilder.Entity<HistorialConsultaClima>()
                .HasOne(p => p.ZonaClima)
                .WithMany()
                .HasForeignKey("IdZonaClima");
        }
    }
}
