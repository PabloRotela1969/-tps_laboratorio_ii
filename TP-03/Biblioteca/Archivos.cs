using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Environment;

namespace Biblioteca
{
    public static class Archivos
    {

        public static string leerArchivoConfiguracion()
        {
            string ruta = Directory.GetCurrentDirectory();
            ruta += @"\configuracion.txt";
            return Leer(ruta);
        }

        public static void Guardar(string contenido, string ruta)
        {
            try
            {
                using(StreamWriter escritor = new StreamWriter(ruta))
                {
                    escritor.WriteLine(contenido);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public static string Leer(string ruta)
        {
            try
            {
                using (StreamReader lector = new StreamReader(ruta))
                {
                    return lector.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
