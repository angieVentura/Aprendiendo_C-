using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula
{
    internal class Persona
    {
        public string nombre;
        public char sexo;
        public int edad;
        public bool presente;
        public Random rand = new Random();
        public Persona(string nombre, char sexo, int edad)
        {
            this.nombre = nombre;
            this.sexo = sexo;
            this.edad = edad;
        }
    }
}
