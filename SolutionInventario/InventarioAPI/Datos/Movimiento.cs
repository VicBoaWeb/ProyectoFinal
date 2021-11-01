using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class Movimiento
    {
        public int Idmovimiento { get; set; }
        public string Descripcion { get; set; }
        public int ArticuloId { get; set; }
        public string TipoMovimiento { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Articulo Articulo { get; set; }
    }
}
