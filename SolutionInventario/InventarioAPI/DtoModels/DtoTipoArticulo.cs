using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.DtosModels
{
    public class DtoTipoArticulo
    {
        public int IdtipoArticulo { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
