using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barajaEspañola
{
    internal class BarajaEspañola : Baraja<Carta<PalosBarEspañola>, PalosBarEspañola>
    {
        private bool incluirOchoNueve;

        public BarajaEspañola(bool incluirOchoNueve) : base(incluirOchoNueve ? 48 : 40, 10)
        {
            this.incluirOchoNueve = incluirOchoNueve;
        }

        public override void CrearBaraja()
        {
            int contador = 1;
            foreach (PalosBarEspañola palo in Enum.GetValues(typeof(PalosBarEspañola)))
            {
                for (int j = 1; j <= 12; j++)
                {
                    if (incluirOchoNueve || (j != 8 && j != 9))
                    {
                        string nombreCarta = GetNombreCarta(j);
                        Carta<PalosBarEspañola> carta = new Carta<PalosBarEspañola>(nombreCarta, palo, true);
                        cartas[contador - 1] = carta;
                        contador++;
                    }
                }
            }
        }

        private string GetNombreCarta(int numero)
        {
            switch (numero)
            {
                case 1:
                    return "As";
                case 10:
                    return "Sota";
                case 11:
                    return "Caballo";
                case 12:
                    return "Rey";
                default:
                    return numero.ToString();
            }
        }
    }
}
