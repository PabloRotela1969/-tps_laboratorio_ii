﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Taller
    {
        List<Vehiculo> vehiculos;
        int espacioDisponible;
        public enum ETipo
        {
            Moto, Automovil, Camioneta, Ciclomotor,Sedan, SUV,Todos
        }

        #region "Constructores"
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>


        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }


        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            bool flag;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            stringBuilder.AppendLine("");
            foreach (Vehiculo vehiculo in taller.vehiculos)
            {
                switch (tipo)
                {
                    case Taller.ETipo.Ciclomotor:
                        {
                            flag = vehiculo is Ciclomotor;
                            if (flag)
                            {
                                stringBuilder.AppendLine(vehiculo.Mostrar());
                            }
                            break;
                        }
                    case Taller.ETipo.Sedan:
                        {
                            flag = vehiculo is Sedan;
                            if (flag)
                            {
                                stringBuilder.AppendLine(vehiculo.Mostrar());
                            }
                            break;
                        }
                    case Taller.ETipo.SUV:
                        {
                            flag = vehiculo is Suv;
                            if (flag)
                            {
                                stringBuilder.AppendLine(vehiculo.Mostrar());
                            }
                            break;
                        }
                    default:
                        stringBuilder.AppendLine(vehiculo.Mostrar());
                        break;
                }
            }
            return stringBuilder.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {

                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v == vehiculo)
                        return taller;
                }
                if(taller.vehiculos.Count < taller.espacioDisponible)
                    taller.vehiculos.Add(vehiculo);
            
            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {

                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        taller.vehiculos.Remove(v);
                        break;
                    }
                }



            return taller;
        }

        public static bool operator ==(Taller taller, Vehiculo vehiculo)
        {
            return taller.vehiculos.Contains(vehiculo);
        }

        public static bool operator !=(Taller taller, Vehiculo vehiculo)
        {
            return !(taller == vehiculo);
        }

        #endregion
    }
}
