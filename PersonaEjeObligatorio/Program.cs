using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonaEjeObligatorio
{

    class Persona
    {
        private string nombre;
        private int edad;
        private string dni;
        private char sexo;
        private double peso;
        private double altura;

        private const char SEXO_POR_DEFECTO = 'H';
        public const int PESO_IDEAL_BAJO = -1;
        public const int PESO_IDEAL_NORMAL = 0;
        public const int PESO_IDEAL_ALTO = 1;

        public Persona()
        {
            this.nombre = "";
            this.edad = 0;
            this.dni = generaDNI();
            this.sexo = SEXO_POR_DEFECTO;
            this.peso = 0;
            this.altura = 0;
        }

        public Persona(string nombre, int edad, char sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.dni = generaDNI();
            this.sexo = comprobarSexo(sexo);
            this.peso = 0;
            this.altura = 0;
        }

        public Persona(string nombre, int edad, string dni, char sexo, double peso, double altura)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.dni = dni;
            this.sexo = comprobarSexo(sexo);
            this.peso = peso;
            this.altura = altura;
        }

        public string getNombre()
        {
            return this.nombre;
        }

        public int getEdad()
        {
            return this.edad;
        }

        public char getSexo()
        {
            return this.sexo;
        }

        public double getPeso()
        {
            return this.peso;
        }

        public double getAltura()
        {
            return this.altura;
        }


        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public void setEdad(int edad)
        {
            this.edad = edad;
        }

        public void setSexo(char sexo)
        {
            this.sexo = comprobarSexo(sexo);
        }

        public void setPeso(double peso)
        {
            this.peso = peso;
        }

        public void setAltura(double altura)
        {
            this.altura = altura;
        }

        public int calcularIMC()
        {
            double imc = peso / Math.Pow(altura, 2);

            if (imc < 20)
            {
                return PESO_IDEAL_BAJO;
            }
            else if (imc >= 20 && imc <= 25)
            {
                return PESO_IDEAL_NORMAL;
            }
            else
            {
                return PESO_IDEAL_ALTO;
            }
        }

        public bool esMayorDeEdad()
        {
            return edad >= 18;
        }

        private char comprobarSexo(char sexo)
        {
            if (sexo != 'H' && sexo != 'M')
            {
                return SEXO_POR_DEFECTO;
            }
            else
            {
                return sexo;
            }
        }

        private string generaDNI()
        {
            Random random = new Random();
            int numDNI = random.Next(10000000, 99999999);
            string letraDNI = generaLetraDNI(numDNI);

            return numDNI.ToString() + letraDNI;
        }

        private string generaLetraDNI(int numDNI)
        {
            Random random = new Random();
            int numLetra = random.Next(0, 2); 
            string letraDNI = "";

            if (numLetra == 0) 
            {
                letraDNI = "H";
            }
            else 
            {
                letraDNI = "M";
            }

            return letraDNI;
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {

            // Personita 1
            Console.WriteLine("Introduce el nombre: ");
            string nombre1 = Console.ReadLine();
            Console.WriteLine("Introduce la edad: ");
            int edad1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce el sexo (H/M): ");
            char sexo1 = char.Parse(Console.ReadLine().ToUpper());
            Console.WriteLine("Introduce el peso en kg: ");
            double peso1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Introduce la altura: ");
            double altura1 = double.Parse(Console.ReadLine());

            Persona persona1 = new Persona(nombre1, edad1, "", sexo1, peso1, altura1);

            int imc1 = persona1.calcularIMC();
            string mensaje1 = "";

            if (imc1 == Persona.PESO_IDEAL_BAJO)
            {
                mensaje1 = "Bajo peso";
            }
            else if (imc1 == Persona.PESO_IDEAL_NORMAL)
            {
                mensaje1 = "Peso normal";
            }
            else
            {
                mensaje1 = "Sobrepeso";
            }

            Console.WriteLine("\nPersona 1:");
            Console.WriteLine("Nombre: " + persona1.getNombre());
            Console.WriteLine("Edad: " + persona1.getEdad());
            Console.WriteLine("Sexo: " + persona1.getSexo());
            Console.WriteLine("Peso: " + persona1.getPeso() + " kg");
            Console.WriteLine("Altura: " + persona1.getAltura() + " m");
            Console.WriteLine("IMC: " + imc1 + " (" + mensaje1 + ")");
            Console.WriteLine("Mayor de edad: " + persona1.esMayorDeEdad());

            // Personita dos
            Console.WriteLine("\nIntroduce el nombre: ");
            string nombre2 = Console.ReadLine();
            Console.WriteLine("Introduce la edad: ");
            int edad2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduce el sexo (H/M): ");
            char sexo2 = char.Parse(Console.ReadLine().ToUpper());

            Persona persona2 = new Persona(nombre2, edad2, sexo2);

            int imc2 = persona2.calcularIMC();
            string mensaje2 = "";

            if (imc2 == Persona.PESO_IDEAL_BAJO)
            {
                mensaje2 = "Bajo peso";
            }
            else if (imc2 == Persona.PESO_IDEAL_NORMAL)
            {
                mensaje2 = "Peso normal";
            }
            else
            {
                mensaje2 = "Sobrepeso";
            }

            Console.WriteLine("\nPersona 2:");
            Console.WriteLine("Nombre: " + persona2.getNombre());
            Console.WriteLine("Edad: " + persona2.getEdad());
            Console.WriteLine("Sexo: " + persona2.getSexo());
            Console.WriteLine("Peso: " + persona2.getPeso() + " kg");
            Console.WriteLine("Altura: " + persona2.getAltura() + " m");
            Console.WriteLine("IMC: " + imc2 + " (" + mensaje2 + ")");
            Console.WriteLine("Mayor de edad: " + persona2.esMayorDeEdad());

            // Personita 3
            Persona persona3 = new Persona();
            persona3.setNombre("Juan");
            persona3.setEdad(25);
            persona3.setSexo('H');
            persona3.setPeso(70);
            persona3.setAltura(1.75);

            int imc3 = persona3.calcularIMC();
            string mensaje3 = "";

            if (imc3 == Persona.PESO_IDEAL_BAJO)
            {
                mensaje3 = "Bajo peso";
            }
            else if (imc3 == Persona.PESO_IDEAL_NORMAL)
            {
                mensaje3 = "Peso normal";
            }
            else
            {
                mensaje3 = "Sobrepeso";
            }

            Console.WriteLine("\nPersona 3:");
            Console.WriteLine("Nombre: " + persona3.getNombre());
            Console.WriteLine("Edad: " + persona3.getEdad());
            Console.WriteLine("Sexo: " + persona3.getSexo());
            Console.WriteLine("Peso: " + persona3.getPeso() + " kg");
            Console.WriteLine("Altura: " + persona3.getAltura() + " m");
            Console.WriteLine("IMC: " + imc3 + " (" + mensaje3 + ")");
            Console.WriteLine("Mayor de edad: " + persona3.esMayorDeEdad());

            Console.ReadKey();
        }
    }
}
