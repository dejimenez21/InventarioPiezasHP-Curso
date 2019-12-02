using System;
using System.Collections.Generic;

namespace Sistema_Inventario_Computos.Models
{
    public partial class TblPiezas
    {
        public TblPiezas()
        {
            TblReemplazosIdPiezaDañadaNavigation = new HashSet<TblReemplazos>();
            TblReemplazosIdPiezaEmpleadaNavigation = new HashSet<TblReemplazos>();
        }

        public int IdPieza { get; set; }
        public int IdTipoPieza { get; set; }
        public string Ct { get; set; }
        public string MacAddress { get; set; }
        public int? IdEstatus { get; set; }

        public virtual TblEstatus IdEstatusNavigation { get; set; }
        public virtual TblTipoPieza IdTipoPiezaNavigation { get; set; }
        public virtual ICollection<TblReemplazos> TblReemplazosIdPiezaDañadaNavigation { get; set; }
        public virtual ICollection<TblReemplazos> TblReemplazosIdPiezaEmpleadaNavigation { get; set; }
    }
}
