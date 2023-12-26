using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Resultado
    {
        public int IdResultado { get; set; }
        public ML.Partido Partido { get; set; }
        public ML.Marcador Marcador { get; set; }
        public int GolesEquipo1 { get; set; }
        public int GolesEquipo2 { get; set; }
        public string DuracionPartido { get; set; }
    }
}
