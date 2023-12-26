using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Liga
    {
        public Liga()
        {
            IdEquipos = new HashSet<Equipo>();
        }

        public int IdLiga { get; set; }
        public string Nombre { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public int IdPais { get; set; }

        public virtual Pai IdPaisNavigation { get; set; } = null!;

        public virtual ICollection<Equipo> IdEquipos { get; set; }
    }
}
