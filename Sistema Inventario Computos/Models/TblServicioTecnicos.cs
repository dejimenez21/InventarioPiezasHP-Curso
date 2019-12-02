using System;
using System.Collections.Generic;

namespace Sistema_Inventario_Computos.Models
{
    public partial class TblServicioTecnicos
    {
        public TblServicioTecnicos()
        {
            TblReemplazos = new HashSet<TblReemplazos>();
        }

        public int IdServicioTecnico { get; set; }
        public int? IdServicio { get; set; }
        public int? IdTecnico { get; set; }

        public virtual TblServicios IdServicioNavigation { get; set; }
        public virtual TblTecnicos IdTecnicoNavigation { get; set; }
        public virtual ICollection<TblReemplazos> TblReemplazos { get; set; }
    }
}
