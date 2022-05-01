using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        #region -------metodos de formulario---------
        /// <summary>
        /// inicializa los objetos de formulario
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }



        /// <summary>
        /// permite limpiar los campos al cargar el formulario
        /// </summary>
        /// <param name="sender></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }


        
        /// <summary>
        /// antes de cerrarse por el botón de cerrar o el del formulario, permite mostrar un messagebox para
        /// permitir una segunda oportunidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quiere salir?", "CONFIRMACION", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }


        #endregion

        #region -------------------otros métodos----------------------------------

        /// <summary>
        /// permite borrar los campos de numerador y denominador así como el combo
        /// de operaciones y el campo de resultados
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperaciones.Text = "";
            this.txtResultado.Text = "";
        }




        /// <summary>
        /// permite usuar el metodo operar de la librería verificando que se haya seleccionado un 
        /// operador primero y luego, si el operador es / el numerador debe ser distinto de 0
        /// si se cumplen esas validaciones,se procede a operar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string cuenta = "";
            char[] textoDelCombo = cmbOperaciones.Text.ToCharArray();
            char operador = textoDelCombo[0];
            if(operador == '\0')
            {
                MessageBox.Show("Favor de ingresar un operador", "AVISO", MessageBoxButtons.OK);
                
            }
            else
            {
                if(operador == '/' && (txtNumero2.Text == "" || txtNumero2.Text == "0"))
                {
                    txtResultado.Text = "ERROR : división por cero";
                }
                else
                {
                    Operando primero = new Operando(txtNumero1.Text);
                    Operando segundo = new Operando(txtNumero2.Text);
                    txtResultado.Text = Calculadora.Operar(primero, segundo, operador).ToString();
                    cuenta = ($"{txtNumero1.Text} {operador} {txtNumero2.Text} = {txtResultado.Text} \n");
                    lstOperaciones.Items.Add(cuenta);
                    invertirItemsEnLista(lstOperaciones);

                }
            }


            

        }

        /// <summary>
        /// metodo para invertir el orden de las operaciones en el listbox de modo que siempre
        /// quede la última cuenta arriba de todo
        /// </summary>
        /// <param name="lista"></param>
        private void invertirItemsEnLista(ListBox lista)
        {
            List<string> listadoInvertido = new List<string>();
            string cuenta = "";

            for (int i = lista.Items.Count - 1; i>-1;  i--)
            {
                cuenta = (string)lista.Items[i];
                listadoInvertido.Add(cuenta);
            }
            lista.Items.Clear();
            foreach(string cuentas in listadoInvertido)
            {
                lista.Items.Add(cuentas);
            }
        }

        #endregion

        #region -----------------------botones-----------------------------

        /// <summary>
        /// El botón limpiar llama al método homónimo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// el botón cerrar llama al cerrado del formulario que a su vez activa al formClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {

            this.Close();           

        }

        /// <summary>
        /// Es un método de clase por lo que se invoca por el objeto y toma el valor que haya
        /// en el campo resultado para sobreescribirlo como binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando(txtResultado.Text);
            this.txtResultado.Text = resultado.DecimalBinario(txtResultado.Text);
        }

        /// <summary>
        /// Es un método de clase por lo que se invoca por el objeto y toma el valor que haya
        /// en el campo resultado para sobreescribirlo como decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            double resultadoBinario = 0;
            double.TryParse(txtResultado.Text, out resultadoBinario);
            Operando resultado = new Operando(resultadoBinario);
            this.txtResultado.Text = resultado.BinarioDecimal(txtResultado.Text);
        }

        #endregion

    }
}
