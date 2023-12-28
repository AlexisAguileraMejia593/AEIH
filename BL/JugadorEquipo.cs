using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class JugadorEquipo
    {
        public static bool Add(ML.JugadorEquipo jugadorEquipo)
        {
            bool correct;

            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    int affectedRow = context.Database.ExecuteSqlRaw($"AddJugadorEquipo {jugadorEquipo.Jugador.IdJugador}, {jugadorEquipo.Equipo.IdEquipo}");

                    if (affectedRow > 0)
                    {
                        correct = true;
                    }
                    else
                    {
                        correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }

            return correct;
        }

        public static bool Delete(int idJugador)
        {
            bool correct;

            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    int affectedRow = context.Database.ExecuteSqlRaw($"DeleteJugadorEquipo {idJugador}");

                    if (affectedRow > 0)
                    {
                        correct = true;
                    }
                    else
                    {
                        correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }

            return correct;
        }

        public static ML.JugadorEquipo GetById(ML.JugadorEquipo jugadorEquipo)
        {
            ML.JugadorEquipo jugadorEquipoObject = new ML.JugadorEquipo();

            try
            {
                using (SqlConnection context = new SqlConnection("Server=.; Database= EstadisticasDeportivas; TrustServerCertificate=True; User ID=sa; Password=pass@word1;"))
                {
                    string query = "SELECT JugadorEquipo.IdJugador, Jugador.Nombre, Jugador.ApellidoPaterno, Jugador.ApellidoMaterno, Jugador.Foto, Jugador.Nacionalidad, Jugador.FechaNacimiento, " +
                        "Jugador.IdPosicion, JugadorEquipo.IdEquipo, Equipo.Nombre, Equipo.Logo, Equipo.IdPais, Equipo.IdEstadio FROM JugadorEquipo " +
                        "LEFT JOIN Jugador ON JugadorEquipo.IdJugador = Jugador.IdJugador " +
                        "LEFT JOIN Equipo ON JugadorEquipo.IdEquipo = Equipo.IdEquipo " +
                        $"WHERE JugadorEquipo.IdJugador = {jugadorEquipo.Jugador.IdJugador}";

                    SqlCommand cmd = new SqlCommand(query, context);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable tableJugadorEquipo = new DataTable();

                    adapter.Fill(tableJugadorEquipo);

                    if (tableJugadorEquipo.Rows.Count > 0)
                    {
                        //Con DataRow le decimos que queremos filas, en este caso, la primera que salga
                        // ademas de que será la unica
                        DataRow row = tableJugadorEquipo.Rows[0];

                        // Asignamos los valores que tengamos en el arreglo dentro de las variables del modelo
                        jugadorEquipo.Jugador.IdJugador = int.Parse(row[0].ToString());
                        jugadorEquipo.Jugador.Nombre = row[1].ToString();
                        jugadorEquipo.Jugador.ApellidoPaterno = row[2].ToString();
                        jugadorEquipo.Jugador.ApellidoMaterno = row[3].ToString();
                        jugadorEquipo.Jugador.Foto = row[4].ToString();
                        jugadorEquipo.Jugador.Nacionalidad = new ML.Pais();
                        jugadorEquipo.Jugador.Nacionalidad.IdPais = int.Parse(row[5].ToString());
                        jugadorEquipo.Jugador.FechaNacimiento = DateTime.Parse(row[6].ToString());
                        jugadorEquipo.Jugador.Posicion = new ML.Posicion();
                        jugadorEquipo.Jugador.Posicion.IdPosicion = int.Parse(row[7].ToString());
                        jugadorEquipo.Equipo = new ML.Equipo();
                        jugadorEquipo.Equipo.IdEquipo = int.Parse(row[8].ToString());
                        jugadorEquipo.Equipo.Nombre = row[9].ToString();
                        jugadorEquipo.Equipo.Logo = row[10].ToString();
                        jugadorEquipo.Equipo.Pais = new ML.Pais();
                        jugadorEquipo.Equipo.Pais.IdPais = int.Parse(row[11].ToString());
                        jugadorEquipo.Equipo.Estadio = new ML.Estadio();
                        jugadorEquipo.Equipo.Estadio.IdEstadio = int.Parse(row[12].ToString());

                        jugadorEquipoObject = jugadorEquipo;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }

            return jugadorEquipoObject;
        }

        public static bool Update(ML.JugadorEquipo jugadorEquipo)
        {
            bool correct;

            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    int affectedRow = context.Database.ExecuteSqlRaw($"UpdateJugadorEquipo {jugadorEquipo.Equipo.IdEquipo}, {jugadorEquipo.Jugador.IdJugador}");

                    if (affectedRow > 0)
                    {
                        correct = true;
                    }
                    else
                    {
                        correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }

            return correct;
        }
    }
}
