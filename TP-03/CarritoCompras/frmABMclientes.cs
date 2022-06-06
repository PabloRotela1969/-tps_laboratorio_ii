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
            CargarListaInicial();
            ActualizarLista();
        }

        


        private void btnAlta_Click(object sender, EventArgs e)
        {
            int dni = 0;
            if(txtDNI.Text != "" && txtNombre.Text != "" && txtApellido.Text != "")
            {
                int.TryParse(txtDNI.Text,out dni);
                Cliente nuevo = new Cliente(dni, txtNombre.Text, txtApellido.Text);
                clientes.altaNuevo(nuevo);
                clientes.persistirListado();
                ActualizarLista();
                LimpiarCamposYSeleccionado();
                txtNombre.Focus();
            }
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            int dni = 0;
            if (seleccionado is not null)
            {
                if(txtDNI.Text != "" && txtNombre.Text != null && txtApellido.Text != "")
                {
                    int.TryParse(txtDNI.Text, out dni);
                    Cliente nuevo = new Cliente(dni, txtNombre.Text, txtApellido.Text);
                    clientes.modificaExistente(seleccionado, nuevo);
                    clientes.persistirListado();
                    ActualizarLista();
                    LimpiarCamposYSeleccionado();
                    this.btnAlta.Enabled = true;
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
                clientes.eliminarExistente(seleccionado);
                clientes.persistirListado();
                ActualizarLista();
                LimpiarCamposYSeleccionado();
                this.btnAlta.Enabled = true;
            }
        }

        private void lstClientes_DoubleClick(object sender, EventArgs e)
        {
            seleccionado = lstClientes.SelectedItem as Cliente;
            this.btnAlta.Enabled = false;
            if (seleccionado is not null)
            {
                this.txtDNI.Text = seleccionado.Dni.ToString();
                this.txtNombre.Text = seleccionado.Nombre;
                this.txtApellido.Text = seleccionado.Apellido;

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
            this.lstClientes.Items.Clear();
            foreach(Cliente c in clientes.mostrarLista())
            {
                this.lstClientes.Items.Add(c);
            }
        }

        private void CargarListaInicial()
        {
            try
            {
                clientes.mostrarLista().AddRange(clientes.leerListaPersistida());
            }
            catch(Exception e)
            {
                MessageBox.Show($"Excepcion : {e.Message}");
            }
        }
    }
}
