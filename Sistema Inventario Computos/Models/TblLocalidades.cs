using System;
using System.Collections.Generic;

namespace Sistema_Inventario_Computos.Models
{
    public partial class TblLocalidades
    {
        public TblLocalidades()
        {
            TblDepartamentos = new HashSet<TblDepartamentos>();
        }

        public int IdLocalidad { get; set; }
        public string Descripcion { get; set; }
        public string Provincia { get; set; }

        public virtual ICollection<TblDepartamentos> TblDepartamentos { get; set; }
    }
}
