using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class Articulo
    {
        public Articulo()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
            DetalleVenta = new HashSet<DetalleVentum>();
            Existencia = new HashSet<Existencia>();
            Movimientos = new HashSet<Movimiento>();
        }

        public int Idarticulo { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int TipoIdtipoArticulo { get; set; }
        public float Costo { get; set; }
        public float Precio { get; set; }
        public int ProveedorIdproveedor { get; set; }

        public virtual Proveedor ProveedorIdproveedorNavigation { get; set; }
        public virtual TipoArticulo TipoIdtipoArticuloNavigation { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
        public virtual ICollection<Existencia> Existencia { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
