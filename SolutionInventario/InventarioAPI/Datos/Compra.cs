using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class Compra
    {
        public Compra()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
        }

        public int Idcompra { get; set; }
        public int ProveedorIdproveedor { get; set; }
        public string User { get; set; }
        public DateTime Fecha { get; set; }
        public int SucursalId { get; set; }
        public int BodegaId { get; set; }

        public virtual Bodega Bodega { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        public virtual Usuario UserNavigation { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
    }
}
