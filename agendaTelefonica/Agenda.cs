using System;
using System.Linq;

namespace agendaTelefonica
{
    internal class Agenda
    {
        public Contacto[] contactos;

        public Agenda()
        {
            contactos = new Contacto[10];
            for (int i = 0; i < contactos.Length; i++)
            {
                contactos[i] = new Contacto(null, null);
            }
        }

        public Agenda(int cantidad)
        {
            contactos = new Contacto[cantidad];
            for (int i = 0; i < contactos.Length; i++)
            {
                contactos[i] = new Contacto(null, null);
            }
        }
        public bool ExisteContacto(Contacto c)
        {
            return contactos.Any(ct => ct.nombre == c.nombre);
        }
        public string[] AniadirContacto(Contacto c)
        {

            string[] motivos = {
            contactos.Where(ct => ct.nombre != null).Any(ct => ct.nombre.ToLower() == c.nombre.ToLower() ) ? "El contacto ya existe" : null,
            contactos.Any(ct => ct.nombre == null) ? null : "No hay más espacio en la agenda"
            };

            if (!ExisteContacto(c) && contactos.Any(ct => ct.nombre == null) && !contactos.Any(ct => ct.telefono == c.telefono)) contactos[Array.IndexOf(contactos, contactos.First(ct => ct.telefono == null))] = c;

            return motivos;
        }

        public string ListarContactos()
        {
            return string.Join("\n", contactos.Where(c => c.nombre != null).Select(c => $"{" ".PadLeft(Console.WindowWidth / 4 + 5)}Nombre:{c.nombre}, Teléfono:{c.telefono}"));
        }

        public string BuscarContacto(string nombre)
        {
            Contacto contacto = contactos.FirstOrDefault(c => c.nombre != null && c.nombre.ToLower() == nombre.ToLower());
            return contacto?.telefono;

        }

        public bool EliminarContacto(Contacto c)
        {
            return (Array.FindIndex(contactos, con => con == c) is int index && index != -1 && index < contactos.Length) ? (contactos[index] = new Contacto(null, null)) != null : false;

        }

        public bool AgendaLlena()
        {
            return !contactos.Any(c => c.nombre == null);
        }

        public int HuecosLibres()
        {
            return contactos.Count(c => c.nombre == null);
        }
    }

}
