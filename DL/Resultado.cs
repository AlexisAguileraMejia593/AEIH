using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Resultado
    {
        public int IdResultado { get; set; }
        public int IdPartido { get; set; }
        public int IdMarcador { get; set; }
        public int GolesEquipoLocal { get; set; }
        public int GolesEquipoVisitante { get; set; }
        public string DuracionPartido { get; set; } = null!;

        public virtual Marcador IdMarcadorNavigation { get; set; } = null!;
        public virtual Partido IdPartidoNavigation { get; set; } = null!;
    }
}
