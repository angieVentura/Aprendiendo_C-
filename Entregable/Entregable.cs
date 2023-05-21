using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregable
{
    interface Entregable
    {
        void Entregar();
        void Devolver();
        bool IsEntregado();
        int CompareTo(Object a);
    }
}
