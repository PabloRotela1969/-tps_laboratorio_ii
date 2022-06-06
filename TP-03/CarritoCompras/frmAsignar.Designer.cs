namespace CarritoCompras
{
    partial class frmAsignar
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
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lstItemsAsignados = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstClientE = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstClientes
            // 
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.ItemHeight = 15;
            this.lstClientes.Location = new System.Drawing.Point(12, 29);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(120, 274);
            this.lstClientes.TabIndex = 0;
            this.lstClientes.DoubleClick += new System.EventHandler(this.lstClientes_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "CLIENTES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "ITEMS";
            // 
            // lstItems
            // 
            this.lstItems.FormattingEnabled = true;
            this.lstItems.ItemHeight = 15;
            this.lstItems.Location = new System.Drawing.Point(158, 29);
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(120, 274);
            this.lstItems.TabIndex = 2;
            this.lstItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstItems_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstClientE);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lstItemsAsignados);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(300, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 275);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DEFINICIONES";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(14, 84);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar ";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "ITEMS ASIGNADOS";
            // 
            // lstItemsAsignados
            // 
            this.lstItemsAsignados.FormattingEnabled = true;
            this.lstItemsAsignados.ItemHeight = 15;
            this.lstItemsAsignados.Location = new System.Drawing.Point(167, 55);
            this.lstItemsAsignados.Name = "lstItemsAsignados";
            this.lstItemsAsignados.Size = new System.Drawing.Size(120, 199);
            this.lstItemsAsignados.TabIndex = 1;
            this.lstItemsAsignados.DoubleClick += new System.EventHandler(this.lstItemsAsignados_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "CLIENTE";
            // 
            // lstClientE
            // 
            this.lstClientE.FormattingEnabled = true;
            this.lstClientE.ItemHeight = 15;
            this.lstClientE.Location = new System.Drawing.Point(14, 55);
            this.lstClientE.Name = "lstClientE";
            this.lstClientE.Size = new System.Drawing.Size(130, 19);
            this.lstClientE.TabIndex = 5;
            this.lstClientE.DoubleClick += new System.EventHandler(this.lstClientE_DoubleClick);
            // 
            // frmAsignar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 354);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstItems);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstClientes);
            this.Name = "frmAsignar";
            this.Text = "Asignar Items a cada Cliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstItemsAsignados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ListBox lstClientE;
    }
}