using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        public enum ETipo { CuatroPuertas, CincoPuertas }
        ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(Vehiculo.EMarca marca, string chasis, ConsoleColor color)
            : base( marca, chasis, color)
        {
            tipo = ETipo.CuatroPuertas;
        }

        public Sedan(Vehiculo.EMarca marca, string chasis, ConsoleColor color, ETipo puertas)
        : base(marca, chasis, color)
        {
            tipo = puertas;
        }

        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// necesita ser reescrita para mostrar el nombre de la clase
        /// llamar a su homónima de la base y completar con el tamaño 
        /// </summary>
        /// <returns>el string con la data a mostrar</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}      ", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo.ToString());
            sb.AppendLine("");
            sb.AppendLine("-----------------------------------------");

            return sb.ToString();
        }
    }
}
