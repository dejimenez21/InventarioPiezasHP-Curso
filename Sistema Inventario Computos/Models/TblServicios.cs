using System;
using System.Collections.Generic;

namespace Sistema_Inventario_Computos.Models
{
    public partial class TblServicios
    {
        public TblServicios()
        {
            TblServicioTecnicos = new HashSet<TblServicioTecnicos>();
        }

        public int IdServicio { get; set; }
        public int? NoTicket { get; set; }
        public string Comentario { get; set; }
        public int? IdDepartamento { get; set; }
        public DateTime Fecha { get; set; }

        public virtual TblDepartamentos IdDepartamentoNavigation { get; set; }
        public virtual ICollection<TblServicioTecnicos> TblServicioTecnicos { get; set; }
    }
}
