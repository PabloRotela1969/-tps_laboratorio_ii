namespace CarritoCompras
{
    partial class frmConfiguracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTablas = new System.Windows.Forms.RadioButton();
            this.rbSerializa = new System.Windows.Forms.RadioButton();
            this.btnCargarArchivoConfig = new System.Windows.Forms.Button();
            this.btnAbrirCarpetaArchivos = new System.Windows.Forms.Button();
            this.btnCadena = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTablas);
            this.groupBox1.Controls.Add(this.rbSerializa);
            this.groupBox1.Location = new System.Drawing.Point(21, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Persistencia de Clientes e Items";
            // 
            // rbTablas
            // 
            this.rbTablas.AutoSize = true;
            this.rbTablas.Location = new System.Drawing.Point(15, 50);
            this.rbTablas.Name = "rbTablas";
            this.rbTablas.Size = new System.Drawing.Size(158, 19);
            this.rbTablas.TabIndex = 1;
            this.rbTablas.TabStop = true;
            this.rbTablas.Text = "Guardar en base de datos";
            this.rbTablas.UseVisualStyleBackColor = true;
            this.rbTablas.Click += new System.EventHandler(this.rbTablas_Click);
            // 
            // rbSerializa
            // 
            this.rbSerializa.AutoSize = true;
            this.rbSerializa.Location = new System.Drawing.Point(15, 25);
            this.rbSerializa.Name = "rbSerializa";
            this.rbSerializa.Size = new System.Drawing.Size(100, 19);
            this.rbSerializa.TabIndex = 0;
            this.rbSerializa.TabStop = true;
            this.rbSerializa.Text = "Serializar listas";
            this.rbSerializa.UseVisualStyleBackColor = true;
            this.rbSerializa.Click += new System.EventHandler(this.rbSerializa_Click);
            // 
            // btnCargarArchivoConfig
            // 
            this.btnCargarArchivoConfig.Location = new System.Drawing.Point(235, 25);
            this.btnCargarArchivoConfig.Name = "btnCargarArchivoConfig";
            this.btnCargarArchivoConfig.Size = new System.Drawing.Size(313, 23);
            this.btnCargarArchivoConfig.TabIndex = 1;
            this.btnCargarArchivoConfig.Text = "Cargar archivo con ruta de archivos serializados";
            this.btnCargarArchivoConfig.UseVisualStyleBackColor = true;
            this.btnCargarArchivoConfig.Click += new System.EventHandler(this.btnCargarArchivoConfig_Click);
            // 
            // btnAbrirCarpetaArchivos
            // 
            this.btnAbrirCarpetaArchivos.Location = new System.Drawing.Point(235, 54);
            this.btnAbrirCarpetaArchivos.Name = "btnAbrirCarpetaArchivos";
            this.btnAbrirCarpetaArchivos.Size = new System.Drawing.Size(314, 23);
            this.btnAbrirCarpetaArchivos.TabIndex = 2;
            this.btnAbrirCarpetaArchivos.Text = "Abrir Carpeta con archivos serializados";
            this.btnAbrirCarpetaArchivos.UseVisualStyleBackColor = true;
            this.btnAbrirCarpetaArchivos.Click += new System.EventHandler(this.btnAbrirCarpetaArchivos_Click);
            // 
            // btnCadena
            // 
            this.btnCadena.Location = new System.Drawing.Point(235, 83);
            this.btnCadena.Name = "btnCadena";
            this.btnCadena.Size = new System.Drawing.Size(313, 23);
            this.btnCadena.TabIndex = 3;
            this.btnCadena.Text = "Cargar archivo de cadena de conexión";
            this.btnCadena.UseVisualStyleBackColor = true;
            this.btnCadena.Click += new System.EventHandler(this.btnCadena_Click);
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 134);
            this.Controls.Add(this.btnCadena);
            this.Controls.Add(this.btnAbrirCarpetaArchivos);
            this.Controls.Add(this.btnCargarArchivoConfig);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConfiguracion";
            this.Text = "Configuracion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTablas;
        private System.Windows.Forms.RadioButton rbSerializa;
        private System.Windows.Forms.Button btnCargarArchivoConfig;
        private System.Windows.Forms.Button btnAbrirCarpetaArchivos;
        private System.Windows.Forms.Button btnCadena;
    }
}