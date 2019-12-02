using System;
using System.Collections.Generic;

namespace Sistema_Inventario_Computos.Models
{
    public partial class TblReemplazos
    {
        public TblReemplazos()
        {
            TblPedidos = new HashSet<TblPedidos>();
        }

        public int IdReemplazo { get; set; }
        public int IdServicioTecnico { get; set; }
        public int IdPiezaEmpleada { get; set; }
        public int IdPiezaDañada { get; set; }

        public virtual TblPiezas IdPiezaDañadaNavigation { get; set; }
        public virtual TblPiezas IdPiezaEmpleadaNavigation { get; set; }
        public virtual TblServicioTecnicos IdServicioTecnicoNavigation { get; set; }
        public virtual ICollection<TblPedidos> TblPedidos { get; set; }
    }
}
