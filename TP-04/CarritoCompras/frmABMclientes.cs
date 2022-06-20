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
    public partial class frmClientes : Form
    {
        Clientela clientes;
        Cliente? seleccionado;

        public frmClientes()
        {
            InitializeComponent();
            clientes = new Clientela();
            this.prgCarga.Value = 0;
            CargarListaInicial();
            ActualizarLista();
            this.prgCarga.Value = 100;
        }


        private void btnAlta_Click(object sender, EventArgs e)
        {
            int dni = 0;
            if(txtDNI.Text != "" && txtNombre.Text != "" && txtApellido.Text != "")
            {
                try
                {
                    this.prgCarga.Value = 0;
                    int.TryParse(txtDNI.Text, out dni);
                    Cliente nuevo = new Cliente(dni, txtNombre.Text, txtApellido.Text);
                    clientes.AltaNuevo(nuevo);
                    clientes.PersistirListado();
                    this.prgCarga.Value = 50;
                    ActualizarLista();
                    LimpiarCamposYSeleccionado();
                    txtNombre.Focus();
                    this.prgCarga.Value = 100;
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error al dar el alta a un nuevo cliente {ex.Message}");
                }
                
            }
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            int dni = 0;
            if (seleccionado is not null)
            {
                if(txtDNI.Text != "" && txtNombre.Text != null && txtApellido.Text != "")
                {
                    try
                    {
                        this.prgCarga.Value = 0;
                        int.TryParse(txtDNI.Text, out dni);
                        Cliente nuevo = new Cliente(dni, txtNombre.Text, txtApellido.Text);
                        clientes.ModificaExistente(seleccionado, nuevo);
                        clientes.PersistirListado();
                        this.prgCarga.Value = 50;
                        ActualizarLista();
                        LimpiarCamposYSeleccionado();
                        this.btnAlta.Enabled = true;
                        this.prgCarga.Value = 100;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al modificar un cliente {ex.Message}");
                    }

                }
                else
                {
                    MessageBox.Show("Sirvase llenar todos los campos");
                }

            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (seleccionado is not null)
            {
                try
                {
                    this.prgCarga.Value = 0;
                    clientes.EliminarExistente(seleccionado);
                    clientes.PersistirListado();
                    this.prgCarga.Value = 50;
                    ActualizarLista();
                    LimpiarCamposYSeleccionado();
                    this.btnAlta.Enabled = true;
                    this.prgCarga.Value = 100;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al borrar un cliente {ex.Message} ");
                }

            }
        }

        private void lstClientes_DoubleClick(object sender, EventArgs e)
        {
            seleccionado = lstClientes.SelectedItem as Cliente;
            this.btnAlta.Enabled = false;
            if (seleccionado is not null)
            {
                try
                {
                    this.txtDNI.Text = seleccionado.Dni.ToString();
                    this.txtNombre.Text = seleccionado.Nombre;
                    this.txtApellido.Text = seleccionado.Apellido;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al traer los datos desde la lista a los campos {ex.Message} ");
                }
            }
        }



        private void btnBorrar_Click(object sender, EventArgs e)
        {
            LimpiarCamposYSeleccionado();
        }

        private void LimpiarCamposYSeleccionado()
        {
            seleccionado = null;
            this.txtDNI.Text = "";
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
        }
        private void ActualizarLista()
        {
            try
            {
                this.lstClientes.Items.Clear();
                foreach (Cliente c in clientes.mostrarLista())
                {
                    this.lstClientes.Items.Add(c);
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error al actualizar lista de clientes {e.Message}");
            }
            
        }

        private void CargarListaInicial()
        {
            try
            {
                List<Cliente> listaLeida = clientes.LeerListaPersistida();
                this.prgCarga.Value = 40;
                if (listaLeida != null )
                {
                    clientes.mostrarLista().AddRange(listaLeida);
                    this.prgCarga.Value = 60;
                }
                else
                {
                    MessageBox.Show("No hay datos en tablas para mostrar");
                }
                
            }
            catch(Exception e)
            {
                MessageBox.Show($"Excepcion al cargar lista inicial {e.Message} {e.InnerException}");
            }
        }
    }
}
