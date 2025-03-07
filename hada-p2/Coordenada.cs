﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    public class Coordenada
    {
        private int fila;
        private int columna;
        public int Fila
        {
            get { return fila; }
            set
            {
                if (value < 0 || value > 9)
                    throw new ArgumentOutOfRangeException("Fila debe estar entre 0 y 9.");
                fila = value;
            }
        }
        public int Columna
        {
            get { return columna; }
            set
            {
                if (value < 0 || value > 9)
                    throw new ArgumentOutOfRangeException("Columna debe estar entre 0 y 9.");
                else // AÑADIDO
                {
                    columna = value;
                }
            }
        }
        public Coordenada()
        {
            Fila = 0;
            Columna = 0;
        }
        public Coordenada(int fila, int columna)
        {
            Fila = fila;
            Columna = columna;
        }
        public Coordenada(Coordenada coordenada)
        {
            Fila = coordenada.Fila;
            Columna = coordenada.Columna;
        }
        public Coordenada(string fila, string columna)
        {
            Fila = int.Parse(fila);
            Columna = int.Parse(columna);
        }
        public override string ToString()
        {
            return $"({Fila},{Columna})";
        }
        public override int GetHashCode()
        {
            return this.Fila.GetHashCode() ^ Columna.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Coordenada))
                return false;

            Coordenada coordenada = (Coordenada)obj;
            return this.Fila == coordenada.Fila && this.Columna == coordenada.Columna;
        }
        public bool Equals(Coordenada coordenada)
        {
            if (coordenada == null)
                return false;

            return this.Fila == coordenada.Fila && this.Columna == coordenada.Columna;
        }
    }
}