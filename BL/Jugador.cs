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
                            jugador.Equipo = new ML.Equipo();
                            jugador.Equipo.IdEquipo = (int)item.IdEquipo;
                            jugador.Equipo.Nombre = item.NombreEquipo;
                            jugador.Equipo.Logo = item.Logo;

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
        public static ML.Jugador GetById(int idJugador)
        {
            ML.Jugador jugador = new ML.Jugador();
            try
            {
                using(DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = context.Jugadors.FromSqlRaw($"JugadorGetById {idJugador}").AsEnumerable().FirstOrDefault();
                    if(query != null)
                    {
                        jugador.Nacionalidad = new ML.Pais();
                        jugador.Posicion = new ML.Posicion();

                        jugador.IdJugador = query.IdJugador;
                        jugador.Nombre = query.Nombre;
                        jugador.ApellidoPaterno = query.ApellidoPaterno;
                        jugador.ApellidoMaterno = query.ApellidoMaterno;
                        jugador.Foto = query.Foto;
                        jugador.FechaNacimiento = query.FechaNacimiento;
                        jugador.Nacionalidad.IdPais = query.IdPais;
                        jugador.Nacionalidad.Nombre = query.NombrePais;
                        jugador.Posicion.IdPosicion = query.IdPosicion;
                        jugador.Posicion.Nombre = query.NombrePosicion;
                        jugador.Equipo = new ML.Equipo();
                        jugador.Equipo.IdEquipo = (int)query.IdEquipo;
                        jugador.Equipo.Nombre = query.NombreEquipo;
                        jugador.Equipo.Logo = query.Logo;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return jugador;
        }
        public static bool Add(ML.JugadorEquipo jugador)
        {
            bool correct = false;
            try
            {
                using(DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    int rowsAffected = context.Database.ExecuteSqlRaw($"JugadorAdd '{jugador.Jugador.Nombre}','{jugador.Jugador.ApellidoPaterno}','{jugador.Jugador.ApellidoMaterno}','{jugador.Jugador.Foto}',{jugador.Jugador.Nacionalidad.IdPais},'{jugador.Jugador.FechaNacimiento}',{jugador.Jugador.Posicion.IdPosicion},{jugador.Equipo.IdEquipo}");
                    if(rowsAffected > 0)
                    {
                        correct = true;
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return correct;
        }
        public static bool Update(ML.JugadorEquipo jugador)
        {
            bool correct = false;
            try
            {
                using(DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    int rowsAffected = context.Database.ExecuteSqlRaw($"JugadorUpdate {jugador.Jugador.IdJugador},'{jugador.Jugador.Nombre}','{jugador.Jugador.ApellidoPaterno}','{jugador.Jugador.ApellidoMaterno}','{jugador.Jugador.Foto}',{jugador.Jugador.Nacionalidad.IdPais},'{jugador.Jugador.FechaNacimiento}',{jugador.Jugador.Posicion.IdPosicion},{jugador.Equipo.IdEquipo}");
                    if(rowsAffected > 0)
                    {
                        correct = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return correct;
        }
        public static bool Delete(int idJugador)
        {
            bool correct = false;
            try
            {
                using(DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    int rowsAffected = context.Database.ExecuteSqlRaw($"JugadorDelete {idJugador}");
                    if (rowsAffected > 0)
                    {
                        correct = true;
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return correct;
        }
    }
}