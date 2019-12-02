using System;
using System.Collections.Generic;

namespace Sistema_Inventario_Computos.Models
{
    public partial class TblPedidos
    {
        public int IdPedido { get; set; }
        public int? IdReemplazo { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime? FechaRecibido { get; set; }
        public DateTime? FechaDevuelto { get; set; }

        public virtual TblReemplazos IdReemplazoNavigation { get; set; }
    }
}
