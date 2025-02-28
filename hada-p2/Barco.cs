using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada;

class Barco
{
    public Dictionary<Coordenada, String> CoordenadasBarcos { get; set; } //mirar a ver que pone que unicamente pone que es de lectura
    public string nombre { get; set; }
    public int NumDanyos { get; set; }

    //mirar si poner static
    public Barco(string nombre, int longitud, char orientacion, Coordenada coordenadaInicio)
    {
        this.nombre = nombre;
        this.NumDanyos = 0;

        if(orientacion == 'h')
        {
            for(int i=0; i<longitud; i++)
            {
                CoordenadasBarcos.Add(Coordenada(coordenadaInicio.fila, coordenadaInicio.columna + i), nombre);
            }
        }
        else if (orientacion == 'v')
        {
            for(int i=0; i<longitud; i++)
            {
                CoordenadasBarcos.Add(Coordenada(coordenadaInicio.fila + i, coordenadaInicio.columna), nombre);
            }
        }
    }

    public void Disparo(Coordenada c)
    {
        foreach(var cord in CoordenadasBarcos)
        {

        }
    }
}
