using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using APIFOODV2.Model;
namespace APIFOODV2.Data
{
    public class DbContextAPI : DbContext
    {
        public DbContextAPI(DbContextOptions<DbContextAPI> options) : base(options)
        {

        }
        public DbSet<Bitacora> Bitacora { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<CuentasPorCobrar> CuentasPorCobrar { get; set; }
        public DbSet<DetFactura> DetFactura { get; set; }
        public DbSet<Factura> Factura { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CuentasPorCobrar>()
                .HasKey(c => new { c.NumFactura, c.CodCliente });
            modelBuilder.Entity<DetFactura>()
                .HasKey(c => new { c.NumFactura, c.CodInterno });
        }
    }
}

