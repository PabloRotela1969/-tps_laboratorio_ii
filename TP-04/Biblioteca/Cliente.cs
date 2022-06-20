using System;
using System.Collections.Generic;

namespace Biblioteca
{
    public class Cliente 
    {
        int dni;
        string nombre;
        string apellido;

        List<Item> bandeja = new List<Item>();

        public List<Item> Bandeja
        { get { return bandeja; } }


        public Cliente() { }
        public Cliente(int dni, string nombre, string apellido)
        {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        public int Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }

        public override string ToString()
        {
            return this.Nombre + " " + this.Apellido;
        }
        
        public static bool operator ==(Cliente uno, Cliente dos)
        {
            return uno.Dni == dos.Dni;
        }
        public static bool operator !=(Cliente uno, Cliente dos)
        {
            return !(uno == dos);
        }
        
    }
}
