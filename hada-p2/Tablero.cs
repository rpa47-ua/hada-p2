using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Tablero
    {
        private int _tamTablero;
        public int TamTablero
        {
            get
            {
                return _tamTablero;
            }
            set
            {
                if (value < 4 || value > 9)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _tamTablero = value;
                }
            }
        }

        private List<Coordenada> coordenadaDisparadas;
        private List<Coordenada> coordenadasTocadas;
        private List<Barco> barcos;
        private List<Barco> barcosEliminados;
        private Dictionary<Coordenada, string> casillasTablero;

        public Tablero(int tamTablero, List<Barco> barcos)
        {
            TamTablero = tamTablero;
            this.barcos = new List<Barco>();
            this.barcos = barcos;
            coordenadaDisparadas = new List<Coordenada>();
            coordenadasTocadas = new List<Coordenada>();
            barcosEliminados = new List<Barco>();
            casillasTablero = new Dictionary<Coordenada, string>;

            inicializaCasillasTablero();
        }

        private void inicializaCasillasTablero()
        {
            //Ponemos por defecto todo el tablero lleno de agua
            for(int fila = 0; fila < TamTablero; fila++)
            {
                for(int col = 0; col < TamTablero; col++)
                {
                    Coordenada coord = new Coordenada(fila, col);
                    casillasTablero[cord] = "AGUA";
                }
            }


            //Rellenamos las coord con barcos (buscar metodo mas eficiente)
            foreach (Barco b in barcos)
            {
                foreach(Coordenada coord in b.CoordenadasBarcos.Keys)
                {
                    casillasTablero[coord] = b.Nombre;
                }
            }
        }
    }
}
