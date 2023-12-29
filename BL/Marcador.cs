using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Marcador
    {
        public static List<object> GetAll()
        {
            List<object> marcadores = new List<object>();
            bool correct = false;
            try
            {
                using(DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = (from marcador in context.Marcadors
                                 select new
                                 {
                                     IdStatus = marcador.IdStatus,
                                     Status = marcador.Status
                                 });
                    if(query != null )
                    {
                        foreach( var item in query )
                        {
                            ML.Marcador marcador = new ML.Marcador();
                            marcador.IdMarcador = item.IdStatus;
                            marcador.Status = item.Status;
                            marcadores.Add( marcador );
                        }
                        correct = true;
                    }
                }

            }catch (Exception ex)
            {
                correct = false;
            }
            return marcadores;
        }
    }
}
