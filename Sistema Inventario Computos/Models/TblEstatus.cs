using System;
using System.Collections.Generic;

namespace Sistema_Inventario_Computos.Models
{
    public partial class TblEstatus
    {
        public TblEstatus()
        {
            TblPiezas = new HashSet<TblPiezas>();
        }

        public int IdEstatus { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<TblPiezas> TblPiezas { get; set; }
    }
}
