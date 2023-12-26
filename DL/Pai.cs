using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Pai
    {
        public Pai()
        {
            Equipos = new HashSet<Equipo>();
            Estadios = new HashSet<Estadio>();
            Jugadors = new HashSet<Jugador>();
            Ligas = new HashSet<Liga>();
        }

        public int IdPais { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Equipo> Equipos { get; set; }
        public virtual ICollection<Estadio> Estadios { get; set; }
        public virtual ICollection<Jugador> Jugadors { get; set; }
        public virtual ICollection<Liga> Ligas { get; set; }
    }
}
