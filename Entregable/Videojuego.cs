using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entregable
{
    class Videojuego
    {
        private string _titulo = "", _genero = "", _compania = "";
        private bool _entregado = false;
        private int _horasEstimadas = 10;

        public Videojuego()
        {
        }

        public Videojuego(string titulo, int horasEstimadas)
        {
            _titulo = titulo;
            _horasEstimadas = horasEstimadas;
        }

        public Videojuego(string titulo, int horasEstimadas, string genero, string compania)
        {
            _titulo = titulo;
            _genero = genero;
            _compania = compania;
            _horasEstimadas = horasEstimadas;
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

        public string Compania
        {
            get { return _compania; }
            set { _compania = value; }
        }
        public int HorasEstimadas
        {
            get { return _horasEstimadas; }
            set { _horasEstimadas = value; }
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
            Videojuego otro = (Videojuego)a;
            return _horasEstimadas.CompareTo(otro._horasEstimadas);
        }
    }
}
