using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Partido
    {
        public static List<object> GetAll()
        {
            List<object> list = new List<object>();

            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var SP = (from objPartido in context.Partidos
                              join objEquipoLocal in context.Equipos on objPartido.IdEquipoLocal equals objEquipoLocal.IdEquipo
                              join objEquipoVisitante in context.Equipos on objPartido.IdEquipoVisitante equals objEquipoVisitante.IdEquipo
                              select new
                              {
                                  // IdPartido
                                  IdPartido = objPartido.IdPartido,
                                  // Equipo local
                                  IdEquipoLocal = objEquipoLocal.IdEquipo,
                                  NombreEquipoLocal = objEquipoLocal.Nombre,
                                  LogoEquipoLocal = objEquipoLocal.Logo,
                                  IdPaisEquipoLocal = objEquipoLocal.IdPais,
                                  IdEstadioEquipoLocal = objEquipoLocal.IdEstadio,
                                  // Equipo visitante
                                  IdEquipoVisitante = objEquipoVisitante.IdPais,
                                  NombreEquipoVisitante = objEquipoVisitante.Nombre,
                                  LogoEquipoVisitante = objEquipoVisitante.Logo,
                                  IdPaisEquipoVisitante = objEquipoVisitante.IdPais,
                                  IdEstadioEquipoVisitante = objEquipoVisitante.IdEstadio,
                                  // Estadio
                                  IdEstadio = objPartido.IdEstadio,
                                  Fecha = objPartido.Fecha
                              }).ToList();

                    if (SP != null)
                    {
                        foreach (var itemPartido in SP)
                        {
                            ML.Partido partido = new ML.Partido();

                            // Partido
                            partido.IdPartido = itemPartido.IdPartido;
                            // Equipo local
                            partido.EquipoLocal = new ML.Equipo();
                            partido.EquipoLocal.IdEquipo = itemPartido.IdEquipoLocal;
                            partido.EquipoLocal.Nombre = itemPartido.NombreEquipoLocal;
                            partido.EquipoLocal.Logo = itemPartido.LogoEquipoLocal;
                            partido.EquipoLocal.Pais = new ML.Pais();
                            partido.EquipoLocal.Pais.IdPais = itemPartido.IdPaisEquipoLocal;
                            partido.EquipoLocal.Estadio = new ML.Estadio();
                            partido.EquipoLocal.Estadio.IdEstadio = itemPartido.IdEstadioEquipoLocal;
                            // Equipo visitante
                            partido.EquipoVisitante = new ML.Equipo();
                            partido.EquipoVisitante.IdEquipo = itemPartido.IdEquipoVisitante;
                            partido.EquipoVisitante.Nombre = itemPartido.NombreEquipoVisitante;
                            partido.EquipoVisitante.Logo = itemPartido.LogoEquipoVisitante;
                            partido.EquipoVisitante.Pais = new ML.Pais();
                            partido.EquipoVisitante.Pais.IdPais = itemPartido.IdPaisEquipoVisitante;
                            partido.EquipoVisitante.Estadio = new ML.Estadio(); 
                            partido.EquipoVisitante.Estadio.IdEstadio = itemPartido.IdEstadioEquipoVisitante;
                            // Partido
                            partido.Estadio = new ML.Estadio();
                            partido.Estadio.IdEstadio = itemPartido.IdEstadio;
                            partido.Fecha = itemPartido.Fecha;

                            list.Add(partido);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }

            return list;
        }

        public static bool Add(ML.Partido partido)
        {
            bool correct;

            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    int affectedRow = context.Database.ExecuteSqlRaw($"AddPartido {partido.EquipoLocal.IdEquipo}, {partido.EquipoVisitante.IdEquipo}, {partido.Estadio.IdEstadio}, '{partido.Fecha}'");

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

        public static bool Delete(int idPartido)
        {
            bool correct;

            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    int affectedRow = context.Database.ExecuteSqlRaw($"DeletePartido {idPartido}");

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
