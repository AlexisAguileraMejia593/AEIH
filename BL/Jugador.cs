using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Jugador
    {
        public static List<object> GetAll()
        {
            List<object> jugadores = new List<object>();
            try
            {
                using(DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = context.Jugadors.FromSqlRaw("JugadorGetAll").ToList();
                    if(query != null)
                    {
                        foreach(var item in query)
                        {
                            ML.Jugador jugador = new ML.Jugador();
                            jugador.Nacionalidad = new ML.Pais();
                            jugador.Posicion = new ML.Posicion();

                            jugador.IdJugador = item.IdJugador;
                            jugador.Nombre = item.Nombre;
                            jugador.ApellidoPaterno = item.ApellidoPaterno;
                            jugador.ApellidoMaterno = item.ApellidoMaterno;
                            jugador.Foto = item.Foto;
                            jugador.FechaNacimiento = item.FechaNacimiento;
                            jugador.Nacionalidad.IdPais = item.IdPais;
                            jugador.Nacionalidad.Nombre = item.NombrePais;
                            jugador.Posicion.IdPosicion = item.IdPosicion;
                            jugador.Posicion.Nombre = item.NombrePosicion;

                            jugadores.Add(jugador);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return jugadores;
        }
    }
}