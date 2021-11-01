using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.DtosModels
{
    public class DtoArticulo
    {
        public int Idarticulo { get; set; }

        [Required(ErrorMessage ="El codigo es requerido ")] 
        public string Codigo { get; set; }

        [Required(ErrorMessage ="La descripcion del articulo el requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage ="El id del tipo de articulo al que pertenece es requerido ")]
        public int TipoIdtipoArticulo { get; set; }

        [Required(ErrorMessage = "El costo es requerido ")]
        public float Costo { get; set; }

        [Required(ErrorMessage = "El precio es requerido  ")]
        public float Precio { get; set; }

        [Required(ErrorMessage = "El id del proveedor es requerido  ")]
        public int ProveedorIdproveedor { get; set; }
    }
}
