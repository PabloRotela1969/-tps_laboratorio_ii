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

        public static string RutaParaArchivoConfiguracion()
        {
            string ruta = LeerRutaEnDllsDeArchivo("configuracion.txt");
            return Leer(ruta);
        }

        public static string LeerArchivo(string archivo)
        {
            string ruta = RutaParaArchivoConfiguracion();
            ruta += @"\" + archivo;
            return Leer(ruta);
        }

        public static string LeerRutaEnDllsDeArchivo(string archivo)
        {
            return Directory.GetCurrentDirectory() + @"\" + archivo;
        }

        public static string LeerArchivoCadenaConexion()
        {
            string ruta = Directory.GetCurrentDirectory();
            ruta += @"\cadena.txt";
            return Leer(ruta);
        }


        public static string LeerRutaParaArchivo(string archivo)
        {
            return RutaParaArchivoConfiguracion() + @"\" + archivo;
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
            catch (Exception)
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
            catch (Exception)
            {
                throw;
            }
        }

    }
}
