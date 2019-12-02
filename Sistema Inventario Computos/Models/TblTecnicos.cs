using System;
using System.Collections.Generic;

namespace Sistema_Inventario_Computos.Models
{
    public partial class TblTecnicos
    {
        public TblTecnicos()
        {
            TblServicioTecnicos = new HashSet<TblServicioTecnicos>();
        }

        public int IdTecnico { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<TblServicioTecnicos> TblServicioTecnicos { get; set; }
    }
}
