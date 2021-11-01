using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.DtosModels
{
    public class DtoProveedor
    {
        public int Idproveedor { get; set; }

        [Required(ErrorMessage ="El nit es requerido")]
        public string Nit { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Estado { get; set; }
    }
}
