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
        List<Cliente> clienteList; // borrar
        List<Item> itemList; // borrar
        List<Cliente> comprador;

        Catalogo catalogo;
        Clientela clientes;
        Cliente? clienteSeleccionado;
        public frmAsignar()
        {
            InitializeComponent();
            catalogo = new Catalogo();
            clientes = new Clientela();
            comprador = new List<Cliente>();
            itemList = catalogo.leerListaPersistida();
            clienteList = clientes.leerListaPersistida();
            
            
            cargarListaClientes();
            cargarListaItems();
        }

        private void cargarListaClientes()
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

        private void cargarListaItems()
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




        private void lstClientes_DoubleClick(object sender, EventArgs e)
        {
            clienteSeleccionado = lstClientes.SelectedItem as Cliente;
            if(clienteSeleccionado is not null)
            {

                this.lstClientE.Items.Add(clienteSeleccionado);
                this.clienteList.Remove(clienteSeleccionado);
                this.lstClientes.Items.Remove(clienteSeleccionado);
                this.lstClientes.Enabled = false;
                this.lstClientE.Enabled = true;
            }
        }

        private void lstClientE_DoubleClick(object sender, EventArgs e)
        {
            if (clienteSeleccionado is not null)
            {
                clienteList.Add(clienteSeleccionado);
                clienteSeleccionado = null;
                cargarListaClientes();
                this.lstClientE.Items.Clear();
                this.lstClientE.Enabled = false;
                this.lstClientes.Enabled = true;
            }
        }

     



        private void lstItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Item? itemSeleccionado = lstItems.SelectedItem as Item;
            if (clienteSeleccionado is not null && itemSeleccionado is not null)
            {
                this.lstItemsAsignados.Items.Add(itemSeleccionado);
                this.lstItemsAsignados.Enabled = true;

            }
        }

        private void lstItemsAsignados_DoubleClick(object sender, EventArgs e)
        {
            Item? seleccionado = lstItemsAsignados.SelectedItem as Item;
            if (seleccionado is not null)
            {
                this.lstItemsAsignados.Items.Remove(seleccionado);
                this.lstItemsAsignados.Enabled = false;
                this.lstItems.Enabled = true;
            }
        }

        public void persistirListadoClientesConCompra()
        {
            try
            {
                string ruta = Archivos.leerArchivoConfiguracion() + @"\clientesConCompras.txt";
                Biblioteca.Serializante<List<Cliente>>.GuardarXML(this.comprador, ruta);
            }
            catch
            {
                throw;
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
                        comprador.Add(clienteSeleccionado);
                        clienteSeleccionado = null;
                        persistirListadoClientesConCompra();
                        this.lstClientE.Items.Clear();
                        this.lstItemsAsignados.Items.Clear();
                        MessageBox.Show("cliente asignado", "INFORMACION", MessageBoxButtons.OK);
                        this.lstClientes.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Seleccione items desde la lista de Items");
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un cliente desde la lista de Clientes");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excepcion : {ex.Message}");
            }
        }

    }
}
