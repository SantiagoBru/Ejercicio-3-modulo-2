using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace EjercicioClase3Modulo2EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Pasos previos
            //Ejecutar el script de base de datos en Management Studio para crear la base de datos y la tabla con datos
            //Instalar Microsoft.EntityFrameworkCore y Microsoft.EntityFrameworkCore.SqlServer
            //Crear las entidades necesarias
            //Crear el dbcontext
            //Configurar aqui el connection string e instanciar el contexto de la base de datos.
            #endregion

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();


                #region ejercicio 1
                //Obtener un listado de todos los actores y actrices de la tabla actor
                var actores = GetAllActores(context);

                static List<Actor> GetAllActores(AppDbContext context)
                {
                    return context.Actores.ToList();
                }

                #endregion

                #region ejercicio 2
                //Obtener listado de todas las actrices de la tabla actor
                var actrices = GetAllActrices(context);

                static List<Actor> GetAllActrices(AppDbContext context)
                {
                    return context.Actores.Where(a => a.Genero == "Femenino").ToList();
                }

                #endregion

                #region ejercicio 3
                //Obtener un listado de todos los actores y actrices mayores de 50 años de la tabla actor
                var actoresMayoresDe50 = GetAllActoresMayoresDe50(context);

                static List<Actor> GetAllActoresMayoresDe50(AppDbContext context)
                {
                    return context.Actores.Where(a => a.Edad > 50).ToList();
                }

                #endregion

                #region ejercicio 4
                //Obtener la edad de la actriz "Julia Roberts"
                var edadJuliaRoberts = GetEdadDeActriz(context, "Julia", "Roberts");
                static int GetEdadDeActriz(AppDbContext context, string nombre, string apellido)
                {
                    var actriz = context.Actores.FirstOrDefault(a => a.Nombre == nombre && a.Apellido == apellido);
                    if (actriz != null)
                    {
                        return actriz.Edad;
                    }
                    return -1; // O devuelve un valor que indique que no se encontró la actriz
                }

                #endregion

                #region ejercicio 5
                //Insertar un nuevo actor en la tabla actor con los siguientes datos:
                //nombre: Ricardo
                //apellido: Darin
                //edad: 67 años
                //nombre_artistico: Ricardo Darin
                //nacionalidad: argentino
                //género: Masculino.
                context.Actores.Add(new Actor
                {
                    Nombre = "Ricardo",
                    Apellido = "Darin",
                    Edad = 67,
                    NombreArtistico = "Ricardo Darin",
                    Nacionalidad = "Argentino",
                    Genero = "M"
                });
                context.SaveChanges();

                #endregion

                #region ejercicio 6
                //obtener la cantidad de actores y actrices que no son de Estados Unidos.
                var cantidadActoresNoEstadounidenses = GetCantidadActoresNoEstadounidenses(context);

                static int GetCantidadActoresNoEstadounidenses(AppDbContext context)
                {
                    return context.Actores.Count(a => a.Nacionalidad != "Estados Unidos");
                }

                #endregion

                #region ejercicio 7
                //obtener los nombres y apellidos de todos los actores maculinos.
                var actoresMasculinos = GetActoresMasculinos(context);

                static List<Actor> GetActoresMasculinos(AppDbContext context)
                {
                    return context.Actores.Where(a => a.Genero == "Masculino").ToList();
                }

                #endregion
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
           {
               services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer("Server=your_server_name;Database=your_database_name;Trusted_Connection=True;"));
           });
    }
}