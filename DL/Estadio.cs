using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Estadio
    {
        public Estadio()
        {
            Equipos = new HashSet<Equipo>();
            Partidos = new HashSet<Partido>();
        }

        public int IdEstadio { get; set; }
        public string Nombre { get; set; } = null!;
        public string Foto { get; set; } = null!;
        public int IdPais { get; set; }

        public virtual Pai IdPaisNavigation { get; set; } = null!;
        public virtual ICollection<Equipo> Equipos { get; set; }
        public virtual ICollection<Partido> Partidos { get; set; }
    }
}
