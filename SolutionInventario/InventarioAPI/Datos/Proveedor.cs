using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Articulos = new HashSet<Articulo>();
        }

        public int Idproveedor { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
