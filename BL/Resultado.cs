using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Resultado
    {
        public static List<object> GetByIdPartido(int IdPartido)
        {
            List<object> partidos = new List<object>();
            try
            {
                using(DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = (from resultado in context.Resultados
                                 join partido in context.Partidos on resultado.IdPartido equals partido.IdPartido
                                 join marcador in context.Marcadors on resultado.IdMarcador equals marcador.IdStatus
                                 where resultado.IdPartido == IdPartido
                                 select new
                                 {
                                     IdResultado = resultado.IdResultado,
                                     IdPartido = resultado.IdPartido,
                                     IdMarcador = resultado.IdMarcador,
                                     GolesEquipoLocal = resultado.GolesEquipoLocal,
                                     GolesEquipoVisitante = resultado.GolesEquipoVisitante,
                                     DuracionPartido = resultado.DuracionPartido

                                 }); 
                    if(query != null)
                    {
                        foreach(var item in query)
                        {
                            ML.Resultado resultado = new ML.Resultado();
                            resultado.Partido = new ML.Partido();
                            resultado.Marcador = new ML.Marcador();
                            resultado.IdResultado = item.IdResultado;
                            resultado.Partido.IdPartido = item.IdPartido;
                            resultado.Marcador.IdMarcador = item.IdMarcador;
                            resultado.GolesEquipo1 = item.GolesEquipoLocal;
                            resultado.GolesEquipo2 = item .GolesEquipoVisitante;
                            resultado.DuracionPartido = item.DuracionPartido;
                            partidos.Add(resultado);
                        }
                    }
                }


            }catch (Exception ex)
            {
                
            }
            return partidos;

        }
    }
}
