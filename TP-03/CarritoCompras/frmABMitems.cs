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
    public partial class frmABMitems : Form
    {
        Catalogo items;
        Item? seleccionado;
        public frmABMitems()
        {
            InitializeComponent();
            items = new Catalogo();
            CargarListaInicial();
            ActualizarLista();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            int id = 0;
            float precio = 0F;
            int cantidad = 0;
            if(txtId.Text != null && txtNombre.Text != null && txtPrecio.Text != null && txtCantidad.Text != null)
            {
                int.TryParse(txtId.Text, out id);
                int.TryParse(txtCantidad.Text, out cantidad);
                float.TryParse(txtPrecio.Text, out precio);
                Item nuevo = new Item(id, txtNombre.Text, cantidad, precio);
                items.altaNuevo(nuevo);
                items.persistirListado();
                ActualizarLista();
                LimpiarCamposYSeleccionado();
                txtId.Focus();
                
            }

        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            int id = 0;
            float precio = 0F;
            int cantidad = 0;
            if (seleccionado is not null)
            {
                if(txtId.Text != "" && txtNombre.Text != "" && txtCantidad.Text != "" && txtPrecio.Text != "")
                {
                    int.TryParse(txtId.Text, out id);
                    int.TryParse(txtCantidad.Text, out cantidad);
                    float.TryParse(txtPrecio.Text, out precio);
                    Item nuevo = new Item(id, txtNombre.Text, cantidad, precio);
                    items.modificaExistente(seleccionado, nuevo);
                    items.persistirListado();
                    LimpiarCamposYSeleccionado();
                    ActualizarLista();
                    this.btnAlta.Enabled = true;

                }
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (seleccionado is not null)
            {
                items.eliminarExistente(seleccionado);
                items.persistirListado();
                LimpiarCamposYSeleccionado();
                ActualizarLista();
                this.btnAlta.Enabled = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCamposYSeleccionado();
        }

        private void ActualizarLista()
        {
            this.lstItems.Items.Clear();
            foreach(Item item in items.mostrarLista())
            {
                this.lstItems.Items.Add(item);
            }
        }

        private void LimpiarCamposYSeleccionado()
        {
            this.txtId.Text = "";
            this.txtPrecio.Text = "";
            this.txtCantidad.Text = "";
            this.txtNombre.Text = "";
            seleccionado = null;
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            seleccionado = lstItems.SelectedItem as Item;
            this.btnAlta.Enabled = false;
            
            if(seleccionado is not null)
            {
                txtId.Text = seleccionado.Id.ToString();
                txtNombre.Text = seleccionado.Nombre;
                txtCantidad.Text = seleccionado.Cantidad.ToString();
                txtPrecio.Text = seleccionado.Precio.ToString();
            }

        }

        private void CargarListaInicial()
        {
            try
            {
                items.mostrarLista().AddRange(items.leerListaPersistida());
            }
            catch (Exception e)
            {
                MessageBox.Show($"Excepcion : {e.Message}");
            }
        }


    }
}
