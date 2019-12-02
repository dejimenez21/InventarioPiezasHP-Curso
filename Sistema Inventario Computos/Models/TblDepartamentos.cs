using System;
using System.Collections.Generic;

namespace Sistema_Inventario_Computos.Models
{
    public partial class TblDepartamentos
    {
        public TblDepartamentos()
        {
            TblServicios = new HashSet<TblServicios>();
        }

        public int IdDepartamento { get; set; }
        public string Descripcion { get; set; }
        public int? IdLocalidad { get; set; }

        public virtual TblLocalidades IdLocalidadNavigation { get; set; }
        public virtual ICollection<TblServicios> TblServicios { get; set; }
    }
}
