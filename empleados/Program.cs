using System;
using System.Collections.Generic;

namespace empleados
{
    class Empleado
    {
        protected string nombre;
        protected int edad;
        protected double salario;
        protected const double PLUS = 300;

        protected Empleado(string nombre, int edad, double salario)
        {
            this.edad = edad;
            this.salario = salario;
            this.nombre = nombre;
        }

        protected string SetNombre
        {
            set { nombre = value; }
        }

        public string GetNombre
        {
            get { return nombre; }
        }

        public int SetEdad
        {
            set { edad = value; }
        }

        public int GetEdad
        {
            get { return edad; }
        }

        public double SetSalario
        {
            set { salario = value; }
        }

        public double GetSalario
        {
            get { return salario; }
        }

        public virtual void Plus()
        {

        }

        public virtual string Mostrar()
        {
            return null;
        }

    }

    class Comercial : Empleado
    {
        public double comision;

        public Comercial(string nombre, int edad, double salario, double comision) : base(nombre, edad, salario)
        {
            this.comision = comision;
        }

        protected double SetComision
        {
            set { comision = value; }
        }

        public double GetComision
        {
            get { return comision; }
        }

        public override void Plus()
        {
            if (edad > 30 && comision > 200) salario += PLUS;
        }

        public override string Mostrar()
        {
            return $"Comercial: {nombre}, Edad: {edad}, Salario: {salario}, Comision: {comision}";
        }

    }

    class Repartidor : Empleado
    {
        public string zona;

        public Repartidor(string nombre, int edad, double salario, string zona) : base(nombre, edad, salario)
        {
            this.zona = zona;
        }

        protected string SetZona
        {
            set { zona = value; }
        }

        public string GetZona
        {
            get { return zona; }
        }

        public override void Plus()
        {
            if (edad > 25 && zona == "zona 3") salario += PLUS;
        }

        public override string Mostrar()
        {
            return $"Repartidor: {nombre}, Edad: {edad}, Salario: {salario}, Zona: {zona}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string[] nombres = { "Juan", "María", "Carlos", "Ana", "Pedro", "Laura", "Luis", "Sofía", "Andrés", "Lucía" };
            string[] zonas = { "zona 1", "zona 2", "zona 3", "zona 4", "zona 5", "zona 6", "zona 7", "zona 8", "zona 9", "zona 10" };

            List<Empleado> empleados = new List<Empleado>
            {
                new Comercial(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2)),
                new Comercial(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2)),
                new Comercial(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2)),
                new Comercial(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2)),
                new Repartidor(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), zonas[rand.Next(zonas.Length)]),                
                new Repartidor(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), zonas[rand.Next(zonas.Length)]),                
                new Repartidor(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), zonas[rand.Next(zonas.Length)]),                
                new Repartidor(nombres[rand.Next(nombres.Length)], rand.Next(18, 66), Math.Round(rand.NextDouble() * (400.50 - 250) + 250, 2), zonas[rand.Next(zonas.Length)])
            };

            empleados.ForEach( emp => Console.WriteLine(emp.Mostrar()));
            Console.WriteLine($"\nPlus:\n");
            empleados.ForEach(emp => { emp.Plus(); Console.WriteLine(emp.Mostrar()); });

            Console.ReadKey();
        }
    }
}
