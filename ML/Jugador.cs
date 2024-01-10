using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Jugador
    {
        public int IdJugador { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Foto { get; set; }
        public ML.Pais? Nacionalidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public ML.Posicion? Posicion { get; set; }
        public ML.Equipo? Equipo { get; set; }
    }
}
