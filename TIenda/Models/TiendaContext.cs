using Microsoft.EntityFrameworkCore;

namespace TIenda.Models
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para Usuario
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.IdUsuario);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Nombre)
                .HasColumnType("VARCHAR(100)");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .HasColumnType("VARCHAR(255)");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Contraseña)
                .HasColumnType("VARCHAR(255)");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Rol)
                .HasColumnType("VARCHAR(50)");

            // Configuración para Producto
            modelBuilder.Entity<Producto>()
                .HasKey(p => p.IdProducto);

            modelBuilder.Entity<Producto>()
                .Property(p => p.Nombre)
                .HasColumnType("VARCHAR(100)");

            modelBuilder.Entity<Producto>()
                .Property(p => p.Descripcion)
                .HasColumnType("TEXT");

            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("DECIMAL(18,2)");

            modelBuilder.Entity<Producto>()
                .Property(p => p.Stock)
                .HasColumnType("INT");

            // Configuración para Pedido
            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.IdPedido);

            modelBuilder.Entity<Pedido>()
                .Property(p => p.Fecha)
                .HasColumnType("DATETIME");

            modelBuilder.Entity<Pedido>()
                .Property(p => p.Total)
                .HasColumnType("DECIMAL(18,2)");

            // Configuración para DetallePedido
            modelBuilder.Entity<DetallePedido>()
    .HasKey(d => d.IdDetalle);

            modelBuilder.Entity<DetallePedido>()
                .Property(d => d.IdDetalle)
                .ValueGeneratedOnAdd();

            // No se definen relaciones para evitar errores

            base.OnModelCreating(modelBuilder); // Llamada a la base
        }
    }
}
