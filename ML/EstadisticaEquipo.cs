using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class EstadisticaEquipo
    {
        public ML.Equipo? Equipo { get; set; }
        public int PartidosJugados { get; set; }
        public int PartidosGanados { get; set; }
        public int PartidosPerdidos { get; set; }
        public int GolesAnotados { get; set; }
        public int Puntos { get; set; }
    }
}
