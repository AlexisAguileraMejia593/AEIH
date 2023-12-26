using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Equipo
    {
        public Equipo()
        {
            PartidoIdEquipoLocalNavigations = new HashSet<Partido>();
            PartidoIdEquipoVisitanteNavigations = new HashSet<Partido>();
            IdJugadors = new HashSet<Jugador>();
            IdLigas = new HashSet<Liga>();
        }

        public int IdEquipo { get; set; }
        public string Nombre { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public int IdPais { get; set; }
        public int IdEstadio { get; set; }

        public virtual Estadio IdEstadioNavigation { get; set; } = null!;
        public virtual Pai IdPaisNavigation { get; set; } = null!;
        public virtual ICollection<Partido> PartidoIdEquipoLocalNavigations { get; set; }
        public virtual ICollection<Partido> PartidoIdEquipoVisitanteNavigations { get; set; }

        public virtual ICollection<Jugador> IdJugadors { get; set; }
        public virtual ICollection<Liga> IdLigas { get; set; }
    }
}
