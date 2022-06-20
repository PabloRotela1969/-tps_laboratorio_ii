using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Biblioteca
{
    public static class Serializante <T> where T : class 
    {
        /// <summary>
        /// Permite grabar en archivos XML el estado de listas con sus objetos
        /// </summary>
        /// <param name="objeto"></param>
        /// <param name="ruta"></param>
        public static void GuardarXML(T objeto, string ruta)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(ruta))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(escritor, objeto);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Permite leer lo persistido en archivos xml
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns></returns>
        public static T LeerXML(string ruta)
        {
            try
            {
                using (StreamReader lector = new StreamReader(ruta))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    return serializador.Deserialize(lector) as T;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
