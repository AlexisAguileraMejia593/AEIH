using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Partido
    {
        public Partido()
        {
            Resultados = new HashSet<Resultado>();
        }

        public int IdPartido { get; set; }
        public int IdEquipoLocal { get; set; }
        public int IdEquipoVisitante { get; set; }
        public int IdEstadio { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Equipo IdEquipoLocalNavigation { get; set; } = null!;
        public virtual Equipo IdEquipoVisitanteNavigation { get; set; } = null!;
        public virtual Estadio IdEstadioNavigation { get; set; } = null!;
        public virtual ICollection<Resultado> Resultados { get; set; }
    }
}
