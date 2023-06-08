using System;
using System.Collections.Generic;
using System.Linq;

namespace empleados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string[] nombres = { "Juan", "María", "Carlos", "Ana", "Pedro", "Laura", "Luis", "Sofía", "Andrés", "Lucía" };
            string[] zonas = { "zona 1", "zona 2", "zona 3", "zona 4", "zona 5", "zona 6", "zona 7", "zona 8", "zona 9", "zona 10" };

            List<Empleado> empleados = new List<Empleado>
            {
                new Comercial(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2)),
                new Comercial(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2)),
                new Comercial(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2)),
                new Comercial(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2)),
                new Repartidor(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), zonas[rand.Next(zonas.Length)]),                
                new Repartidor(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), zonas[rand.Next(zonas.Length)]),                
                new Repartidor(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), zonas[rand.Next(zonas.Length)]),                
                new Repartidor(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), zonas[rand.Next(zonas.Length)])
            };

            Console.WriteLine("Empleados:\n");
            empleados.ForEach(emp => Console.WriteLine(emp.Mostrar()));

            Console.WriteLine("\nAplicando Plus:\n");
            empleados.ForEach(emp => { emp.Plus(); Console.WriteLine(emp.Mostrar()); });

            Console.ReadKey();
        }
    }
}
