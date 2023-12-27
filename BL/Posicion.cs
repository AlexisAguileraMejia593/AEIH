using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Posicion
    {
        public static List<ML.Posicion> GetAll()
        {
            List<ML.Posicion> posiciones = new List<ML.Posicion>();
            try
            {
                using(DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = context.Posicions.FromSqlRaw("PosicionGetAll").ToList();
                    if( query != null)
                    {
                        foreach( var item in query )
                        {
                            ML.Posicion posicion = new ML.Posicion();
                            posicion.IdPosicion = item.IdPosicion;
                            posicion.Nombre = item.Nombre;
                            posiciones.Add(posicion);
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return posiciones;
        }
    }
}
