using System;
using System.Data.Common;
using System.Linq;

namespace agendaTelefonica
{

    class Contacto
    {
        public string nombre, telefono;

        public Contacto(string nombre, string telefono)
        {
            this.telefono = telefono;
            this.nombre = nombre;
        }
    }

    class Agenta
    {
        public Contacto[] contactos;

        public Agenta()
        {
            contactos = new Contacto[10];
        }

        public Agenta(int cantidad)
        {
            contactos = new Contacto[cantidad];
        }

        public string[] AniadirContacto(Contacto c)
        {
            string[] motivos = {
            contactos.Any(ct => ct.nombre == c.nombre ) ? "El contacto ya existe." : null,
            contactos.Any(ct => ct == null) ? null : "No hay más espacio en la agenda."
            };

            if (!contactos.Any(ct => ct.nombre == c.nombre) && contactos.Any(ct => ct == null)) contactos[Array.IndexOf(contactos, contactos.First(ct => ct == null))] = c;

            return motivos;
        }

        public bool ExisteContacto(Contacto c)
        {
            return contactos.Any(ct => ct.nombre == c.nombre);
        }

        public string ListarContactos()
        {
            return string.Join("\n", contactos.Where(c => c != null).Select(c => $"Nombre:{c.nombre}, Teléfono:{c.telefono}"));
        }

        public string BuscarContacto(string nombre)
        {
            return contactos.Count(c => c.nombre == nombre) > 1 ? $"Coincidencias: {contactos.Count(c => c.nombre == nombre)}\n\n{string.Join("\n", contactos.Where(c => c.nombre == nombre).Select(c => c.telefono))}" : contactos.FirstOrDefault(c => c.nombre == nombre)?.telefono;
        }

        public bool EliminarContacto(Contacto c)
        {
            return !Convert.ToBoolean(contactos[Array.IndexOf(contactos, c)] = null);
        }

        public bool AgendaLlena()
        {
            return !contactos.Any(c => c == null);
        }

        public int HuecosLibres()
        {
            return contactos.Count(c => c == null);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
