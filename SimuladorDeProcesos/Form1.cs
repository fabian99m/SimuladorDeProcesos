using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimuladorDeProcesos.Logica;

namespace SimuladorDeProcesos
{
    public partial class Form1 : Form
    {

        DataTable modelo;
        int cont = 0;
        List<Proceso> lista = new List<Proceso>();

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
            if (comboBox.SelectedIndex == -1 || guardar.Enabled)
            {
                MessageBox.Show("Seleccione un algoritmo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                lista.Add(new Proceso(textBox1.Text,int.Parse(textBox2.Text),int.Parse(textBox3.Text)));
                graficar();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                cont++;
                
            }
        }

        public void fifo()
        {
            lista.OrderBy(x => x.tlleg);
            int anterior = 0;
            foreach ( Proceso i in lista)
            {
                i.tcom = anterior;
                i.tfin = anterior + i.tcpu;
                i.tesp = i.tcom - i.tlleg;
                anterior = i.tfin;
            }
            modelo.Clear();
            rellenar();
        }
        public void sjf() {
            lista.OrderBy(x => x.tcpu);
            int j = buscarComienzo();
            Proceso p = lista[j];
            lista.RemoveAt(j);
            lista.Insert(0, p);
            int anterior = 0;
            foreach (Proceso i in lista)
            {
                i.tcom = anterior;
                i.tfin = anterior + i.tcpu;
                i.tesp = i.tcom - i.tlleg;
                anterior = i.tfin;
            }
            modelo.Clear();
            rellenar();
        }
        public  int buscarComienzo()
        {
            int r = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].tlleg == 0)
                {
                    r = i;
                }
            }
            return r;
        }

        private void rellenar()
        {
            
            foreach (Proceso i in lista)
            {
                DataRow fila = modelo.NewRow();
                fila["Proceso"] = i.id;
                fila["T. Lleg"] = i.tlleg;
                fila["T. CPU"] = i.tcpu;
                fila["T. Com"] = i.tcom;
                fila["T. Fin"] = i.tfin;
                fila["T. Esp"] = i.tesp;
                modelo.Rows.Add(fila);
            }
        }

        private void Iniciar()
        {
            modelo = new DataTable();
            
            modelo.Columns.Add("Proceso");
            modelo.Columns.Add("T. Lleg");
            modelo.Columns.Add("T. CPU");
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
            modelo.Rows.Add(fila);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox.SelectedIndex!= -1)
            {
                guardar.Enabled = false;
            } else
            {
                MessageBox.Show("Seleccione un algoritmo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            guardar.Enabled = true;
            comboBox.SelectedIndex = -1;
            modelo.Clear();
            cont = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(cont>3 && cont<7)
            {
                MessageBox.Show("Bien!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (comboBox.SelectedIndex == 0)
                {
                    fifo();
                }
            }
            else
            {
                MessageBox.Show("Ingrese entre 4 y 6 procesos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
