using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Equipo
    {
        public static void Add(string Nombre, ML.Pais pais, string Logo, ML.Estadio estadio)
        {
            using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
            {
                var rowAffected = context.Database.ExecuteSqlRaw($"EquipoAdd '{Nombre}', '{pais}', '{Logo}', '{estadio}'");
                if (rowAffected > 0)
                {
                    Console.WriteLine("Insertado");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
        public static List<object> GetAll()
        {
            List<object> list = new List<object>();
            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = context.Equipos.FromSqlRaw("EquipoGetAll").ToList();
                    if (query.Count > 0)
                    {

                        foreach (var registro in query)
                        {
                            ML.Equipo equipo = new ML.Equipo();
                            equipo.IdEquipo = registro.IdEquipo;
                            equipo.Nombre = registro.Nombre;
                            equipo.Pais = new ML.Pais();
                            equipo.Pais.IdPais = registro.IdPais;
                            equipo.Logo = registro.Logo;
                            equipo.Estadio = new ML.Estadio();
                            equipo.Estadio.IdEstadio = registro.IdEstadio;
                            list.Add(equipo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
        public static List<object> GetById(int IdEquipo)
        {
            List<object> list = new List<object>();
            try
            {
                using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
                {
                    var query = context.Equipos.FromSqlRaw($"EquipoGetById '{IdEquipo}'").AsEnumerable().SingleOrDefault();

                    if (query != null)
                    {
                        ML.Equipo equipo = new ML.Equipo();
                        equipo.IdEquipo = query.IdEquipo;
                        equipo.Nombre = query.Nombre;
                        equipo.Pais = new ML.Pais();
                        equipo.Pais.IdPais = query.IdPais;
                        equipo.Logo = query.Logo;
                        equipo.Estadio = new ML.Estadio();
                        equipo.Estadio.IdEstadio = query.IdEstadio;
                        list.Add(equipo);

                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and return an empty list
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<object>();
            }
            // Return the list of objects
            return list;
        }
        public static void Update(int IdEquipo, string Nombre, ML.Pais pais, string Logo, ML.Estadio estadio)
        {
            using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
            {
                var rowAffected = context.Database.ExecuteSqlRaw($"EquipoUpdate '{IdEquipo}', '{Nombre}' ,'{pais}', '{Logo}', '{estadio}'");
                if (rowAffected > 0)
                {
                    Console.WriteLine("Actualizado");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
        public static void Delete(int IdEquipo)
        {
            using (DL.EstadisticasDeportivasContext context = new DL.EstadisticasDeportivasContext())
            {
                var rowAffected = context.Database.ExecuteSqlRaw($"EquipoDelete '{IdEquipo}'");
                if (rowAffected > 0)
                {
                    Console.WriteLine("Eliminado");
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
    }
}