using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Biblioteca
{
    public class Catalogo : Ilistado<Item>
    {

        private static bool persistirPorTablas = false;

        public static bool PersistirPorTablas { get => persistirPorTablas; set => persistirPorTablas = value; }


        List<Item> listadoItems = new List<Item>();

        string ruta = "";

        public List<Item> mostrarLista()
        {
            return listadoItems;
        }

        public Catalogo()
        {
            try
            {
                ruta = Biblioteca.Archivos.LeerRutaParaArchivo("catalogos.txt");
            }
            catch(Exception)
            {
                throw;
            }
            
        }


        public void AltaNuevo(Item i)
        {
            if(i is not null)
            {
                listadoItems.Add(i);
            }
        }

        public void ModificaExistente(Item viejo, Item nuevo)
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
                catch (Exception )
                {
                    throw;
                }


            }
        }


        public void EliminarExistente(Item i)
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

        public void PersistirListado()
        {


            if (!persistirPorTablas)
            {
                Biblioteca.Serializante<List<Item>>.GuardarXML(listadoItems, ruta);
            }
            else
            {
                string insert = "";
                insert = "delete from catalogos";
                DAO.Grabar(insert.ToString());
                foreach (Item item in listadoItems)
                {
                    insert = "insert into catalogos (id,nombre,cantidad, precio) values ";
                    insert += $"({item.Id.ToString()},'{item.Nombre}',{item.Cantidad.ToString()},{item.Precio.ToString()})";
                    DAO.Grabar(insert);
                }
            }

        }


        public List<Item> LeerListaPersistida()
        {
            List<Item> devolver = null;
            try
            {


                if (!persistirPorTablas)
                {
                    if (File.Exists(ruta))
                    {
                        devolver = Biblioteca.Serializante<List<Item>>.LeerXML(ruta);
                    }
                    else
                    {
                        throw new Exception("no hay nada cargado de clientes");
                    }
                }
                else
                {

                    string select = "select id,nombre,cantidad,precio from catalogos";
                    DataTable tabla = DAO.Leer(select);
                    if (tabla.Rows.Count > 0)
                    {
                        devolver = new List<Item>();
                        int id = 0;
                        string nombre = "";
                        int cantidad = 0;
                        float precio = 0.0f;
                        foreach (DataRow fila in tabla.Rows)
                        {
                            int.TryParse(fila["id"].ToString(), out id);
                            nombre = fila["nombre"].ToString();
                            int.TryParse(fila["cantidad"].ToString(), out cantidad);
                            float.TryParse(fila["precio"].ToString(), out precio);
                            if (id > -1 && nombre != "")
                            {
                                Item nuevo = new Item(id,nombre, cantidad, precio);
                                devolver.Add(nuevo);
                            }

                        }
                    }
                }



            }
            catch (Exception)
            {
                throw;
            }
            return devolver;

        }

    }
}
