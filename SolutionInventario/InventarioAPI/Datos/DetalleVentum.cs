using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class DetalleVentum
    {
        public int IddetalleVenta { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public float? Precio { get; set; }
        public int VentaId { get; set; }

        public virtual Articulo Articulo { get; set; }
        public virtual Ventum Venta { get; set; }
    }
}
