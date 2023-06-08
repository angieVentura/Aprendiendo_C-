using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ruletaRusa
{
    internal class Revolver
    {
        public int posicionRevolver;
        public int posicionBala;
        static Random rand = new Random();

        public Revolver()
        {
            posicionRevolver = rand.Next(6);
            posicionBala = rand.Next(6);
        }

        public bool DispararRe()
        {
            return posicionBala == posicionRevolver;
        }

        public void SiguienteBala()
        {
            posicionRevolver = (posicionRevolver + 1) % 6;
        }
    }
}
