using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class TipoArticulo
    {
        public TipoArticulo()
        {
            Articulos = new HashSet<Articulo>();
        }

        public int IdtipoArticulo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
