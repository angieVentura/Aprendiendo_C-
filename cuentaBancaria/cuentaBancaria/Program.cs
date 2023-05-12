using System;
using System.Collections.Generic;
using System.Linq;

namespace cuentaBancaria
{
    internal class Program
    {

        class Cuenta
        {
            public string titular;
            public double cantidad;

            public Cuenta(string titular, double cantidad)
            {
                this.titular = titular;
                this.cantidad = cantidad;
            }

            public Cuenta(string titular)
            {
                this.titular = titular;
                this.cantidad = 0.0;
            }

            static public string ingresar(double ingreso, Cuenta persona)
            {
                if (ingreso > 0)
                {
                    persona.cantidad += ingreso;
                    return persona.titular;
                }

                return null;
            }

            static public string retirar(double gasto, Cuenta persona)
            {
                persona.cantidad = persona.cantidad - gasto;
                if (persona.cantidad - gasto < 0) persona.cantidad = 0.0;
                return null;
            }

        }

        static public string[] menu = { "MENU", "[1]Ingresar monto", "[2]Retirar monto" };


        static public void mensaje(string mensaje, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(mensaje);
        }

        static public string read(string mensaje, int x, int y, int y2)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(mensaje);
            Console.SetCursorPosition(x, y2);
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            List<Cuenta> cuentas = new List<Cuenta>
            {
                new Cuenta("Gaspi", 200.1 ),
                new Cuenta("Sofi", 200.1),
                new Cuenta("Luis", 300.25),
                new Cuenta("Tamara", 300.3),
                new Cuenta("Tobi", 290.9),
                new Cuenta("Claudia"),
                new Cuenta("Angie", 777.7)
            };
            int op;
            //Acceso
            string titular = read("Ingrese el nombre del titular de la cuenta", Console.WindowWidth / 3, 3, 5);
            Cuenta encontrado = cuentas.Find(t => t.titular.ToLower() == titular.ToLower());

            while (encontrado == null)
            {
                mensaje(" ".PadLeft(45, ' '), Console.WindowWidth / 3, 5);
                titular = read("No se encontro al titular de la cuenta", Console.WindowWidth / 3, 7, 5);
                encontrado = cuentas.Find(t => t.titular.ToLower() == titular.ToLower());
            }

            Console.Clear();
            for (int i = 0; i < menu.Count(); i++)
                mensaje(menu[i], Console.WindowWidth / 3, 3 + i);
            bool suceso = int.TryParse(read("Seleccione una opción", Console.WindowWidth / 3, 7, 9), out op);
            if (!suceso) Environment.Exit(0);

            while (suceso)
            {
  
                switch (op)
                {
                    case 1:
                        //Monto
                        Console.Clear();
                        double ingresoMonetario = Convert.ToDouble(read("Ingrese el monto:", Console.WindowWidth / 3, 3, 5));
                        string operacion = Cuenta.ingresar(ingresoMonetario, encontrado);
                        mensaje($" Su monto actual es: {encontrado.cantidad} ", Console.WindowWidth / 3, 7);
                        mensaje($"Toque cualquier letra para volver al menu", Console.WindowWidth / 3, 13);
                        Console.ReadKey();

                        Console.Clear();
                        for (int i = 0; i < menu.Count(); i++)
                            mensaje(menu[i], Console.WindowWidth / 3, 3 + i);
                       suceso = int.TryParse(read("Seleccione una opción", Console.WindowWidth / 3, 7, 9), out op);
                        if (!suceso) Environment.Exit(0);

                        break;
                    case 2:
                        //Retirar
                        Console.Clear();
                        double gastoMonetario = Convert.ToDouble(read("Ingrese el monto a retirar:", Console.WindowWidth / 3, 3, 5));
                        Cuenta.retirar(gastoMonetario, encontrado);
                        mensaje($"Su monto actual es: {encontrado.cantidad} ", Console.WindowWidth / 3, 9);
                        mensaje($"Toque cualquier letra para volver al menu", Console.WindowWidth / 3, 13);
                        Console.ReadKey();
                        Console.Clear();
                        for (int i = 0; i < menu.Count(); i++)
                            mensaje(menu[i], Console.WindowWidth / 3, 3 + i);
                        suceso = int.TryParse(read("Seleccione una opción", Console.WindowWidth / 3, 7, 9), out op);
                        if (!suceso) Environment.Exit(0);

                        break;
                    default: 
                        mensaje($"Ingrese una opción valida", Console.WindowWidth / 3, 11);
                        mensaje($"Toque cualquier letra para volver al menu", Console.WindowWidth / 3, 13);
                        Console.ReadKey();
                        Console.Clear();
                        for (int i = 0; i < menu.Count(); i++)
                            mensaje(menu[i], Console.WindowWidth / 3, 3 + i);
                        suceso = int.TryParse(read("Seleccione una opción", Console.WindowWidth / 3, 7, 9), out op);
                        if (!suceso) Environment.Exit(0);

                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
