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

        public EventHandler<TocadoArgs> eventoTocado;
        public EventHandler<HundidoArgs> eventoHundido;

        public Barco(string nombre, int longitud, char orientacion, Coordenada coordenadaInicio)
        {
            Nombre = nombre;
            NumDanyos = 0;
            CoordenadasBarcos = new Dictionary<Coordenada, string>();

            if (orientacion == 'h')
            {
                for (int i = 0; i < longitud; i++)
                {
                    CoordenadasBarcos.Add(Coordenada(coordenadaInicio.fila, coordenadaInicio.columna + i), nombre);
                }
            }
            else if (orientacion == 'v')
            {
                for (int i = 0; i < longitud; i++)
                {
                    CoordenadasBarcos.Add(Coordenada(coordenadaInicio.fila + i, coordenadaInicio.columna), nombre);
                }
            }
        }

        public void Disparo(Coordenada c)
        {
            if(CoordenadasBarcos.ContainsKey(c))
            {
                if (!CoordenadasBarcos[c].EndsWith("_T"))
                {
                    CoordenadasBarcos[c] = CoordenadasBarcos[c] + "_T";
                    NumDanyos++;
                    //evento tocado
                    OnTocado(new TocadoArgs(Nombre, c));
                }

                if(this.Hundido())
                {
                    //evento hundido
                    OnHundido(new HundidoArgs(Nombre));
                }
            }
        }

        public bool Hundido()
        {
            bool hundido = true;
            foreach( String etiqueta in CoordenadasBarcos.Values )
            {
                if (!etiqueta.EndsWith("_T")) hundido = false;
            }

            return hundido;
        }

        public override string ToString()
        {
            string estado = this.Hundido() ? "[True]" : "[False]";
            string cadBarco = $"[{Nombre}] - DAÑOS: [{NumDanyos}] - HUNDIDO: [{estado}] - COORDENADAS: ";

            foreach(Coordenada cords in CoordenadasBarcos)
            {
                string cord = cords.ToString();
                cadBarco += $"[{cord} :{cords.Value}] ";
            }

            cadBarco += "\n";
            return cadBarco;
        }

        protected virtual void  OnTocado(TocadoArgs args)
        {
            eventoTocado?.Invoke(this, args);
        }

        protected virtual void OnHundido(HundidoArgs args)
        {
            eventoHundido?.Invoke(this, args);
        }
    }
}
