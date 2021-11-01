using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class InventarioContext : DbContext
    {
        public InventarioContext()
        {
        }

        public InventarioContext(DbContextOptions<InventarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Bodega> Bodegas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }
        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Existencia> Existencias { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<NotaCredito> NotaCreditos { get; set; }
        public virtual DbSet<NotaDebito> NotaDebitos { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<Sucursal> Sucursals { get; set; }
        public virtual DbSet<TipoArticulo> TipoArticulos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Ventum> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-D4S5HLR\\DATALOCAL;Initial Catalog=Inventario;Trusted_connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.HasKey(e => e.Idarticulo)
                    .HasName("_copy_8");

                entity.ToTable("articulo");

                entity.Property(e => e.Idarticulo).HasColumnName("idarticulo");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Costo).HasColumnName("costo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.ProveedorIdproveedor).HasColumnName("proveedorIdproveedor");

                entity.Property(e => e.TipoIdtipoArticulo).HasColumnName("tipoIdtipoArticulo");

                entity.HasOne(d => d.ProveedorIdproveedorNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.ProveedorIdproveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_articulo_proveedor_1");

                entity.HasOne(d => d.TipoIdtipoArticuloNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.TipoIdtipoArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_articulo_tipoArticulo_1");
            });

            modelBuilder.Entity<Bodega>(entity =>
            {
                entity.HasKey(e => e.Idbodega)
                    .HasName("_copy_6");

                entity.ToTable("bodegas");

                entity.Property(e => e.Idbodega).HasColumnName("idbodega");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength(true);

                entity.Property(e => e.SucursalId).HasColumnName("sucursalId");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("_copy_7");

                entity.ToTable("cliente");

                entity.Property(e => e.Idcliente).HasColumnName("idcliente");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength(true);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nit");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.Idcompra)
                    .HasName("_copy_12");

                entity.ToTable("compra");

                entity.Property(e => e.Idcompra).HasColumnName("idcompra");

                entity.Property(e => e.BodegaId).HasColumnName("bodegaId");

                entity.Property(e => e.Fecha)
                    .HasPrecision(0)
                    .HasColumnName("fecha");

                entity.Property(e => e.ProveedorIdproveedor).HasColumnName("proveedorIdproveedor");

                entity.Property(e => e.SucursalId).HasColumnName("sucursalId");

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user");

                entity.HasOne(d => d.Bodega)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.BodegaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_compra_bodegas_1");

                entity.HasOne(d => d.Sucursal)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.SucursalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_compra_sucursal_1");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_compra_usuario_1");
            });

            modelBuilder.Entity<DetalleCompra>(entity =>
            {
                entity.HasKey(e => e.IddetalleCompra)
                    .HasName("_copy_9");

                entity.ToTable("detalleCompra");

                entity.Property(e => e.IddetalleCompra).HasColumnName("iddetalleCompra");

                entity.Property(e => e.ArticuloId).HasColumnName("articuloId");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CompraId).HasColumnName("compraId");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.ArticuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detalleCompra_articulo_1");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.DetalleCompras)
                    .HasForeignKey(d => d.CompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detalleCompra_compra_1");
            });

            modelBuilder.Entity<DetalleVentum>(entity =>
            {
                entity.HasKey(e => e.IddetalleVenta)
                    .HasName("_copy_2");

                entity.ToTable("detalleVenta");

                entity.Property(e => e.IddetalleVenta).HasColumnName("iddetalleVenta");

                entity.Property(e => e.ArticuloId).HasColumnName("articuloId");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.VentaId).HasColumnName("ventaId");

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.ArticuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detalleVenta_articulo_1");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_detalleVenta_venta_1");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Idempresa)
                    .HasName("_copy_15");

                entity.ToTable("empresa");

                entity.Property(e => e.Idempresa).HasColumnName("idempresa");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength(true);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nit");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Existencia>(entity =>
            {
                entity.HasKey(e => e.Idexistencia)
                    .HasName("_copy_5");

                entity.ToTable("existencias");

                entity.Property(e => e.Idexistencia).HasColumnName("idexistencia");

                entity.Property(e => e.ArticuloId).HasColumnName("articuloId");

                entity.Property(e => e.BodegaId).HasColumnName("bodegaId");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.Existencia)
                    .HasForeignKey(d => d.ArticuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_existencias_articulo_1");

                entity.HasOne(d => d.Bodega)
                    .WithMany(p => p.Existencia)
                    .HasForeignKey(d => d.BodegaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_existencias_bodegas_1");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasKey(e => e.Idmovimiento)
                    .HasName("_copy_4");

                entity.ToTable("movimientos");

                entity.Property(e => e.Idmovimiento).HasColumnName("idmovimiento");

                entity.Property(e => e.ArticuloId).HasColumnName("articuloId");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasPrecision(0)
                    .HasColumnName("fecha");

                entity.Property(e => e.TipoMovimiento)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("tipoMovimiento")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Articulo)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.ArticuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_movimientos_articulo_1");
            });

            modelBuilder.Entity<NotaCredito>(entity =>
            {
                entity.HasKey(e => e.IdnotaCredito)
                    .HasName("_copy_1");

                entity.ToTable("notaCredito");

                entity.Property(e => e.IdnotaCredito).HasColumnName("idnotaCredito");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength(true);

                entity.Property(e => e.Fecha)
                    .HasPrecision(0)
                    .HasColumnName("fecha");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.VentaId).HasColumnName("ventaId");

                entity.HasOne(d => d.Venta)
                    .WithMany(p => p.NotaCreditos)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_notaCredito_venta_1");
            });

            modelBuilder.Entity<NotaDebito>(entity =>
            {
                entity.HasKey(e => e.IdNotaDebito)
                    .HasName("_copy_3");

                entity.ToTable("notaDebito");

                entity.Property(e => e.IdNotaDebito).HasColumnName("idNotaDebito");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Fecha)
                    .HasPrecision(0)
                    .HasColumnName("fecha");

                entity.Property(e => e.NotaCreditoId).HasColumnName("notaCreditoId");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.NotaCredito)
                    .WithMany(p => p.NotaDebitos)
                    .HasForeignKey(d => d.NotaCreditoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_notaDebito_notaCredito_1");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.Idproveedor)
                    .HasName("_copy_11");

                entity.ToTable("proveedor");

                entity.Property(e => e.Idproveedor).HasColumnName("idproveedor");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength(true);

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nit");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.Idsucursal)
                    .HasName("_copy_13");

                entity.ToTable("sucursal");

                entity.Property(e => e.Idsucursal).HasColumnName("idsucursal");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.EmpresaId).HasColumnName("empresaId");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Sucursals)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sucursal_empresa_1");
            });

            modelBuilder.Entity<TipoArticulo>(entity =>
            {
                entity.HasKey(e => e.IdtipoArticulo)
                    .HasName("_copy_14");

                entity.ToTable("tipoArticulo");

                entity.Property(e => e.IdtipoArticulo).HasColumnName("idtipoArticulo");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("estado")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.User)
                    .HasName("PK__usuario__7FC76D7317DA9481");

                entity.ToTable("usuario");

                entity.Property(e => e.User)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user");

                entity.Property(e => e.EmpresaIdempresa).HasColumnName("empresaIdempresa");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Sucursaldsucursal).HasColumnName("sucursaldsucursal");

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("tipoUsuario")
                    .IsFixedLength(true);

                entity.HasOne(d => d.EmpresaIdempresaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.EmpresaIdempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario_empresa_1");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.Idventa)
                    .HasName("_copy_10");

                entity.ToTable("venta");

                entity.Property(e => e.Idventa).HasColumnName("idventa");

                entity.Property(e => e.ClienteId).HasColumnName("clienteId");

                entity.Property(e => e.Fecha)
                    .HasPrecision(0)
                    .HasColumnName("fecha");

                entity.Property(e => e.SucursalId).HasColumnName("sucursalId");

                entity.Property(e => e.TipoVenta)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("tipoVenta")
                    .IsFixedLength(true);

                entity.Property(e => e.User)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venta_cliente_1");

                entity.HasOne(d => d.Sucursal)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.SucursalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venta_sucursal_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
