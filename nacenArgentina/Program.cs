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
            CrearPersona("Argentina");
            CrearPersona("Argentina");
            CrearPersona("Argentina");

            var timer = new System.Threading.Timer(
                e => MostrarPersonas("Lista de personas","Lista de muertos" ,"Población"),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(10));

            var timerNacimiento = new System.Threading.Timer(
                e => CrearPersona("Argentina"),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(30));

            var timerMuerte = new System.Threading.Timer(
                e => EliminarPersona("Argentina"),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(60));

            Console.ReadLine();
        }

        static void CrearPersona( string pais)
        {
            string[] nombres = new string[30] { "Juan", "María", "Pedro", "Laura", "Andrés", "Ana", "Diego", "Carla", "Lucía", "Javier", "Lucas", "Marta", "Luis", "Clara", "Isabel", "Pablo", "Elena", "Sofía", "Gonzalo", "Valentina", "Fernando", "Valeria", "Antonio", "Natalia", "Gabriel", "Sara", "Hugo", "Carmen", "Rafael", "Inés" };

            string[] apellidos = new string[30] { "García", "Pérez", "Martínez", "Sánchez", "Gómez", "Álvarez", "Fernández", "González", "Romero", "Ortega", "Rubio", "Molina", "López", "Hernández", "Díaz", "Moreno", "Muñoz", "Alonso", "Castro", "Núñez", "Navarro", "Jiménez", "Ramos", "Gutiérrez", "Torres", "Vázquez", "Serrano", "Reyes", "Ramírez", "Blanco" };

            list.Add(new Personas(nombres[ran.Next(30)], apellidos[ran.Next(30)], pais));
        }

        static void EliminarPersona(string pais)
        {
            if (list.Count > 0)
            {
                int eliminado = ran.Next(list.Count);
                listM.Add(new Personas(list[eliminado].name, list[eliminado].surname, pais));
                list.RemoveAt(eliminado);
            }
        }
        static void MostrarPersonas(string mensaje1, string mensaje2, string marcador)
        {
            Console.Clear();
            Console.WriteLine($"{mensaje1}:");
            foreach (var persona in list)
            {
                Console.WriteLine($"{persona.name} {persona.surname}");
            }
            Console.WriteLine($"\n{marcador}: {list.Count}");

            if (listM.Count > 0)
            {
                Console.SetCursorPosition(20, 0);
                Console.WriteLine($"{mensaje2}:");

                for (int i = 0; i < listM.Count; i++)
                {
                    Console.SetCursorPosition(20, 1 + i);
                    Console.WriteLine($"{listM[i].name} {listM[i].surname}");
                }
            }

        }
    }
}