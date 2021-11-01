using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class Ventum
    {
        public Ventum()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
            NotaCreditos = new HashSet<NotaCredito>();
        }

        public int Idventa { get; set; }
        public DateTime Fecha { get; set; }
        public string User { get; set; }
        public int SucursalId { get; set; }
        public int ClienteId { get; set; }
        public string TipoVenta { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
        public virtual ICollection<NotaCredito> NotaCreditos { get; set; }
    }
}
