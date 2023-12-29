using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EstadisticaEquipo
    {
        public static List<object> GetById(int idEquipo)
        {
            List<object> Estadisticas = new List<object>();
            bool Correct = false;
            try
            {
                using(DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = (from estadistica in context.EstadisticaEquipos
                                 where estadistica.IdEquipo == idEquipo
                                 select new
                                 {
                                     IdEquipo = estadistica.IdEquipo,
                                     PartidosJugados= estadistica.PartidosJugados,
                                     PartidosGanados = estadistica.PartidosGanados,
                                     PartidosPerdidos= estadistica.PartidosPerdidos,
                                     GolesAnotados = estadistica.GolesAnotados,
                                     Puntos = estadistica.Puntos
                                 });
                    if(query != null )
                    {
                        foreach( var item in query )
                        {
                            ML.EstadisticaEquipo estadisticas = new ML.EstadisticaEquipo();
                            estadisticas.Equipo = new ML.Equipo();
                            estadisticas.Equipo.IdEquipo = item.IdEquipo;
                            estadisticas.PartidosJugados = (int)item.PartidosJugados;
                            estadisticas.PartidosGanados = (int)item.PartidosGanados;
                            estadisticas.PartidosPerdidos = (int)item.PartidosPerdidos;
                            estadisticas.GolesAnotados = (int)item.GolesAnotados;
                            estadisticas.Puntos = (int)item.Puntos;

                            Estadisticas.Add(estadisticas);

                        }
                        Correct = true;
                    }
                    else
                    {
                        Correct = false;
                    }
                }

            }catch (Exception)
            {
                Correct = false;
            }
            return Estadisticas;
        }
        public static bool Update(ML.EstadisticaEquipo estadistica)
        {
            bool correct = false;
            try
            {
                using(DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UpdateEstadisticasDeportivas {estadistica.Equipo.IdEquipo}, {estadistica.PartidosJugados}, {estadistica.PartidosGanados}, {estadistica.PartidosPerdidos}, {estadistica.GolesAnotados}, {estadistica.Puntos}");
                    if (query > 0)
                    {
                        correct = true;
                    }
                    else
                    {
                        correct = false;
                    }
                }

            }catch(Exception)
            {
                correct = false;
            }
            return correct;
        }
    }
}
