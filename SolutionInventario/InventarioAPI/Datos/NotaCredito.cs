using System;
using System.Collections.Generic;

#nullable disable

namespace InventarioAPI.Datos
{
    public partial class NotaCredito
    {
        public NotaCredito()
        {
            NotaDebitos = new HashSet<NotaDebito>();
        }

        public int IdnotaCredito { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int VentaId { get; set; }
        public string Estado { get; set; }
        public float Precio { get; set; }

        public virtual Ventum Venta { get; set; }
        public virtual ICollection<NotaDebito> NotaDebitos { get; set; }
    }
}
