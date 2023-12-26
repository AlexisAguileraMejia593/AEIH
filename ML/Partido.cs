using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Partido
    {
        public int IdPartido { get; set; }
        public ML.Equipo EquipoLocal { get; set; }
        public ML.Equipo EquipoVisitante { get; set; }
        public ML.Estadio Estadio { get; set; }
        public DateTime Fecha { get; set; }
    }
}
