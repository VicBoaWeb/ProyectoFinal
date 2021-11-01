using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class NotaDebito
    {
        public int IdNotaDebito { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int NotaCreditoId { get; set; }
        public DateTime Fecha { get; set; }

        public virtual NotaCredito NotaCredito { get; set; }
    }
}
