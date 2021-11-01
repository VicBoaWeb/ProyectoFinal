using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class Usuario
    {
        public Usuario()
        {
            Compras = new HashSet<Compra>();
        }

        public string User { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string TipoUsuario { get; set; }
        public int EmpresaIdempresa { get; set; }
        public int Sucursaldsucursal { get; set; }

        public virtual Empresa EmpresaIdempresaNavigation { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
