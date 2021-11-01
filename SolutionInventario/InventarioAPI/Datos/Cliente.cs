using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Ventum>();
        }

        public int Idcliente { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
