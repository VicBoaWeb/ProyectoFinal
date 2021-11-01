using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.DtosModels
{
    public class DtoUsuario
    {
        [Required(ErrorMessage ="El usuario es requerido")]
        public string User { get; set; }

        [Required(ErrorMessage = "El password es requerido")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        public string TipoUsuario { get; set; }

        [Required(ErrorMessage = "El id de la empresa a que pertenece el usuario es requerido")]
        public int EmpresaIdempresa { get; set; }

        [Required(ErrorMessage = "El id de la sucursal es requerido")]
        public int Sucursaldsucursal { get; set; }
    }
}
