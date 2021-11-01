CREATE DATABASE Inventario;

use Inventario;

CREATE TABLE [articulo] (
  [idarticulo] int  IDENTITY(1,1) NOT NULL,
  [codigo] varchar(255) NOT NULL,
  [descripcion] varchar(255) NOT NULL,
  [tipoIdtipoArticulo] int NOT NULL,
  [costo] float(10) NOT NULL,
  [precio] float(10) NOT NULL,
  [proveedorIdproveedor] int NOT NULL,
  CONSTRAINT [_copy_8] PRIMARY KEY CLUSTERED ([idarticulo])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [bodegas] (
  [idbodega] int  IDENTITY(1,1) NOT NULL,
  [descripcion] varchar(255) NOT NULL,
  [sucursalId] int NOT NULL,
  [estado] char(1) NOT NULL,
  CONSTRAINT [_copy_6] PRIMARY KEY CLUSTERED ([idbodega])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [cliente] (
  [idcliente] int  IDENTITY(1,1) NOT NULL,
  [nit] varchar(255) NOT NULL,
  [nombre] varchar(255) NOT NULL,
  [estado] char(1) NOT NULL,
  CONSTRAINT [_copy_7] PRIMARY KEY CLUSTERED ([idcliente])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [compra] (
  [idcompra] int  IDENTITY(1,1) NOT NULL,
  [proveedorIdproveedor] int NOT NULL,
  [user] varchar(255) NOT NULL,
  [fecha] datetime2(0) NOT NULL,
  [sucursalId] int NOT NULL,
  [bodegaId] int NOT NULL,
  CONSTRAINT [_copy_12] PRIMARY KEY CLUSTERED ([idcompra])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [detalleCompra] (
  [iddetalleCompra] int  IDENTITY(1,1) NOT NULL,
  [articuloId] int NOT NULL,
  [cantidad] int NOT NULL,
  [precio] float NOT NULL,
  [compraId] int NOT NULL,
  CONSTRAINT [_copy_9] PRIMARY KEY CLUSTERED ([iddetalleCompra])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO


CREATE TABLE [detalleVenta] (
  [iddetalleVenta] int  IDENTITY(1,1) NOT NULL,
  [articuloId] int NOT NULL,
  [cantidad] int NOT NULL,
  [precio] float(10) NULL,
  [ventaId] int NOT NULL,
  CONSTRAINT [_copy_2] PRIMARY KEY CLUSTERED ([iddetalleVenta])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [empresa] (
  [idempresa] int  IDENTITY(1,1) NOT NULL,
  [nit] varchar(255) NOT NULL,
  [nombre] varchar(255) NOT NULL,
  [telefono] varchar(25) NOT NULL,
  [direccion] varchar(255) NOT NULL,
  [estado] char(1) NOT NULL,
  CONSTRAINT [_copy_15] PRIMARY KEY CLUSTERED ([idempresa])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [existencias] (
  [idexistencia] int  IDENTITY(1,1) NOT NULL,
  [articuloId] int NOT NULL,
  [cantidad] int NOT NULL,
  [bodegaId] int NOT NULL,
  CONSTRAINT [_copy_5] PRIMARY KEY CLUSTERED ([idexistencia])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [movimientos] (
  [idmovimiento] int  IDENTITY(1,1) NOT NULL,
  [descripcion] varchar(255) NOT NULL,
  [articuloId] int NOT NULL,
  [tipoMovimiento] char(1) NOT NULL,
  [cantidad] int NOT NULL,
  [fecha] datetime2(0) NOT NULL,
  CONSTRAINT [_copy_4] PRIMARY KEY CLUSTERED ([idmovimiento])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [notaCredito] (
  [idnotaCredito] int  IDENTITY(1,1) NOT NULL,
  [descripcion] varchar(255) NOT NULL,
  [fecha] datetime2(0) NOT NULL,
  [ventaId] int NOT NULL,
  [estado] char(1) NOT NULL,
  [precio] float(10) NOT NULL,
  CONSTRAINT [_copy_1] PRIMARY KEY CLUSTERED ([idnotaCredito])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [notaDebito] (
  [idNotaDebito] int  IDENTITY(1,1) NOT NULL,
  [descripcion] varchar(255) NOT NULL,
  [precio] float(10) NOT NULL,
  [notaCreditoId] int NOT NULL,
  [fecha] datetime2(0) NOT NULL,
  CONSTRAINT [_copy_3] PRIMARY KEY CLUSTERED ([idNotaDebito])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [proveedor] (
  [idproveedor] int  IDENTITY(1,1) NOT NULL,
  [nit] varchar(255) NOT NULL,
  [nombre] varchar(255) NOT NULL,
  [direccion] varchar(255) NOT NULL,
  [telefono] varchar(25) NULL,
  [estado] char(1) NOT NULL,
  CONSTRAINT [_copy_11] PRIMARY KEY CLUSTERED ([idproveedor])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [sucursal] (
  [idsucursal] int  IDENTITY(1,1) NOT NULL,
  [nombre] varchar(255) NOT NULL,
  [direccion] varchar(255) NOT NULL,
  [telefono] varchar(25) NOT NULL,
  [empresaId] int NOT NULL,
  [estado] char(1) NOT NULL,
  CONSTRAINT [_copy_13] PRIMARY KEY CLUSTERED ([idsucursal])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [table_1] (

)
GO

CREATE TABLE [tipoArticulo] (
  [idtipoArticulo] int IDENTITY(1,1) NOT NULL,
  [descripcion] varchar(255) NOT NULL,
  [estado] char(1) NOT NULL,
  CONSTRAINT [_copy_14] PRIMARY KEY CLUSTERED ([idtipoArticulo])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [usuario] (
  [user] varchar(255) NOT NULL,
  [password] varchar(255) NOT NULL,
  [nombre] varchar(255) NOT NULL,
  [tipoUsuario] char(1) NOT NULL,
  [empresaIdempresa] int NOT NULL,
  [sucursaldsucursal] int NOT NULL,
  PRIMARY KEY CLUSTERED ([user])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

CREATE TABLE [venta] (
  [idventa] int IDENTITY(1,1) NOT NULL,
  [fecha] datetime2(0) NOT NULL,
  [user] varchar(255) NOT NULL,
  [sucursalId] int NOT NULL,
  [clienteId] int NOT NULL,
  [tipoVenta] char(2) NOT NULL,
  CONSTRAINT [_copy_10] PRIMARY KEY CLUSTERED ([idventa])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

ALTER TABLE [articulo] ADD CONSTRAINT [fk_articulo_tipoArticulo_1] FOREIGN KEY ([tipoIdtipoArticulo]) REFERENCES [tipoArticulo] ([idtipoArticulo])
GO
ALTER TABLE [articulo] ADD CONSTRAINT [fk_articulo_proveedor_1] FOREIGN KEY ([proveedorIdproveedor]) REFERENCES [proveedor] ([idproveedor])
GO
ALTER TABLE [compra] ADD CONSTRAINT [fk_compra_usuario_1] FOREIGN KEY ([user]) REFERENCES [usuario] ([user])
GO
ALTER TABLE [compra] ADD CONSTRAINT [fk_compra_bodegas_1] FOREIGN KEY ([bodegaId]) REFERENCES [bodegas] ([idbodega])
GO
ALTER TABLE [compra] ADD CONSTRAINT [fk_compra_sucursal_1] FOREIGN KEY ([sucursalId]) REFERENCES [sucursal] ([idsucursal])
GO
ALTER TABLE [detalleCompra] ADD CONSTRAINT [fk_detalleCompra_articulo_1] FOREIGN KEY ([articuloId]) REFERENCES [articulo] ([idarticulo])
GO
ALTER TABLE [detalleCompra] ADD CONSTRAINT [fk_detalleCompra_compra_1] FOREIGN KEY ([compraId]) REFERENCES [compra] ([idcompra])
GO
ALTER TABLE [detalleVenta] ADD CONSTRAINT [fk_detalleVenta_venta_1] FOREIGN KEY ([ventaId]) REFERENCES [venta] ([idventa])
GO
ALTER TABLE [detalleVenta] ADD CONSTRAINT [fk_detalleVenta_articulo_1] FOREIGN KEY ([articuloId]) REFERENCES [articulo] ([idarticulo])
GO
ALTER TABLE [existencias] ADD CONSTRAINT [fk_existencias_articulo_1] FOREIGN KEY ([articuloId]) REFERENCES [articulo] ([idarticulo])
GO
ALTER TABLE [existencias] ADD CONSTRAINT [fk_existencias_bodegas_1] FOREIGN KEY ([bodegaId]) REFERENCES [bodegas] ([idbodega])
GO
ALTER TABLE [movimientos] ADD CONSTRAINT [fk_movimientos_articulo_1] FOREIGN KEY ([articuloId]) REFERENCES [articulo] ([idarticulo])
GO
ALTER TABLE [notaCredito] ADD CONSTRAINT [fk_notaCredito_venta_1] FOREIGN KEY ([ventaId]) REFERENCES [venta] ([idventa])
GO
ALTER TABLE [notaDebito] ADD CONSTRAINT [fk_notaDebito_notaCredito_1] FOREIGN KEY ([notaCreditoId]) REFERENCES [notaCredito] ([idnotaCredito])
GO
ALTER TABLE [sucursal] ADD CONSTRAINT [fk_sucursal_empresa_1] FOREIGN KEY ([empresaId]) REFERENCES [empresa] ([idempresa])
GO
ALTER TABLE [usuario] ADD CONSTRAINT [fk_usuario_empresa_1] FOREIGN KEY ([empresaIdempresa]) REFERENCES [empresa] ([idempresa])
GO
ALTER TABLE [venta] ADD CONSTRAINT [fk_venta_sucursal_1] FOREIGN KEY ([sucursalId]) REFERENCES [sucursal] ([idsucursal])
GO
ALTER TABLE [venta] ADD CONSTRAINT [fk_venta_cliente_1] FOREIGN KEY ([clienteId]) REFERENCES [cliente] ([idcliente])
GO

