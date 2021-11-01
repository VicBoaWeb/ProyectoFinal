using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class Bodega
    {
        public Bodega()
        {
            Compras = new HashSet<Compra>();
            Existencia = new HashSet<Existencia>();
        }

        public int Idbodega { get; set; }
        public string Descripcion { get; set; }
        public int SucursalId { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<Existencia> Existencia { get; set; }
    }
}
