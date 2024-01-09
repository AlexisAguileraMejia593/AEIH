using DL;
using Microsoft.EntityFrameworkCore;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estadio
    {
        public static List<object> GetAll()
        {
            List<object> estadios = new List<object>();
            bool correct = false;
            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = (from estadio in context.Estadios
                                 join pais in context.Pais on estadio.IdPais equals  pais.IdPais
                                 select new
                                 {
                                     IdEstadio = estadio.IdEstadio,
                                     Nombre = estadio.Nombre,
                                     Foto = estadio.Foto,
                                     IdPais = estadio.IdPais,
                                     NombrePais = pais.Nombre
                                 });

                    if(query != null )
                    {
                        foreach ( var item in query )
                        {
                            ML.Estadio estadio = new ML.Estadio();
                            estadio.Pais = new ML.Pais();
                            estadio.IdEstadio = item.IdEstadio;
                            estadio.Nombre = item.Nombre;
                            estadio.Foto = item.Foto;
                            estadio.Pais.IdPais = item.IdPais;
                            estadio.Pais.Nombre = item.NombrePais;
                            estadios.Add( estadio );
                            
                        }
                        correct = true;
                    }
                    else
                    {
                        correct = false;
                    }
                }
                
            }catch (Exception e)
            {
                correct = false;
            }
            return estadios;
        }
    }
}
