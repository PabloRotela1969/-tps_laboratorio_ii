using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Biblioteca
{
    public class Clientela : Ilistado<Cliente>
    {
        List<Cliente> lista = new List<Cliente>();
        string ruta = Biblioteca.Archivos.leerArchivoConfiguracion() + @"\clientela.txt";
        public List<Cliente> mostrarLista()
        {
            return lista;
        }


        public void altaNuevo(Cliente o)
        {
            if(o is not null)
            {
                this.lista.Add(o);
            }
            
        }

        public void eliminarExistente(Cliente o)
        {
            if (o is not null)
            {
                this.lista.Remove(o);
            }
        }

        public void modificaExistente(Cliente viejo, Cliente nuevo)
        {
            bool encontrado = false;
            if (viejo is not null && nuevo is not null)
            {
                try
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (lista[i] == viejo)
                        {
                            lista[i] = nuevo;
                            encontrado = true;
                            break;

                        }
                    }
                    if (!encontrado)
                    {
                        throw new Exception("No se encontró el elemento a reemplazar en la lista");
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public void persistirListado()
        {
            try
            {
                Biblioteca.Serializante<List<Cliente>>.GuardarXML(this.lista, ruta);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Cliente> leerListaPersistida()
        {
            List<Cliente> devolver = null;
            try
            {
                if (File.Exists(ruta))
                {
                    devolver = Biblioteca.Serializante<List<Cliente>>.LeerXML(ruta);
                }
                else
                {
                    throw new Exception("no hay nada cargado de clientes");
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return devolver;
        }
    }
}
