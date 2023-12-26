using System;
using System.Collections.Generic;

namespace DL
{
    public partial class EstadisticaEquipo
    {
        public int IdEquipo { get; set; }
        public int? PartidosJugados { get; set; }
        public int? PartidosGanados { get; set; }
        public int? PartidosPerdidos { get; set; }
        public int? GolesAnotados { get; set; }
        public int? Puntos { get; set; }

        public virtual Equipo IdEquipoNavigation { get; set; } = null!;
    }
}
