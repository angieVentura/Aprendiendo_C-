using System;

namespace Password
{
    class Password
    {
        private int longitud;
        private string contrasena;
        private static Random rnd = new Random();

        public Password()
        {
            longitud = 8;
            contrasena = generarPassword(longitud);
        }

        public Password(int longitud)
        {
            this.longitud = longitud;
            contrasena = generarPassword(longitud);
        }

        public int Longitud
        {
            get { return longitud; }
            set { longitud = value; contrasena = generarPassword(longitud); }
        }

        public string Contrasena
        {
            get { return contrasena; }
        }

        public bool esFuerte()
        {
            int mayusculas = 0;
            int minusculas = 0;
            int numeros = 0;

            foreach (char c in contrasena)
            {
                if (Char.IsUpper(c))
                {
                    mayusculas++;
                }
                else if (Char.IsLower(c))
                {
                    minusculas++;
                }
                else if (Char.IsDigit(c))
                {
                    numeros++;
                }
            }

            return (mayusculas > 2 && minusculas > 1 && numeros > 5);
        }

        public static string generarPassword(int longitud)
        {
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            char[] contraseña = new char[longitud];

            for (int i = 0; i < longitud; i++)
                contraseña[i] = caracteres[rnd.Next(caracteres.Length)];

            return new string(contraseña);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese la longitud de los passwords: ");
            int longitud = int.Parse(Console.ReadLine());

            Console.Write("Ingrese la cantidad de passwords a generar: ");
            int tamano = int.Parse(Console.ReadLine());

            Password[] passwords = new Password[tamano];
            bool[] esFuerteArray = new bool[tamano];

            for (int i = 0; i < tamano; i++)
            {
                passwords[i] = new Password(longitud);
                esFuerteArray[i] = passwords[i].esFuerte();
                Console.WriteLine("{0} {1}", passwords[i].Contrasena, esFuerteArray[i]);
            }

            Console.ReadLine();
        }
    }
}
