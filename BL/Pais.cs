using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static List<ML.Pais> GetAll()
        {
            List<ML.Pais> paises = new List<ML.Pais>();
            try
            {
                using(DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = context.Pais.FromSqlRaw("PaisGetAll").ToList();
                    if(query != null)
                    {
                        foreach(var item in query)
                        {
                            ML.Pais pais = new ML.Pais();
                            pais.IdPais = item.IdPais;
                            pais.Nombre = item.Nombre;
                            paises.Add(pais);
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return paises;
        }
    }
}
