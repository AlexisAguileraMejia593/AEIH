using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Marcador
    {
        public Marcador()
        {
            Resultados = new HashSet<Resultado>();
        }

        public int IdStatus { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<Resultado> Resultados { get; set; }
    }
}
