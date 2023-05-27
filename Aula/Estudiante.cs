using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula
{
    internal class Estudiante: Persona
    {
        public int calificacion;
        public Estudiante(string nombre, char sexo, int edad, int calificacion) : base(nombre, sexo, edad)
        {
            this.calificacion = calificacion;
            presente = Probabilidad();
        }
        public bool Probabilidad()
        {
            return rand.Next(0, 101) <= 50;
        }
    }
}
