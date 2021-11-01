using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            Compras = new HashSet<Compra>();
            Venta = new HashSet<Ventum>();
        }

        public int Idsucursal { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int EmpresaId { get; set; }
        public string Estado { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
