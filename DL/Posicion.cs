using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Posicion
    {
        public Posicion()
        {
            Jugadors = new HashSet<Jugador>();
        }

        public int IdPosicion { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Jugador> Jugadors { get; set; }
    }
}
