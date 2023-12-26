using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Estadio
    {
        public int IdEstadio { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public ML.Pais Pais { get; set; }
    }
}
