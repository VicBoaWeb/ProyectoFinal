using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class Empresa
    {
        public Empresa()
        {
            Sucursals = new HashSet<Sucursal>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Idempresa { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Sucursal> Sucursals { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
