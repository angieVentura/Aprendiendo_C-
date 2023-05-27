using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula
{
    internal class Profesor : Persona
    {
        public Materia materia;
        public Profesor(string nombre, char sexo, int edad, Materia materia) : base(nombre, sexo, edad)
        {
            this.materia = materia;
            presente = Probabilidad();
        }
        public bool Probabilidad()
        {
            return rand.Next(0, 101) <= 80;
        }
    }
}
