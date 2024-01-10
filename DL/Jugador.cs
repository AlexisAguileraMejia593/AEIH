﻿using System;
using System.Collections.Generic;

namespace DL
{
    public partial class Jugador
    {
        public Jugador()
        {
            IdEquipos = new HashSet<Equipo>();
        }

        public int IdJugador { get; set; }
        public string Nombre { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string? ApellidoMaterno { get; set; }
        public string Foto { get; set; } = null!;
        public int Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdPosicion { get; set; }

        public virtual Posicion IdPosicionNavigation { get; set; } = null!;
        public virtual Pai NacionalidadNavigation { get; set; } = null!;

        public virtual ICollection<Equipo> IdEquipos { get; set; }

        //Propiedades para consulta de GetAll// NO BORRAR
        public int IdPais { get; set; }
        public string NombrePais { get; set; }
        public string NombrePosicion { get; set; }

        // Equipo
        public int? IdEquipo { get; set; }
        public string? NombreEquipo { get; set; }
        public string? Logo { get; set; }
    }
}
