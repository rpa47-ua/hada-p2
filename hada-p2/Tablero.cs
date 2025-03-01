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

        public event EventHandler<EventArgs> eventoFinPartida;

        public Tablero(int tamTablero, List<Barco> barcos)
        {
            TamTablero = tamTablero;
            this.barcos = new List<Barco>();
            this.barcos = barcos;
            coordenadaDisparadas = new List<Coordenada>();
            coordenadasTocadas = new List<Coordenada>();
            barcosEliminados = new List<Barco>();
            casillasTablero = new Dictionary<Coordenada, string>();

            inicializaCasillasTablero();
        }

        private void inicializaCasillasTablero()
        { //Mirar si es < o <= 
            //Ponemos por defecto todo el tablero lleno de agua
            for(int fila = 0; fila < TamTablero; fila++)
            {
                for(int col = 0; col < TamTablero; col++)
                {
                    Coordenada coord = new Coordenada(fila, col);
                    casillasTablero[coord] = "AGUA";
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

        public void Disparar(Coordenada c)
        {//Mirar si es > i >= 
            if(c.Fila < 0 || c.Fila > TamTablero || c.Columna < 0 || c.Columna > TamTablero)
            { //repasar tema del ToString Coordenada
                Console.WriteLine($"La coordenada {c.ToString()} está fuera de las dimensiones del tablero");
            }
            else
            {
                foreach(Barco b in barcos)
                {
                    b.Disparo(c);
                }
            }

        }

        public string DibujarTablero()
        {//mirar tema de dimensiones
            string tablero = "";
            int i = 1;
            
            foreach(var coord in casillasTablero)
            {

                tablero += $"[{coord.Value}]";
                if(i==TamTablero)
                {
                    tablero += "\n";
                    i = 0;
                }
                
                i++; 
            }
        }

        public override string ToString()
        {
            string info = "";
            foreach(Barco b in barcos)
            {
                info += b.ToString();
            }

            info += "Coordenadas disparadas: ";
            foreach(Coordenadas coord in coordenadaDisparadas)
            {
                info += coord.ToString();
            }
            // mirar a ver si hace falta \n
            info += "Coordenadas tocadas: ";
            foreach(Coordenadas coord in coordenadasTocadas)
            {
                info += coord.ToString();
            }

            info += "\n\n\n";
            info += "CASILLAS TABLERO\n";
            info += "-------\";
            info += DibujarTablero();

            return info;
        }

        private void cuandoEventoTocado(object sender, TocadoArgs e)
        {
        }

        private void cuandoEventoHundido(object sender, HundidoArgs e)
        {
        }
    }
}
