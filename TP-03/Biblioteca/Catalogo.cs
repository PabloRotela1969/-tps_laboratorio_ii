using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Biblioteca
{
    public class Catalogo : Ilistado<Item>
    {
        List<Item> listadoItems = new List<Item>();

        string ruta = Biblioteca.Archivos.leerArchivoConfiguracion() + @"\catalogos.txt";

        public List<Item> mostrarLista()
        {
            return listadoItems;
        }



        public void altaNuevo(Item i)
        {
            if(i is not null)
            {
                listadoItems.Add(i);
            }
        }

        public void modificaExistente(Item viejo, Item nuevo)
        {
            bool encontrado = false;
            if (viejo is not null && nuevo is not null)
            {
                try
                {
                    for (int i = 0; i < listadoItems.Count; i++)
                    {
                        if (listadoItems[i] == viejo)
                        {
                            listadoItems[i] = nuevo;
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


        public void eliminarExistente(Item i)
        {
            if (i is not null )
            {
                try
                {
                    listadoItems.Remove(i);
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
                //Biblioteca.Serializante<List<Item>>.GuardarXML(listadoItems, @"C:\Users\MI COMPU\Documents\prueba\catalogo.txt");
                Biblioteca.Serializante<List<Item>>.GuardarXML(listadoItems, ruta);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public List<Item> leerListaPersistida()
        {
            List<Item> devolver = null;
            try
            {
                if(File.Exists(ruta))
                {
                    devolver = Biblioteca.Serializante<List<Item>>.LeerXML(ruta);
                }
                else
                {
                    throw new Exception("no hay nada cargado de items");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return devolver;

        }

    }
}
