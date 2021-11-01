using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.DtosModels
{
    public class DtoSucursal
    {
        public int Idsucursal { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        [Required(ErrorMessage ="El id de la empresa a la que pertenece es requerido")]
        public int EmpresaId { get; set; }
        public string Estado { get; set; }
    }
}
