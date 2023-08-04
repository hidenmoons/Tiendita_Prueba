using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prueba_Tecnica.Models;

public partial class StoreLowCostContext : DbContext
{
    public StoreLowCostContext()
    {
    }

    public StoreLowCostContext(DbContextOptions<StoreLowCostContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<CarritoDetail> CarritoDetails { get; set; }

    public virtual DbSet<DetallesPedido> DetallesPedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=Store_LowCost; Trusted_Connection=True;TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.CarritoId).HasName("PK__Carrito__778D580BE882E807");

            entity.ToTable("Carrito");

            entity.Property(e => e.CarritoId).HasColumnName("CarritoID");
            entity.Property(e => e.CarritoStatus)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Carrito__UserID__29572725");
        });

        modelBuilder.Entity<CarritoDetail>(entity =>
        {
            entity.HasKey(e => e.IddetalleCarrito).HasName("PK__CarritoD__2B49305F89324B03");

            entity.Property(e => e.IddetalleCarrito)
                .ValueGeneratedOnAdd()
                .HasColumnName("IDDetalleCarrito");
            entity.Property(e => e.Idcarrito).HasColumnName("IDCarrito");
            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdcarritoNavigation).WithMany(p => p.CarritoDetails)
                .HasForeignKey(d => d.Idcarrito)
                .HasConstraintName("FK__CarritoDe__IDCar__2C3393D0");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.CarritoDetails)
                .HasForeignKey(d => d.Idproducto)
                .HasConstraintName("FK__CarritoDe__IDPro__2D27B809");
        });

        modelBuilder.Entity<DetallesPedido>(entity =>
        {
            entity.HasKey(e => e.IddetallePedido).HasName("PK__Detalles__8F0552448A37C78A");

            entity.ToTable("DetallesPedido");

            entity.Property(e => e.IddetallePedido)
                .ValueGeneratedNever()
                .HasColumnName("IDDetallePedido");
            entity.Property(e => e.Idpedido).HasColumnName("IDPedido");
            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdpedidoNavigation).WithMany(p => p.DetallesPedidos)
                .HasForeignKey(d => d.Idpedido)
                .HasConstraintName("FK__DetallesP__IDPed__32E0915F");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.DetallesPedidos)
                .HasForeignKey(d => d.Idproducto)
                .HasConstraintName("FK__DetallesP__IDPro__33D4B598");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Idpedido).HasName("PK__Pedidos__00C11F9937C6F766");

            entity.Property(e => e.Idpedido)
                
                .HasColumnName("IDPedido");
            entity.Property(e => e.DireccionEnvio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EstadoPedido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaHoraPedido).HasColumnType("datetime");
            entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            entity.Property(e => e.TotalPedido).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdusuarioNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idusuario)
                .HasConstraintName("FK__Pedidos__IDUsuar__300424B4");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED0B8919B4");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Categoria)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Descript)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Imagen)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACCE563371");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534695286F7").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Addres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Passwo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
