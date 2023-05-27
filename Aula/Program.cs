using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula
{
    public enum Materia
    {
        Matematicas,
        Filosofia,
        Fisica
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            char[] sexo = { 'h', 'm' };
            string[] nombresM = { "Ana", "María", "Sofía", "Laura", "Isabella", "Valentina", "Emma", "Lucía", "Mía", "Camila", "Valeria", "Martina", "Paula", "Sara", "Julia", "Emily", "Ximena", "Victoria", "Nicole", "Daniela", "Alejandra", "Carolina", "Fernanda", "Regina", "Luna", "Adriana", "Gabriela", "Clara", "Natalia", "Elena" };
            string[] nombresH = { "Juan", "Pedro", "Diego", "Carlos", "Luis", "Miguel", "Alejandro", "Sebastián", "Gabriel", "Andrés", "Javier", "Daniel", "Fernando", "José", "David", "Ricardo", "Pablo", "Emilio", "Hugo", "Gustavo", "Rodrigo", "Manuel", "Rafael", "Mario", "Santiago", "Francisco", "Jorge", "Antonio", "Roberto", "Ángel" };
            Materia[] materias = (Materia[])Enum.GetValues(typeof(Materia));
            int cMaterias = materias.Length;
            while (true)
            {
                Random rand = new Random();
                List<Estudiante> estudiantes = new List<Estudiante>();
                char sexoP = sexo[rand.Next(0, sexo.Length)];
                Profesor profesor = new Profesor(sexoP == 'h' ? nombresH[rand.Next(0, nombresH.Length)] : nombresM[rand.Next(0, nombresM.Length)], sexoP, rand.Next(25, 65), (Materia)rand.Next(0, cMaterias));
                Aula aula = new Aula(rand.Next(0, 11), rand.Next(20, 40), (Materia)rand.Next(0, cMaterias), profesor, estudiantes);
                estudiantes.AddRange(Enumerable.Range(0, aula.maxAl).Select(_ => new Estudiante((sexoP = sexo[rand.Next(0, sexo.Length)]) == 'h' ? nombresH[rand.Next(0, nombresH.Length)] : nombresM[rand.Next(0, nombresM.Length)], sexoP, rand.Next(12, 25), rand.Next(0, 11))));

                Console.Clear();
                Console.WriteLine(aula.ClaseSuspendida().Any(s => s != null) ? $"No se puede dar clase, ya que: \n{string.Join("\n", aula.ClaseSuspendida().Where(c => c != null))}" : $"Se puede dar clase. Las alumnas aprobadas son {aula.AprobadosM()} y los alumnos aprobados son {aula.AprobadosH()}.");
                Console.WriteLine("\nToque cualquier letra para reiniciar.");
                Console.ReadKey();
            }
        }
    }
}
