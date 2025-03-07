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
            barcos.Add(new Barco("THOR", 1, 'h', new Coordenada(0, 0)));
            barcos.Add(new Barco("LOKI", 2, 'v', new Coordenada(1, 2)));
            barcos.Add(new Barco("MAYA", 3, 'h', new Coordenada(3, 1)));
            tablero = new Tablero(4, barcos);
            tablero.eventoFinPartida += cuandoEventoFinPartida;
            while (!finPartida)
            {
                Console.WriteLine(tablero.ToString());  // Mostramos el estado actual del tablero.


                Console.Write("Introduce una coordenada (fila,columna) o 's' para salir: ");
                string input = Console.ReadLine();


                if (input.ToLower() == "s")
                {
                    finPartida = true;
                    Console.WriteLine("La partida ha sido finalizada por el usuario.");
                    break;
                }


                if (validarCoordenada(input, out Coordenada coordenada))
                {

                    tablero.Disparar(coordenada);
                }
                else
                {
                    Console.WriteLine("Coordenada no válida. Asegúrate de introducir el formato correcto.");
                }
            }
        }
        private bool validarCoordenada(string input, out Coordenada coordenada)
        {
            coordenada = null;


            if (input.Length == 3)
            {

                if (input[1] == ',')
                {

                    if (int.TryParse(input[0].ToString(), out int fila) && int.TryParse(input[2].ToString(), out int columna))//mirar esto
                    {
                        coordenada = new Coordenada(fila, columna);
                        return true;
                    }
                }
            }


            return false;
        }

        private void cuandoEventoFinPartida(object sender, EventArgs e)
        {
            Console.WriteLine("¡¡PARTIDA FINALIZADA!!");
            finPartida = true;
        }

    }
}