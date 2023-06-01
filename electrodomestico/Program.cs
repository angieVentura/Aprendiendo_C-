using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace electrodomestico
{
    class Electrodomesticos
    {
        protected int precioBase;
        protected string color;
        protected char consumoEnergetico;
        protected double peso;

        protected const string COLOR = "Blanco";
        protected const char CONSUMO_ENERGETICO = 'F';
        protected const int PRECIO_BASE = 100;
        protected const double PESO = 5;

        protected static readonly string[] colores = { "Blanco", "Negro", "Rojo", "Azul", "Gris" };
        protected static readonly char[] letras = "ABCDEF".ToCharArray();
        protected static readonly int[] precioConsumo = { 100, 80, 60, 50, 30, 10 };
        protected static readonly int[] precioPeso = { 10, 50, 80, 100 };


        public Electrodomesticos()
        {
            precioBase = PRECIO_BASE;
            color = COLOR;
            consumoEnergetico = CONSUMO_ENERGETICO;
            peso = PESO;
        }

        public Electrodomesticos(int precio, double peso)
        {
            precioBase = precio;
            this.peso = peso;
            color = COLOR;
            consumoEnergetico = CONSUMO_ENERGETICO;
        }

        public Electrodomesticos(int precioBase, string color, char consumoEnergetico, double peso)
        {
            this.precioBase = precioBase;
            this.peso = peso;
            ComprobarColor(color);
            ComprobarConsumoEnergetico(consumoEnergetico);
        }

        public int PrecioBase
        {
            get { return precioBase; }
        }

        public char ConsumoEnergetico
        {
            get { return consumoEnergetico; }
        }

        public string Color
        {
            get { return color; }
        }

        public double Peso
        {
            get { return peso; }
        }

        private void ComprobarConsumoEnergetico(char letra)
        {
            consumoEnergetico = Array.IndexOf(letras, letra) >= 0 ? consumoEnergetico = letra : CONSUMO_ENERGETICO;
        }

        private void ComprobarColor(string color)
        {
            this.color = Array.IndexOf(colores, color) >= 0 ? this.color = color : this.color = COLOR;
        }

        public int PrecioFinal()
        {
            int precioFinal = precioBase + precioConsumo[Array.IndexOf(letras, ConsumoEnergetico)];
            if (peso >= 0 && peso <= 19)
            {
                precioFinal += 10;
            } else if (peso >= 20 && peso <= 49)
            {
                precioFinal += 50;
            } else if (peso >= 50 && peso <= 79)
            {
                precioFinal += 80;
            } else if (precioFinal > 80)
            {
                precioFinal += 100;
            }

            return precioFinal;
        }

    } 

    class Lavadora : Electrodomesticos
    {
        protected double carga;
        protected const double CARGA = 5;

        public Lavadora() : base()
        {
            carga = CARGA;
        }

        public Lavadora(int precio, double peso) : base(precio, peso)
        {
            carga = CARGA;
        }

        public Lavadora(int precioBase, string color, char consumoEnergetico, double peso, double carga) : base(precioBase, color, consumoEnergetico, peso)
        {
            this.carga = carga;
        }

        public double Carga
        {
            get { return carga; }
        }

        public new int PrecioFinal()
        {
            int precioFinal = base.PrecioFinal();

            if (carga > 30) precioFinal += 50;
            
            return precioFinal;
        }

    }

    class Television : Electrodomesticos
    {
        protected double resolucion;
        protected bool sintonizador;

        protected const double RESOLUCION = 20;
        protected const bool SINTONIZADOR = false;

        public Television() : base()
        {
            resolucion = RESOLUCION;
            sintonizador = SINTONIZADOR;
        }

        public Television(int precio, double peso) : base(precio, peso)
        {
            resolucion = RESOLUCION;
            sintonizador = SINTONIZADOR;
        }

        public Television(int precio, string color, char consumoEnergetico, double peso, double resolucion, bool sintonizador): base(precio, color, consumoEnergetico, peso)
        {
            this.resolucion = resolucion;
            this.sintonizador = sintonizador;
        }

        public double Resolucion
        {
            get { return resolucion; }
        
        }

        public bool Sintonizador
        {
            get { return sintonizador; }
        }

        public new int PrecioFinal()
        {
            int precioFinal = base.PrecioFinal();

            if (resolucion > 40) precioFinal += (precioFinal / 100) * 30;
            if (sintonizador == true) precioFinal += 50;

            return precioFinal;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Electrodomesticos[] electrodomesticos = new Electrodomesticos[10];

            electrodomesticos[0] = new Lavadora();
            electrodomesticos[1] = new Television();
            electrodomesticos[2] = new Television(20000, 10);
            electrodomesticos[3] = new Lavadora(40000, 30);
            electrodomesticos[4] = new Television(10000, "Azul", 'D', 35, 40, true);
            electrodomesticos[5] = new Lavadora(50000, "Negro", 'A', 50, 40);
            electrodomesticos[6] = new Lavadora(45000, "Rosa", 'G', 50, 10);
            electrodomesticos[7] = new Lavadora(350, "gris", 'D', 45, 40);
            electrodomesticos[8] = new Television(550, "rojo", 'A', 30, 55, false);
            electrodomesticos[9] = new Electrodomesticos(200, "azul", 'B', 12);

            int precioL  = electrodomesticos.Where( e => e.GetType() == typeof(Lavadora)).Sum( e => e.PrecioFinal());
            int precioT = electrodomesticos.Where(e => e.GetType() == typeof(Television)).Sum(e => e.PrecioFinal());
            int precioE = electrodomesticos.Sum(e => e.PrecioFinal());

            Console.WriteLine($"Precio de todos los televisores: {precioT}");
            Console.WriteLine($"Precio de todas las lavadoras: {precioL}");
            Console.WriteLine($"Precio de todos los electrodomesticos {precioE}");
            Console.ReadKey();
        }
    }
}
