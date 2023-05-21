using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregable
{
    class Serie
    {
        private string _titulo = "", _genero = "", _creador = "";
        private int _numDeTem = 3;
        private bool _entregado = false;

        public Serie()
        {

        }

        public Serie(string titulo, string creador)
        {
            _titulo = titulo;
            _creador = creador;
        }

        public Serie(string titulo, int numDeTem, string genero, string creador)
        {
            _titulo = titulo;
            _creador = creador;
            _genero = genero;
            _numDeTem = numDeTem;
        }

        public string Titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        public string Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        public string Creador
        {
            get { return _creador; }
            set { _creador = value; }
        }

        public int NumDeTem
        {
            get { return _numDeTem; }
            set { _numDeTem = value; }
        }

        public void Entregar()
        {
            _entregado = true;
        }

        public void Devolver()
        {
            _entregado = false;
        }

        public bool IsEntregado()
        {
            return _entregado;
        }

        public int CompareTo(Object a)
        {
            Serie otro = (Serie)a;
            return _numDeTem.CompareTo(otro.NumDeTem);
        }
    }
}
