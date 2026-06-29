using System;
using Microsoft.EntityFrameworkCore;
using MilyLab.API.Models;

namespace MilyLab.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Producto> Productos { get; set; }
    public DbSet<Cotizacion> Cotizaciones { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoProducto> PedidoProductos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relación Pedido ? PedidoProducto
        modelBuilder.Entity<PedidoProducto>()
            .HasOne(pp => pp.Pedido)
            .WithMany(p => p.Productos)
            .HasForeignKey(pp => pp.PedidoId);

        // Relación Producto ? PedidoProducto
        modelBuilder.Entity<PedidoProducto>()
            .HasOne(pp => pp.Producto)
            .WithMany()
            .HasForeignKey(pp => pp.ProductoId);

        // Precio siempre con 2 decimales
        modelBuilder.Entity<Producto>()
            .Property(p => p.Precio)
            .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<Pedido>()
            .Property(p => p.Total)
            .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<PedidoProducto>()
            .Property(p => p.PrecioUnitario)
            .HasColumnType("decimal(10,2)");
    }
}