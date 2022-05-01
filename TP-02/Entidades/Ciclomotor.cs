using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        public Ciclomotor(Vehiculo.EMarca marca, string chasis, ConsoleColor color)
            : base(marca, chasis, color)
        {
        }
        
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return (ETamanio)0;
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

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
    }
}
