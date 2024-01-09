using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Liga
    {
        public static List<object> GetAll()
        {
            List<object> ligas = new List<object>();
            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = (from liga in context.Ligas
                                 join pais in context.Pais on liga.IdPais equals pais.IdPais
                                 select new
                                 {
                                     IdLiga = liga.IdLiga,
                                     Nombre = liga.Nombre,
                                     Logo = liga.Logo,
                                     IdPais = liga.IdPais,
                                     NombrePais = pais.Nombre
                                 });
                    if(query != null )
                    {
                        foreach ( var item in query)
                        {
                            ML.Liga li = new ML.Liga();
                            li.Pais = new ML.Pais();
                            li.IdLiga = item.IdLiga;
                            li.Nombre = item.Nombre;
                            li.Logo = item.Logo;
                            li.Pais.IdPais= item.IdPais;
                            li.Pais.Nombre = item.NombrePais;
                            ligas.Add( li );

                        }
                    }
                }

            }catch (Exception ex)
            {

            }
            return ligas;
        }
        public static List<object> GetById(int IdLiga)
        {
            List<object> ligas = new List<object>();
            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = (from liga in context.Ligas
                                 join pais in context.Pais on liga.IdPais equals pais.IdPais
                                 where liga.IdLiga == IdLiga
                                 select new
                                 {
                                     IdLiga = liga.IdLiga,
                                     Nombre = liga.Nombre,
                                     Logo = liga.Logo,
                                     IdPais = liga.IdPais,
                                     NombrePais = pais.Nombre
                                 });
                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.Liga li = new ML.Liga();
                            li.Pais = new ML.Pais();
                            li.IdLiga = item.IdLiga;
                            li.Nombre = item.Nombre;
                            li.Logo = item.Logo;
                            li.Pais.IdPais = item.IdPais;
                            li.Pais.Nombre = item.NombrePais;
                            ligas.Add(li);

                        }
                    }

                }
            }catch (Exception ex)
            {

            }
            return ligas;
        }
        public static bool Add(ML.Liga liga)
        {
            bool correct = false;
            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AddLiga '{liga.Nombre}', '{liga.Logo}', {liga.Pais.IdPais}");
                    if (query > 0)
                    {
                        correct = true;
                    }
                }

            }catch(Exception ex)
            {
                correct =false;
            }
            return correct;
        }
        public static bool Delete(int IdLiga)
        {
            bool correct = false;
            try
            {
                using(DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext()) { 
                var query = context.Database.ExecuteSqlRaw($"DeleteLiga {IdLiga}");
                if (query > 0)
                {
                    correct = true;
                }
                }

            }
            catch (Exception ex)
            {
                correct=false;
            }
            return correct;
        }
        public static bool Update(ML.Liga liga)
        {
            bool correct = false;
            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UpdateLiga {liga.IdLiga}, '{liga.Nombre}', '{liga.Logo}', {liga.Pais.IdPais}");
                    if (query > 0)
                    {
                        correct = true;
                    }
                }
            }catch( Exception ex )
            {
                correct = false;
            }
            return correct;
        }
    }
}
