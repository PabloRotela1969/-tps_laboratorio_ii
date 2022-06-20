using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Item 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }

        public float Precio { get; set; }

        public Item() { }
        public Item (int id, string nombre, int cantidad, float precio)
        {
            Id = id;
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
        }
        public static bool operator ==(Item uno, Item dos)
        {
            return uno.Id == dos.Id && uno.Nombre == dos.Nombre;
        }
        public static bool operator !=(Item uno, Item dos)
        {
            return !(uno == dos);
        }

        public override string ToString()
        {
            return String.Format("{0,-3}{1,-10:C}{2,-5:F}{3,-4:D}",this.Id,this.Nombre,this.Precio,this.Cantidad);
        }

    }
}
