using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Barco
    {

        public Dictionary<Coordenada, String> CoordenadasBarcos { get; private set; }
        public string Nombre { get; set; }
        public int NumDanyos { get; set; }

        public event EventHandler<TocadoArgs> eventoTocado;
        public event EventHandler<HundidoArgs> eventoHundido;

        public Barco(string nombre, int longitud, char orientacion, Coordenada coordenadaInicio)
        {
            Nombre = nombre;
            NumDanyos = 0;
            CoordenadasBarcos = new Dictionary<Coordenada, String>();

            if (orientacion == 'h')
            {
                for (int i = 0; i < longitud; i++)
                {
                    CoordenadasBarcos.Add(new Coordenada(coordenadaInicio.Fila, coordenadaInicio.Columna + i), nombre);
                }
            }
            else if (orientacion == 'v')
            {
                for (int i = 0; i < longitud; i++)
                {
                    CoordenadasBarcos.Add(new Coordenada(coordenadaInicio.Fila + i, coordenadaInicio.Columna), nombre);
                }
            }
        }

        public void Disparo(Coordenada c)
        {
            if (CoordenadasBarcos.ContainsKey(c))
            {
                if (!CoordenadasBarcos[c].EndsWith("_T"))
                {
                    CoordenadasBarcos[c] = CoordenadasBarcos[c] + "_T";
                    NumDanyos++;
                    //evento tocado (repasasr)
                    eventoTocado?.Invoke(this, new TocadoArgs(Nombre, c));

                }

                if (this.Hundido())
                {
                    //evento hundido
                    eventoHundido?.Invoke(this, new HundidoArgs(Nombre));
                }
            }
        }

        public bool Hundido()
        {
            bool hundido = true;
            foreach (String etiqueta in CoordenadasBarcos.Values)
            {
                if (!etiqueta.EndsWith("_T")) hundido = false;
            }

            return hundido;
        }

        public override string ToString()
        {
            string estado = this.Hundido() ? "[True]" : "[False]";
            string cadBarco = $"[{Nombre}] - DAÑOS: [{NumDanyos}] - HUNDIDO: {estado} - COORDENADAS: ";

            foreach (KeyValuePair<Coordenada, String> coord in CoordenadasBarcos)
            {
                cadBarco += $"[{coord.Key.ToString()} :{coord.Value}] ";
            }

            cadBarco += "\n";
            return cadBarco;
        }
    }
}