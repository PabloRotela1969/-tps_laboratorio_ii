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
