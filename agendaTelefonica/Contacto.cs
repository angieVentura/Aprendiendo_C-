using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendaTelefonica
{
    internal class Contacto
    {
        public string nombre, telefono;

        public Contacto(string nombre, string telefono)
        {
            this.telefono = telefono;
            this.nombre = nombre;
        }
    }
}
