using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class DetalleCompra
    {
        public int IddetalleCompra { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public int CompraId { get; set; }

        public virtual Articulo Articulo { get; set; }
        public virtual Compra Compra { get; set; }
    }
}
