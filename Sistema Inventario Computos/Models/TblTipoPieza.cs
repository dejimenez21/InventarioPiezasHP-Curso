using System;
using System.Collections.Generic;

namespace Sistema_Inventario_Computos.Models
{
    public partial class TblTipoPieza
    {
        public TblTipoPieza()
        {
            TblPiezas = new HashSet<TblPiezas>();
        }

        public int IdTipoPieza { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<TblPiezas> TblPiezas { get; set; }
    }
}
