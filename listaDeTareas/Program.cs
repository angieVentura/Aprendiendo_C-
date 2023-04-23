using System;
using System.Collections.Generic;
using System.Linq;

namespace listaDeTareas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> tareas = new Dictionary<string, int>();
            List<string> nombresTareas = new List<string>();

            Console.WriteLine("Lista de tareas");

            while (true)
            {
                Console.WriteLine("Nombre de la tarea o escriba 'exit' par ver la lista de tareas: ");
                string nombreTarea = Console.ReadLine().ToLower();

                if (nombreTarea == "exit") break;

                int prioridadTarea = 0;

                while (prioridadTarea == 0)
                {
                    Console.WriteLine("Nivel de prioridad [1]alta, [2]media, [3]baja): ");
                    string prioridad = Console.ReadLine();

                    if (int.TryParse(prioridad, out prioridadTarea) && prioridadTarea >= 1 && prioridadTarea <= 3) break;

                    Console.WriteLine("El nivel de prioridad debe ser un número entre 1 y 3.");
                }

                tareas.Add(nombreTarea, prioridadTarea);
                nombresTareas.Add(nombreTarea);
            }

            var tareasOrdenadas = nombresTareas.OrderBy(nombre => tareas[nombre]);

            Console.WriteLine("\nTareas organizadas por prioridad:");

            foreach (var nombreTarea in tareasOrdenadas)
            {
                Console.WriteLine("{0} ({1})", nombreTarea, tareas[nombreTarea]);
            }

            Console.WriteLine("Presione cualquier tecla para salir.");
            Console.ReadKey();
        }
    }
}