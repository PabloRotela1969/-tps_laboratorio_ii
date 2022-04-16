using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        /// <summary>
        /// propiedad del operando
        /// (como el enunciado del TP tiene el error de pedir método de clase en una 
        /// clase estática, supuse que la falta de un get sería otro error, entonces lo incluí)
        /// </summary>
        private double Numero 
        {
            get
            { return numero; }
            set
            {
                this.numero = ValidarOperando(value.ToString());
                    
            } 
        }

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Operando() : this(0)
        {

        }
        /// <summary>
        /// primer sobrecarga del constructor
        /// </summary>
        /// <param name="numero">para un double</param>
        public Operando(double numero)
        {
            this.Numero = numero;
        }

        /// <summary>
        /// segunda sobrecarga del constructor
        /// </summary>
        /// <param name="strNumero">caso que sea un string</param>
        public Operando(string strNumero)
        {
            double numeroDoble = 0;
            double.TryParse(strNumero, out numeroDoble);
            this.Numero = numeroDoble;
        }

        /// <summary>
        /// verifica que se trate de un número 
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>devuelve 0 si no es, sino el double equivalente</returns>
        private double ValidarOperando(string strNumero)
        {
            double retornar = 0;        
            double.TryParse(strNumero, out retornar);
            return retornar;
        }

        /// <summary>
        /// verifica que el string contenga solo unos y ceros
        /// </summary>
        /// <param name="binario">el string a evaluar</param>
        /// <returns>true si es binario, false caso contrario</returns>
        private bool EsBinario(string binario)
        {
            bool devolver = true;
            foreach(char caracter in binario)
            {
                if (caracter != '1' && caracter != '0')
                {
                    devolver = false;
                    break;
                }
            }
            return devolver;
        }

        /// <summary>
        /// toma un binario y lo combierte usando las potencias de cada posición
        /// </summary>
        /// <param name="binario">ingresa el binario en formato string</param>
        /// <returns>devuelve el número decimal equivalente</returns>
        public string BinarioDecimal(string binario)
        {
            string strNumero = "";
            int potencia = 1;
            int acumulado = 0;
            int digito = 0;
            if (EsBinario(binario))
            {
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    digito = int.Parse(binario.Substring(i, 1));
                    acumulado += digito * potencia;
                    potencia *= 2;
                }
                strNumero = acumulado.ToString();
            }
            else
            {
                strNumero = "Valor inválido";
            }
            return strNumero;

        }

        /// <summary>
        /// permite pasar la parte entera de un número decimal a binario
        /// </summary>
        /// <param name="numero">numero en formato double</param>
        /// <returns>retorna una cadena de unos y ceros equivalentes en binario
        /// </returns>
        public string DecimalBinario(double numero)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder devolver = new StringBuilder();
            int numeroInt = (int)numero;
            int resultadoParcial = numeroInt;
            do
            {
                resultadoParcial = numeroInt % 2;
                numeroInt = numeroInt / 2;
                sb.Append(resultadoParcial);
            }
            while (numeroInt > 0);

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                devolver.Append(sb[i].ToString());
            }
            return devolver.ToString();
        }

        /// <summary>
        /// sobrecarga del metodo DecimalBinario que recibe el número como cadena y lo transforma a binario
        /// </summary>
        /// <param name="numero">numero como string</param>
        /// <returns>cadena en binario que representa al numero decimal</returns>
        public string DecimalBinario(string numero)
        {
            double dblNumero = 0.0;
            double.TryParse(numero, out dblNumero);
            return DecimalBinario(dblNumero);
        }

        /// <summary>
        /// sobrecarga del operador resta
        /// </summary>
        /// <param name="n1">minuendo</param>
        /// <param name="n2">sustraendo</param>
        /// <returns>resta</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.Numero - n2.Numero;
        }

        /// <summary>
        /// sobrecarga del operador suma
        /// </summary>
        /// <param name="n1">perimer numero</param>
        /// <param name="n2">segundo numero</param>
        /// <returns>suma</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.Numero + n2.Numero;
        }

        /// <summary>
        /// sobrecarga del operador division
        /// </summary>
        /// <param name="n1">numerador</param>
        /// <param name="n2">denominador</param>
        /// <returns>division</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            return n1.Numero / n2.Numero;
        }

        /// <summary>
        /// sobrecarga del operador multiplicación
        /// </summary>
        /// <param name="n1">primer numero</param>
        /// <param name="n2">segundo numero</param>
        /// <returns>producto</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.Numero * n2.Numero;
        }


    }
}
