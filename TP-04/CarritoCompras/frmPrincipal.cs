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
    public partial class frmPrincipal : Form
    {

        public frmPrincipal()
        {
            InitializeComponent();
            
            try
            {
                Archivos.LeerArchivoCadenaConexion();

            }
            catch (Exception)
            {
                MessageBox.Show($"Estimado usuario, reponga el archivo cadena.txt en el mismo directorio donde arranca la app", "AVISO", MessageBoxButtons.OK);
            }
            try
            {
                Archivos.RutaParaArchivoConfiguracion();
            }
            catch (Exception)
            {
                MessageBox.Show($"Estimado usuario, reponga el archivo configuracion.txt en el mismo directorio donde arranca la app","AVISO",MessageBoxButtons.OK);
            }
            AbrirFormuarioDeConfiguracion();
        }

        private frmClientes formularioClientes = null;
        private frmClientes FormularioClientes
        {
            get
            {
                try
                {
                    if (formularioClientes == null)
                    {
                        formularioClientes = new frmClientes();
                        formularioClientes.MdiParent = this;
                        formularioClientes.FormClosed += new FormClosedEventHandler(formularioClientes_Closed);
                        formularioClientes.Disposed += new EventHandler(formularioClientes_Disposed);
                        formularioClientes.Load += new EventHandler(formularioClientes_Load);
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show($"Error al cargar el formulario de clientes : {e.Message}");
                }
                
                return formularioClientes;
            }
        }

        private void formularioClientes_Disposed(object? sender, EventArgs e)
        {
            formularioClientes = null;
        }

        private void formularioClientes_Load(object? sender, EventArgs e)
        {
        }

        private void formularioClientes_Closed(object? sender, EventArgs e)
        {
        }



        private frmABMitems formularioItems = null;
        private frmABMitems FormularioItems
        {
            
            get
            {
                try
                {
                    if (formularioItems == null)
                    {
                        formularioItems = new frmABMitems();
                        formularioItems.MdiParent = this;
                        formularioItems.FormClosed += new FormClosedEventHandler(formularioItems_Closed);
                        formularioItems.Disposed += new EventHandler(formularioItems_Disposed);
                        formularioItems.Load += new EventHandler(formularioItems_Load);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error al cargar el formulario de Alta, Baja y Modificacion de items : {e.Message}");
                }

                
                return formularioItems;
            }
        }

        private void formularioItems_Disposed(object? sender, EventArgs e)
        {
            formularioItems = null;
        }

        private void formularioItems_Load(object? sender, EventArgs e)
        {
        }

        private void formularioItems_Closed(object? sender, EventArgs e)
        {
        }




        private frmAsignar formularioAsignar = null;
        private frmAsignar FormularioAsignar
        {
            get
            {
                try
                {
                    if (formularioAsignar == null)
                    {
                        formularioAsignar = new frmAsignar();
                        formularioAsignar.MdiParent = this;
                        formularioAsignar.FormClosed += new FormClosedEventHandler(formularioAsignar_Closed);
                        formularioAsignar.Disposed += new EventHandler(formularioAsignar_Disposed);
                        formularioAsignar.Load += new EventHandler(formularioAsignar_Load);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error al cargar el formulario para asignar items a clientes : {e.Message}");
                }
                                    
                return formularioAsignar;
            }
        }

        private void formularioAsignar_Disposed(object? sender, EventArgs e)
        {
            formularioAsignar = null;
        }

        private void formularioAsignar_Load(object? sender, EventArgs e)
        {
        }

        private void formularioAsignar_Closed(object? sender, EventArgs e)
        {
        }




        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
                frmClientes frm = FormularioClientes;
                if(frm != null)
                    frm.Show();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                frmABMitems frm = FormularioItems;
                if (frm != null)
                    frm.Show();
           
            
        }

        private void asignarItemsAClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                frmAsignar frm = FormularioAsignar;
                if (frm != null)
                    frm.Show();
           

        }

        private void AbrirFormuarioDeConfiguracion()
        {
            frmConfiguracion config = new frmConfiguracion();
            if (config != null)
            {
                config.MdiParent = this;
                config.Show();
            }
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormuarioDeConfiguracion();


        }
    }
}
