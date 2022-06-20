using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace CarritoCompras
{
    public partial class frmAsignar : Form
    {
        List<Cliente> clienteList = null; 
        List<Item> itemList = null; 
        List<Cliente> comprador = null;

        Catalogo catalogo = null;
        Clientela clientes = null;
        Cliente? clienteSeleccionado = null;
        public frmAsignar()
        {
            InitializeComponent();
            try
            {
                catalogo = new Catalogo();
                clientes = new Clientela();
                comprador = new List<Cliente>();
                itemList = catalogo.LeerListaPersistida();
                clienteList = clientes.LeerListaPersistida();
                CargarListaClientes();
                CargarListaItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error mientras levantaba el formulario asignar {ex.Message} {ex.InnerException}");
            }
            
            
        }

        /// <summary>
        /// Carga la lista de clientes
        /// </summary>
        private void CargarListaClientes()
        {
            try
            {
                lstClientes.Items.Clear();
                foreach (Cliente cliente in clienteList)
                {
                    lstClientes.Items.Add(cliente);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"Excepcion : {e.Message}");
            }
            
        }

        /// <summary>
        /// Carga la lista de items
        /// </summary>
        private void CargarListaItems()
        {
            try
            {
                lstItems.Items.Clear();
                foreach (Item item in itemList)
                {
                    lstItems.Items.Add(item);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"Excepcion : {e.Message}");
            }
            
        }





        /// <summary>
        /// Permite elegir un cliente de la lista y cargarlo en el campo de asignaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstClientes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clienteSeleccionado = lstClientes.SelectedItem as Cliente;
                if (clienteSeleccionado is not null)
                {
                    this.lstClientE.Items.Add(clienteSeleccionado);
                    this.clienteList.Remove(clienteSeleccionado);
                    this.lstClientes.Items.Remove(clienteSeleccionado);
                    this.lstClientes.Enabled = false;
                    this.lstClientE.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el cliente de lista y pasarlo al campo de cliente para agregarle items {ex.Message}");
            }



        }

        /// <summary>
        /// Permite devolver el cliente a la lista de clientes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstClientE_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (clienteSeleccionado is not null)
                {
                    clienteList.Add(clienteSeleccionado);
                    clienteSeleccionado = null;
                    CargarListaClientes();
                    this.lstClientE.Items.Clear();
                    this.lstClientE.Enabled = false;
                    this.lstClientes.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al devolver el cliente a la lista de clientes desde el campo para asignarle items {ex.Message}");
            }

        }

     



        private void lstItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Item? itemSeleccionado = lstItems.SelectedItem as Item;
                if (clienteSeleccionado is not null && itemSeleccionado is not null)
                {
                    this.lstItemsAsignados.Items.Add(itemSeleccionado);
                    this.lstItemsAsignados.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar items desde la lista de items a la lista de items seleccionados {ex.Message}");
            }

        }

        private void lstItemsAsignados_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Item? seleccionado = lstItemsAsignados.SelectedItem as Item;
                if (seleccionado is not null)
                {
                    this.lstItemsAsignados.Items.Remove(seleccionado);
                    this.lstItems.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al deseleccionar items desde la lista de items seleccionados {ex.Message}");
            }

        }

        public void persistirListadoClientesConCompra()
        {
            try
            {
                string ruta = Archivos.LeerRutaParaArchivo("clientesConCompras.txt");
                Biblioteca.Serializante<List<Cliente>>.GuardarXML(this.comprador, ruta);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error al guardar la lista de clientes con compras {ex.Message} : {ex.InnerException}");
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(clienteSeleccionado is not null )
                {
                        
                    if (this.lstItemsAsignados.Items.Count > 0)
                    {
                            
                        foreach (Item item in this.lstItemsAsignados.Items)
                        {
                            clienteSeleccionado.Bandeja.Add(item);
                        }
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"Cliente : {clienteSeleccionado.ToString()} \n Compró : ");
                        comprador.Add(clienteSeleccionado);
                        clienteSeleccionado = null;
                        persistirListadoClientesConCompra();
                        this.lstClientE.Items.Clear();
                        foreach(Item item in this.lstItemsAsignados.Items)
                        {
                            sb.AppendLine(item.ToString());
                        }
                        this.lstItemsAsignados.Items.Clear();
                        MessageBox.Show($"{sb.ToString()}", "INFORMACION", MessageBoxButtons.OK);
                        this.lstClientes.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Seleccione items desde la lista de Items", "AVISO", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un cliente desde la lista de Clientes","AVISO",MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cuardar un cliente con sus items seleccionados : {ex.Message} : {ex.InnerException}");
            }
        }

    }
}
