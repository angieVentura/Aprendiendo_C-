using System;
using System.Collections.Generic;
using System.Linq;

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
        static Random ran = new Random();
        static string[] pais = new string[3] { "Argentina", "Paraguay", " Brasil" };
        static void Main(string[] args)
        {
            CrearPersona(pais[0]);
            CrearPersona(pais[1]);
            CrearPersona(pais[2]);
            CrearPersona(pais[0]);
            CrearPersona(pais[1]);
            CrearPersona(pais[2]);
            CrearPersona(pais[0]);
            CrearPersona(pais[1]);
            CrearPersona(pais[2]);

            var act = new System.Threading.Timer(
                e => MostrarPersonas("Población", pais[0], pais[1], pais[2]),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(10));

            var nacimientoAr = new System.Threading.Timer(
                e => CrearPersona(pais[0]),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(ran.Next(40)));

            var nacimientoCh = new System.Threading.Timer(
                e => CrearPersona(pais[1]),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(ran.Next(40)));

            var nacimientoMx = new System.Threading.Timer(
                e => CrearPersona(pais[2]),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(ran.Next(40)));

            var muerteA = new System.Threading.Timer(
                e => EliminarPersona(pais[0]),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(60));

            var muerteC = new System.Threading.Timer(
                e => EliminarPersona(pais[1]),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(62));

            var muerteM = new System.Threading.Timer(
                e => EliminarPersona(pais[2]),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(61));

            var noPersonas = new System.Threading.Timer(
                e => noGente(pais[ran.Next(3)]),
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(120));

            Console.ReadLine();
        }

        static void CrearPersona(string nationality)
        {
            string[] nombres = new string[30] { "Juan", "María", "Pedro", "Laura", "Andrés", "Ana", "Diego", "Carla", "Lucía", "Javier", "Lucas", "Marta", "Luis", "Clara", "Isabel", "Pablo", "Elena", "Sofía", "Gonzalo", "Valentina", "Fernando", "Valeria", "Antonio", "Natalia", "Gabriel", "Sara", "Hugo", "Carmen", "Rafael", "Inés" };

            string[] apellidos = new string[30] { "García", "Pérez", "Martínez", "Sánchez", "Gómez", "Álvarez", "Fernández", "González", "Romero", "Ortega", "Rubio", "Molina", "López", "Hernández", "Díaz", "Moreno", "Muñoz", "Alonso", "Castro", "Núñez", "Navarro", "Jiménez", "Ramos", "Gutiérrez", "Torres", "Vázquez", "Serrano", "Reyes", "Ramírez", "Blanco" };

            list.Add(new Personas(nombres[ran.Next(29)], apellidos[ran.Next(29)], nationality));
        }

        static void EliminarPersona(string nationality)
        {
            var personas = list.Where(p => p.nationality == nationality).ToList();

            if (personas.Count > 0)
            {
                var personaSeleccionada = personas[ran.Next(personas.Count)];

                list.Remove(personaSeleccionada);
            }
        }
        static void MostrarPersonas(string marcador, string p1, string p2, string p3)
        {
            Console.Clear();
            mensaje(p1, 0, 2);
            mensaje(p2, 30, 2);
            mensaje(p3, 60, 2);
            int countA = 0;
            int countC = 0;
            int countM = 0;
            var listOrdenada = list.OrderBy(p => p.surname).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                if (listOrdenada[i].nationality == pais[0])
                {
                    countA++;
                    mensaje($"{listOrdenada[i].name} {listOrdenada[i].surname}", 0, 4 + countA);
                }
                else if (listOrdenada[i].nationality == pais[1])
                {
                    countC++;
                    mensaje($"{listOrdenada[i].name} {listOrdenada[i].surname}", 30, 4 + countC);
                }
                else
                {
                    countM++;
                    mensaje($"{listOrdenada[i].name} {listOrdenada[i].surname}", 60, 4 + countM);
                }

            }

            mensaje($"{marcador}: {countA}", 0, 6 + countA);
            mensaje($"{marcador}: {countC}", 30, 6 + countC);
            mensaje($"{marcador}: {countM}", 60, 6 + countM);

        }
        static void mensaje(string mensaje, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(mensaje);
        }

        static void noGente(string nationality)
        {
            list.RemoveAll(p => p.nationality == nationality);
        }
    }
}