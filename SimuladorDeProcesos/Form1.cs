using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorDeProcesos
{
    public partial class Form1 : Form
    {

        DataTable modelo;
        int cont = 0;

        public Form1()
        {
            InitializeComponent();
            Iniciar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un algoritmo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                graficar();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }
        private void Iniciar()
        {
            modelo = new DataTable();
            
            modelo.Columns.Add("Proceso");
            modelo.Columns.Add("T. Lleg");
            modelo.Columns.Add("T. CPU");
            modelo.Columns.Add("Prioridad");
            modelo.Columns.Add("T. Com");
            modelo.Columns.Add("T. Fin");
            modelo.Columns.Add("T. Esp");
            
            
            tabla.DataSource = modelo;
             tabla.AutoResizeColumns();
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void graficar()
        {
          
            DataRow fila = modelo.NewRow();
            fila["Proceso"] = textBox1.Text;
            fila["T. Lleg"] = textBox2.Text;
            fila["T. CPU"] = textBox3.Text;
            if (comboBox.SelectedIndex == 2){
                fila["Prioridad"] = textBox4.Text;
            }
            
            modelo.Rows.Add(fila);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex != -1)
            {
                if (comboBox.SelectedIndex == 0 || comboBox.SelectedIndex == 1)
                {
                    label1.Visible = false;
                    textBox4.Enabled = false;
                    textBox4.Visible = false;
                    guardar.Enabled = false;
               
                }
                else
                {
                    label1.Visible = true;
                    textBox4.Enabled = true;
                    textBox4.Visible = true;
                    guardar.Enabled = false;
                }
            } else
            {
                MessageBox.Show("Seleccione un algoritmo!", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox4.Enabled = true;
            guardar.Enabled = true;
            textBox4.Visible = true;
            comboBox.SelectedIndex = -1;
            modelo.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
