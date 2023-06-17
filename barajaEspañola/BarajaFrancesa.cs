using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barajaEspañola
{
    internal class BarajaFrancesa : Baraja<Carta<PalosBarFrancesa>, PalosBarFrancesa>
    {
        public BarajaFrancesa() : base(52, 13)
        {
        }

        public override void CrearBaraja()
        {
            int contador = 1;
            foreach (PalosBarFrancesa palo in Enum.GetValues(typeof(PalosBarFrancesa)))
            {
                for (int j = 1; j <= 13; j++)
                {
                    string nombreCarta = GetNombreCarta(j);
                    Carta<PalosBarFrancesa> carta = new Carta<PalosBarFrancesa>(nombreCarta, palo, true);
                    cartas[contador - 1] = carta;
                    contador++;
                }
            }
        }

        private string GetNombreCarta(int numero)
        {
            switch (numero)
            {
                case 1:
                    return "As";
                case 11:
                    return "Jota";
                case 12:
                    return "Reina";
                case 13:
                    return "Rey";
                default:
                    return numero.ToString();
            }
        }

        public bool CartaRoja(Carta<PalosBarFrancesa> c)
        {
            return c.palo == PalosBarFrancesa.Corazones || c.palo == PalosBarFrancesa.Diamantes;
        }

        public bool CartaNegra(Carta<PalosBarFrancesa> c)
        {
            return c.palo == PalosBarFrancesa.Treboles || c.palo == PalosBarFrancesa.Picas;
        }
    }
}
