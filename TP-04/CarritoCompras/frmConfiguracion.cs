using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Biblioteca;

namespace CarritoCompras
{
    public partial class frmConfiguracion : Form
    {


        public frmConfiguracion()
        {
            InitializeComponent();
            rbSerializa.Checked = true;
        }

        private void rbSerializa_Click(object sender, EventArgs e)
        {
            Clientela.PersistirPorTablas = false;
            Catalogo.PersistirPorTablas = false;

        }

        private void rbTablas_Click(object sender, EventArgs e)
        {
            Clientela.PersistirPorTablas = true;
            Catalogo.PersistirPorTablas = true;

        }

        private void btnCargarArchivoConfig_Click(object sender, EventArgs e)
        {
            string ruta = "";
            try
            {
                ruta = Directory.GetCurrentDirectory();
                ruta += @"\configuracion.txt";
                if(File.Exists(ruta))
                {
                    Process proceso = new Process();
                    proceso.StartInfo.FileName = ruta;
                    proceso.StartInfo.UseShellExecute = true;
                    proceso.Start();
                }
                else
                {
                    MessageBox.Show("No se encontró el archivo de configuracion");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el archivo de configuracion por {ex.Message}");
            }
        }

        private void btnAbrirCarpetaArchivos_Click(object sender, EventArgs e)
        {
            string ruta = "";
            try
            {
                ruta = Archivos.RutaParaArchivoConfiguracion();
                if (Directory.Exists(ruta))
                {
                    Process proceso = new Process();
                    proceso.StartInfo.FileName = ruta;
                    proceso.StartInfo.UseShellExecute = true;
                    proceso.Start();
                }
                else
                {
                    MessageBox.Show("No se encontró la carpeta mencionada");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el archivo de configuracion por {ex.Message}");
            }
        }

        private void btnCadena_Click(object sender, EventArgs e)
        {
            string ruta = "";
            try
            {
                ruta = Archivos.LeerRutaEnDllsDeArchivo("cadena.txt");
                if (File.Exists(ruta))
                {
                    Process proceso = new Process();
                    proceso.StartInfo.FileName = ruta;
                    proceso.StartInfo.UseShellExecute = true;
                    proceso.Start();
                }
                else
                {
                    MessageBox.Show("No se encontró el archivo de cadena de conexión a base de datos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el archivo de configuracion por {ex.Message}");
            }
        }
    }
}
