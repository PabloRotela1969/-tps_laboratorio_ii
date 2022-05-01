using System;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// método estático que valida que el operador sea uno de los 4 permitidos, de otra forma
        /// devuelve el + por defecto
        /// </summary>
        /// <param name="operador">de tipo char</param>
        /// <returns>devuelve un char con el operador seleccionado correcto</returns>
        private static char ValidarOperador(char operador)
        {
            char devolver = '+';
            if(operador == '+' || operador == '*' || operador == '/' || operador == '-')
            {
                devolver = operador;
            }
            return devolver;
        }

        /// <summary>
        /// El metodo es estático por estar en una clase estática y permite operar entre los operandos
        /// (esto representa un error en el enunciado del TP subsanado como static)
        /// </summary>
        /// <param name="num1">primer numero de tipo operando</param>
        /// <param name="num2">segundo numero de tipo operando</param>
        /// <param name="operador">resultado de tipo double</param>
        /// <returns></returns>
        public static double Operar(Operando num1,Operando num2, char operador)
        {
            double result = 0;
            operador = ValidarOperador(operador);
            switch (operador)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '/':
                    result = num1 / num2;
                    break;
            }
            
            return result;
        }

    }
}
