using System;
using System.Collections.Generic;
using System.Linq;

namespace cajeroAutomático
{
    class Usuario
    {
        public string name;
        public string password;
        public double saldo;

        public Usuario(string name, string password, double saldo)
        {

            this.name = name;
            this.password = password;
            this.saldo = saldo;

        }
    }
    internal class Program
    {
        /*Crear un programa que simule un cajero automático, permitiendo al usuario hacer depósitos, retiros y consultar su saldo.*/

        static void mensaje(string mensaje, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(mensaje);
        }

        static string entrada(string mensaje, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(mensaje);
            Console.SetCursorPosition(x, y + 2);
            return Console.ReadLine();
        }

        static void hacerMenu(string[] menu)
        {
            for (int i = 0; i < menu.Count(); i++)
            {
                mensaje($"{menu[i]}", Console.WindowWidth / 3, 5 + i);
            }

        }


        static void Main(string[] args)
        {
            List<Usuario> list = new List<Usuario>();
            list.Add(new Usuario("Pablo", "123", 1.50));
            list.Add(new Usuario("tobi", "uwu", 1.25));
            list.Add(new Usuario("sofi", "owo", 2.50));
            list.Add(new Usuario("feli", "Huracan", 0.75));
            bool estadoUsuario = true;
            bool estadoContraseña = true;
            int contador = 4;
            int op;
            string[] menu = { "[1]Depósitar", "[2]Retirar", "[3]Consultar Saldo", "[4] Salir" };

            mensaje("CAJERO AUTOMÁTICO", Console.WindowWidth / 3, 3);
            string name = entrada("Ingrese el nombre para acceder al cajero", Console.WindowWidth / 3, 5);
            Usuario encontrado = list.Find(u => u.name.ToLower() == name.ToLower());

            if (encontrado != null) estadoUsuario = false;

            while (estadoUsuario)
            {
                mensaje("No se encontro al usuario, intentelo de nuevo", Console.WindowWidth / 3, 9);
                mensaje(" ".PadLeft(45), Console.WindowWidth / 3, 7);
                name = entrada("", Console.WindowWidth / 3, 5);
                encontrado = list.Find(u => u.name.ToLower() == name.ToLower());
                if (encontrado != null) estadoUsuario = false;
            }

            Console.Clear();
            mensaje("CAJERO AUTOMÁTICO", Console.WindowWidth / 3, 3);
            string password = entrada("Ingrese la contraseña para acceder al cajero", Console.WindowWidth / 3, 5);

            if (encontrado.password == password) estadoContraseña = false;

            while (estadoContraseña)
            {
                contador--;
                if (contador == 0) Environment.Exit(0);

                mensaje($"Contraseña incorrecta, cantidad de intentos disponibles: {contador}", Console.WindowWidth / 3, 9);
                mensaje(" ".PadLeft(45), Console.WindowWidth / 3, 7);
                password = entrada("", Console.WindowWidth / 3, 5);
                if (encontrado.password == password) estadoContraseña = false;
            }

            while (true)
            {
                Console.Clear();
                mensaje("CAJERO AUTOMÁTICO", Console.WindowWidth / 3, 3);
                hacerMenu(menu);
                Console.SetCursorPosition(Console.WindowWidth / 3, 10);
                bool estadoMenu = int.TryParse(Console.ReadLine(), out op);
                if (!estadoMenu) Environment.Exit(0);
                
                Console.Clear();
                mensaje("CAJERO AUTOMÁTICO", Console.WindowWidth / 3, 3);
                
                switch (op)
                {
                    case 1:

                        int dep = Convert.ToInt32(entrada("Ingrese cantidad a depositar:", Console.WindowWidth / 3, 5));
                        encontrado.saldo += dep;
                        mensaje("Toque cualquier letra para acceder al menu", Console.WindowWidth / 3, 7);
                        Console.ReadKey();
                        
                        break;
                    case 2:

                        int ret = Convert.ToInt32(entrada("Ingrese cantidad a retirar:", Console.WindowWidth / 3, 5));
                        encontrado.saldo -= ret;

                        mensaje("Toque cualquier letra para acceder al menu", Console.WindowWidth / 3, 7);
                        Console.ReadKey();
                        break;
                    case 3:

                        mensaje($"Tu saldo es de:{encontrado.saldo}", Console.WindowWidth / 3, 5);

                        mensaje("Toque cualquier letra para acceder al menu", Console.WindowWidth / 3, 7);
                        Console.ReadKey();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;

                }
            }
        }
    }
}


