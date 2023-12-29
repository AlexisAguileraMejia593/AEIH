using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Equipo
    {
        public static bool Add(ML.Equipo equipo)
        {
            using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
            {
                var rowAffected = context.Database.ExecuteSqlRaw($"EquipoAdd '{equipo.Nombre}', '{equipo.Logo}', '{equipo.Pais.IdPais}', '{equipo.Estadio.IdEstadio}'");
                if (rowAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static List<object> GetAll()
        {
            List<object> list = new List<object>();
            bool result = false;
            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = (from Equipo in context.Equipos
                                 join pais in context.Pais on Equipo.IdPais equals pais.IdPais
                                 join estadio in context.Estadios on Equipo.IdEstadio equals estadio.IdEstadio

                                 select new
                                 {
                                     IdEquipo = Equipo.IdEquipo,
                                     NombreEquipo = Equipo.Nombre,
                                     Logo = Equipo.Logo,
                                     IdPais = pais.IdPais,
                                     NombrePais = pais.Nombre,
                                     IdEstadio = estadio.IdEstadio,
                                     NombreEstadio = estadio.Nombre,
                                     Foto = estadio.Foto,
                                     IdPais2 = estadio.IdPais,
                                     NombrePais2 = estadio.IdPaisNavigation.Nombre
                                 });
                    if (query != null)
                    {
                        foreach (var registro in query)
                        {
                            ML.Equipo equipo = new ML.Equipo();
                            equipo.IdEquipo = registro.IdEquipo;
                            equipo.Nombre = registro.NombreEquipo;
                            equipo.Logo = registro.Logo;
                            equipo.Pais = new ML.Pais();
                            equipo.Pais.IdPais = registro.IdPais;
                            equipo.Pais.Nombre = registro.NombrePais;
                            equipo.Estadio = new ML.Estadio();
                            equipo.Estadio.IdEstadio = registro.IdEstadio;
                            equipo.Estadio.Nombre = registro.NombreEstadio;
                            equipo.Estadio.Foto = registro.Foto;
                            equipo.Estadio.Pais = new ML.Pais();
                            equipo.Estadio.Pais.IdPais = registro.IdPais2;
                            equipo.Estadio.Pais.Nombre = registro.NombrePais2;
                            list.Add(equipo);
                        }
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            return list;
        }
        public static object GetById(int IdEquipo)
        {
            object equipos = null;
            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var registro = (from Equipo in context.Equipos
                                    join pais in context.Pais on Equipo.IdPais equals pais.IdPais
                                    join estadio in context.Estadios on Equipo.IdEstadio equals estadio.IdEstadio
                                    where Equipo.IdEquipo == IdEquipo
                                    select new
                                    {
                                        IdEquipo = Equipo.IdEquipo,
                                        NombreEquipo = Equipo.Nombre,
                                        Logo = Equipo.Logo,
                                        IdPais = pais.IdPais,
                                        NombrePais = pais.Nombre,
                                        IdEstadio = estadio.IdEstadio,
                                        NombreEstadio = estadio.Nombre,
                                        Foto = estadio.Foto,
                                        IdPais2 = estadio.IdPais,
                                        NombrePais2 = estadio.IdPaisNavigation.Nombre
                                    }).FirstOrDefault();
                    if (registro != null)
                    {
                        ML.Equipo equipo = new ML.Equipo();
                        equipo.IdEquipo = registro.IdEquipo;
                        equipo.Nombre = registro.NombreEquipo;
                        equipo.Logo = registro.Logo;
                        equipo.Pais = new ML.Pais();
                        equipo.Pais.IdPais = registro.IdPais;
                        equipo.Pais.Nombre = registro.NombrePais;
                        equipo.Estadio = new ML.Estadio();
                        equipo.Estadio.IdEstadio = registro.IdEstadio;
                        equipo.Estadio.Nombre = registro.NombreEstadio;
                        equipo.Estadio.Foto = registro.Foto;
                        equipo.Estadio.Pais = new ML.Pais();
                        equipo.Estadio.Pais.IdPais = registro.IdPais2;
                        equipo.Estadio.Pais.Nombre = registro.NombrePais2;
                        return equipo;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return equipos;
        }
        public static bool Update(ML.Equipo equipo)
        {
            using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
            {
                var rowAffected = context.Database.ExecuteSqlRaw($"EquipoUpdate {equipo.IdEquipo},'{equipo.Nombre}' ,'{equipo.Logo}', '{equipo.Pais.IdPais}', '{equipo.Estadio.IdEstadio}'");
                if (rowAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool Delete(int IdEquipo)
        {
            using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
            {
                var rowAffected = context.Database.ExecuteSqlRaw($"EquipoDelete '{IdEquipo}'");
                if (rowAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}