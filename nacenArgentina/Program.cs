using System;
using System.Collections.Generic;

namespace nacenArgentina
{
    class Personas
    {
        public string name;
        public string surname;
        public string nationality;

        public Personas(string name, string surname, string nationality)
        {
            this.name = name;
            this.surname = surname;
            this.nationality = nationality;

        }
    }
    internal class Program
    {
        static List<Personas> list = new List<Personas>();
        static List<Personas> listM = new List<Personas>();
        static Random ran = new Random();
        static void Main(string[] args)
        {
            CrearPersona();
            CrearPersona();
            CrearPersona();

            // Refrescar la lista cada 10 segundos
            var timer = new System.Threading.Timer(
                e => MostrarPersonas(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            // Crear una persona cada 30 segundos
            var timerNacimiento = new System.Threading.Timer(
                e => CrearPersona(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(15));

            // Eliminar una persona cada 60 segundos
            var timerMuerte = new System.Threading.Timer(
                e => EliminarPersona(),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(30));

            Console.ReadLine();
        }

        static void CrearPersona()
        {
            string[] nombres = new string[30] { "Juan", "María", "Pedro", "Laura", "Andrés", "Ana", "Diego", "Carla", "Lucía", "Javier", "Lucas", "Marta", "Luis", "Clara", "Isabel", "Pablo", "Elena", "Sofía", "Gonzalo", "Valentina", "Fernando", "Valeria", "Antonio", "Natalia", "Gabriel", "Sara", "Hugo", "Carmen", "Rafael", "Inés" };

            string[] apellidos = new string[30] { "García", "Pérez", "Martínez", "Sánchez", "Gómez", "Álvarez", "Fernández", "González", "Romero", "Ortega", "Rubio", "Molina", "López", "Hernández", "Díaz", "Moreno", "Muñoz", "Alonso", "Castro", "Núñez", "Navarro", "Jiménez", "Ramos", "Gutiérrez", "Torres", "Vázquez", "Serrano", "Reyes", "Ramírez", "Blanco" };

            list.Add(new Personas(nombres[ran.Next(30)], apellidos[ran.Next(30)], "Argentina"));
        }

        static void EliminarPersona()
        {
            if (list.Count > 0)
            {
                int eliminado = ran.Next(list.Count);
                listM.Add(new Personas(list[eliminado].name, list[eliminado].surname, "Argentina"));
                list.RemoveAt(eliminado);
            }
        }
        static void MostrarPersonas()
        {
            Console.Clear();
            Console.WriteLine("Lista de personas:");
            foreach (var persona in list)
            {
                Console.WriteLine($"{persona.name}, {persona.surname}");
            }
            Console.WriteLine($"Población: {list.Count}");

            if (listM.Count > 0)
            {
                Console.SetCursorPosition(20, 0);
                Console.WriteLine("Lista de Muertes:");

                for (int i = 0; i < listM.Count; i++)
                {
                    Console.SetCursorPosition(20, 1 + i);
                    Console.WriteLine($"{listM[i].name} {listM[i].surname}");
                }
            }

        }
    }
}