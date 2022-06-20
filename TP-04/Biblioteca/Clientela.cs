using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
namespace Biblioteca
{
    public class Clientela : Ilistado<Cliente>
    {
        private static bool persistirPorTablas = false;



        List<Cliente> listaClientes = new List<Cliente>();
        string ruta = "";

        public  static bool PersistirPorTablas { get => persistirPorTablas; set => persistirPorTablas = value; }
        

        public List<Cliente> mostrarLista()
        {
            return listaClientes;
        }

        
        public Clientela()
        {
            try
            {
                ruta = Biblioteca.Archivos.LeerRutaParaArchivo("clientela.txt");
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void AltaNuevo(Cliente o)
        {
            if(o is not null)
            {
                this.listaClientes.Add(o);
            }
            
        }

        public void EliminarExistente(Cliente o)
        {
            if (o is not null)
            {
                this.listaClientes.Remove(o);
            }
        }

        public void ModificaExistente(Cliente viejo, Cliente nuevo)
        {
            bool encontrado = false;
            if (viejo is not null && nuevo is not null)
            {
                try
                {
                    for (int i = 0; i < listaClientes.Count; i++)
                    {
                        if (listaClientes[i] == viejo)
                        {
                            listaClientes[i] = nuevo;
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

        public void PersistirListado()
        {
            try
            {
                if(!persistirPorTablas)
                {
                    Biblioteca.Serializante<List<Cliente>>.GuardarXML(this.listaClientes, ruta);
                }
                else
                {
                    string insert = "";
                    insert = "delete from clientela";
                    DAO.Grabar(insert.ToString());
                    foreach(Cliente cliente in listaClientes)
                    {
                        insert = "insert into clientela (dni,nombre,apellido) values ";
                        insert += $"({cliente.Dni.ToString()},'{cliente.Nombre}','{cliente.Apellido}')";
                        DAO.Grabar(insert);
                    }
                }
                
            }
            catch (Exception )
            {
                throw;
            }
        }

        public List<Cliente> LeerListaPersistida()
        {
            List<Cliente> devolver = null;
            try
            {
                if(!persistirPorTablas)
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
                else
                {
                    
                    string select = "select dni,nombre,apellido from clientela";
                    DataTable tabla = DAO.Leer(select);
                    if(tabla .Rows.Count > 0)
                    {
                        devolver = new List<Cliente>();
                        int dni = 0;
                        string nombre = "";
                        string apellido = "";
                        foreach (DataRow fila in tabla.Rows)
                        {
                            int.TryParse(fila["dni"].ToString(), out dni);
                            nombre = fila["nombre"].ToString();
                            apellido = fila["apellido"].ToString();
                            if (dni > -1 && nombre != "" && apellido != "")
                            {
                                Cliente nuevo = new Cliente(dni, nombre, apellido);
                                devolver.Add(nuevo);
                            }

                        }
                    }
                }
               
            }
            catch(Exception )
            {
                throw;
            }
            return devolver;
        }
    }
}
