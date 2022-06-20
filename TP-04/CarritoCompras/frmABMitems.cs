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
            this.prgCarga.Value = 0;
            items = new Catalogo();
            CargarListaInicial();
            this.prgCarga.Value = 50;
            ActualizarLista();
            this.prgCarga.Value = 100;
        }


        private void btnAlta_Click(object sender, EventArgs e)
        {
            int id = 0;
            float precio = 0F;
            int cantidad = 0;
            if(txtId.Text != null && txtNombre.Text != null && txtPrecio.Text != null && txtCantidad.Text != null)
            {
                try
                {
                    int.TryParse(txtId.Text, out id);
                    int.TryParse(txtCantidad.Text, out cantidad);
                    float.TryParse(txtPrecio.Text.Replace(',','.'), out precio);
                    Item nuevo = new Item(id, txtNombre.Text, cantidad, precio);
                    items.AltaNuevo(nuevo);
                    this.prgCarga.Value = 0;
                    items.PersistirListado();
                    this.prgCarga.Value = 50;
                    ActualizarLista();
                    LimpiarCamposYSeleccionado();
                    txtId.Focus();
                    this.prgCarga.Value = 100;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error en el alta de items {ex.Message} {ex.InnerException}");
                }
                
                
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
                    try
                    {
                        int.TryParse(txtId.Text, out id);
                        int.TryParse(txtCantidad.Text, out cantidad);
                        float.TryParse(txtPrecio.Text, out precio);
                        Item nuevo = new Item(id, txtNombre.Text, cantidad, precio);
                        items.ModificaExistente(seleccionado, nuevo);
                        this.prgCarga.Value = 0;
                        items.PersistirListado();
                        this.prgCarga.Value = 50;
                        LimpiarCamposYSeleccionado();
                        ActualizarLista();
                        this.btnAlta.Enabled = true;
                        this.prgCarga.Value = 100;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error durante la modificación de items {ex.Message} {ex.InnerException}");
                    }
                    

                }
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (seleccionado is not null)
            {
                try
                {
                    items.EliminarExistente(seleccionado);
                    this.prgCarga.Value = 0;
                    items.PersistirListado();
                    this.prgCarga.Value = 50;
                    LimpiarCamposYSeleccionado();
                    ActualizarLista();
                    this.btnAlta.Enabled = true;
                    this.prgCarga.Value = 100;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error durante el borrado de items {ex.Message} {ex.InnerException}");
                }
                
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCamposYSeleccionado();
        }

        private void ActualizarLista()
        {
            this.LstItems.Items.Clear();
            foreach(Item item in items.mostrarLista())
            {
                this.LstItems.Items.Add(item);
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
        private void LstItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            seleccionado = LstItems.SelectedItem as Item;
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

                List<Item> listaLeida = items.LeerListaPersistida();
                
                if (listaLeida != null)
                {
                    items.mostrarLista().AddRange(listaLeida);

                }
                else
                {
                    MessageBox.Show("No hay datos en tablas para mostrar");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Excepcion : {e.Message}");
            }




        }


    }
}
