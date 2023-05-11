using System;
using System.Collections.Generic;

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

            static public string ingresar(double ingreso, List<Cuenta> cuenta, string titular)
            {
                if (ingreso > 0)
                {
                    cuenta.Find(c => c.titular == titular);
                    cuenta[Convert.ToInt32(titular)].cantidad += ingreso;
                    return titular;
                }

                return null;
            }


        }

        /*1) Crea una clase llamada Cuenta que tendrá los siguientes atributos: 
            * titular y cantidad (puede tener decimales).
            El titular será obligatorio y la cantidad es opcional. Crea dos constructores que cumplan lo anterior.
Tendrá dos métodos especiales:
ingresar(double cantidad): se ingresa una cantidad a la cuenta, si la cantidad introducida es negativa, no se hará nada.
retirar(double cantidad): se retira una cantidad a la cuenta, si restando la cantidad actual a la que nos pasan es negativa, la cantidad de la cuenta pasa a ser 0.
*/
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
                new Cuenta("Claudia", 300.5),
                new Cuenta("Angie", 777.7)
            };


            string titular = read("Ingrese el nombre del titular de la cuenta", Console.WindowWidth / 3, 3, 5);

            Cuenta encontrado = cuentas.Find(t => t.titular == titular);

            while (encontrado == null)
            {
                mensaje(" ".PadLeft(45, ' '), Console.WindowWidth / 3, 5);
                titular = read("No se encontro al titular de la cuenta", Console.WindowWidth / 3, 7, 5);
                encontrado = cuentas.Find(t => t.titular == titular);
            }

            double ingresoMonetario = Convert.ToDouble(read("Ingrese el monto:", Console.WindowWidth / 3, 3, 5));

            if (ingresoMonetario > 0)
            {
                encontrado.cantidad += ingresoMonetario;
            }

            Console.Clear();

            mensaje("lol", Console.WindowWidth / 3, 5);

            Console.ReadKey();
        }
    }
}
