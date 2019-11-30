namespace SimuladorDeProcesos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.titulo = new System.Windows.Forms.Label();
            this.añadir = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.guardar = new System.Windows.Forms.Button();
            this.reiniciar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.Location = new System.Drawing.Point(292, 22);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(190, 18);
            this.titulo.TabIndex = 0;
            this.titulo.Text = "Simulador de procesos";
            this.titulo.Click += new System.EventHandler(this.label1_Click);
            // 
            // añadir
            // 
            this.añadir.Location = new System.Drawing.Point(89, 208);
            this.añadir.Name = "añadir";
            this.añadir.Size = new System.Drawing.Size(179, 34);
            this.añadir.TabIndex = 7;
            this.añadir.Text = "Añadir!";
            this.añadir.UseVisualStyleBackColor = true;
            this.añadir.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(156, 147);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(112, 22);
            this.textBox3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "T. CPU";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(156, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 22);
            this.textBox2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "T. lleg";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(156, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 22);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.añadir);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(40, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 294);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Añadir proceso";
            // 
            // tabla
            // 
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(109, 414);
            this.tabla.Name = "tabla";
            this.tabla.ReadOnly = true;
            this.tabla.RowHeadersWidth = 51;
            this.tabla.RowTemplate.Height = 24;
            this.tabla.Size = new System.Drawing.Size(596, 203);
            this.tabla.TabIndex = 3;
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "FIFO",
            "SJF",
            "SRTF"});
            this.comboBox.Location = new System.Drawing.Point(89, 47);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 24);
            this.comboBox.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.guardar);
            this.groupBox2.Controls.Add(this.reiniciar);
            this.groupBox2.Controls.Add(this.comboBox);
            this.groupBox2.Location = new System.Drawing.Point(428, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 294);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algoritmo";
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(89, 119);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(121, 35);
            this.guardar.TabIndex = 11;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.button3_Click);
            // 
            // reiniciar
            // 
            this.reiniciar.Location = new System.Drawing.Point(89, 208);
            this.reiniciar.Name = "reiniciar";
            this.reiniciar.Size = new System.Drawing.Size(121, 34);
            this.reiniciar.TabIndex = 10;
            this.reiniciar.Text = "Reiniciar";
            this.reiniciar.UseVisualStyleBackColor = true;
            this.reiniciar.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 668);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabla);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.titulo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "SImulador";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Button añadir;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Button reiniciar;
    }
}

