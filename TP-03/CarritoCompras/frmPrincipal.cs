using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarritoCompras
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private frmClientes formularioClientes = null;
        private frmClientes FormularioClientes
        {
            get
            {
                if(formularioClientes == null)
                {
                    formularioClientes = new frmClientes();
                    formularioClientes.MdiParent = this;
                    formularioClientes.FormClosed += new FormClosedEventHandler(formularioClientes_Closed);
                    formularioClientes.Disposed += new EventHandler(formularioClientes_Disposed);
                    formularioClientes.Load += new EventHandler(formularioClientes_Load);
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
                if (formularioItems == null)
                {
                    formularioItems = new frmABMitems();
                    formularioItems.MdiParent = this;
                    formularioItems.FormClosed += new FormClosedEventHandler(formularioItems_Closed);
                    formularioItems.Disposed += new EventHandler(formularioItems_Disposed);
                    formularioItems.Load += new EventHandler(formularioItems_Load);
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
                if (formularioAsignar == null)
                {
                    formularioAsignar = new frmAsignar();
                    formularioAsignar.MdiParent = this;
                    formularioAsignar.FormClosed += new FormClosedEventHandler(formularioAsignar_Closed);
                    formularioAsignar.Disposed += new EventHandler(formularioAsignar_Disposed);
                    formularioAsignar.Load += new EventHandler(formularioAsignar_Load);
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
            frm.Show();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMitems frm = FormularioItems;
            frm.Show();
        }

        private void asignarItemsAClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsignar frm = FormularioAsignar;
            frm.Show(); 
        }
    }
}
