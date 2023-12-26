using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Liga
    {
        public int IdLiga { get; set; }
        public string Nombre { get; set; }
        public string Logo { get; set; }
        public ML.Pais Pais { get; set; }
    }
}
