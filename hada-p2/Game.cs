using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    public class Game
    {
        private bool finPartida;
        private Tablero tablero;
        private List<Barco> barcos;

        public Game()
        {
            finPartida = false;
            barcos = new List<Barco>();
            gameLoop();  // Llamamos al bucle del juego desde el constructor.
        }
        private void gameLoop()
        {
            barcos.Add(new Barco("Barco1", 3, 'h', new Coordenada(0, 0)));
            barcos.Add(new Barco("Barco2", 4, 'v', new Coordenada(2, 3)));
            barcos.Add(new Barco("Barco3", 2, 'h', new Coordenada(5, 5)));
            tablero = new Tablero(10, barcos);
            tablero.eventoFinPartida += cuandoEventoFinPartida;
        }

    }
