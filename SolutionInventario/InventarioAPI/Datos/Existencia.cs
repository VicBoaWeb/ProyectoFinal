using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class Existencia
    {
        public int Idexistencia { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public int BodegaId { get; set; }

        public virtual Articulo Articulo { get; set; }
        public virtual Bodega Bodega { get; set; }
    }
}
