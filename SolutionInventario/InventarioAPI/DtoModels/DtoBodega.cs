using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.DtosModels
{
    public class DtoBodega
    {
        public int Idbodega { get; set; }

        [Required(ErrorMessage ="La descripcion es requerida")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La descripcion es requerida")]
        public int SucursalId { get; set; }
        public string Estado { get; set; }
    }
}
