using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.DtoModels
{
    public class DtoCompra
    {
        public int Idcompra { get; set; }
        public int ProveedorIdproveedor { get; set; }
        public string User { get; set; }
        public DateTime Fecha { get; set; }
        public int SucursalId { get; set; }
        public int BodegaId { get; set; }
    }
}
