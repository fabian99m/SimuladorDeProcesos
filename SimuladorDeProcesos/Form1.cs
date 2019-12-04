using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            if (!String.IsNullOrEmpty(id.Text) && !String.IsNullOrEmpty(tllegada.Text) && !String.IsNullOrEmpty(tcpu.Text))
            {
                if (comboBox.SelectedIndex == -1 || guardar.Enabled)
                {
                    MessageBox.Show("Seleccione un algoritmo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    lista.Add(new Proceso(id.Text, int.Parse(tllegada.Text), int.Parse(tcpu.Text)));
                    graficar();
                    id.Text = "";
                    tllegada.Text = "";
                    tcpu.Text = "";
                    cont++;

                }
            } else
            {
                MessageBox.Show("Ingrese datos!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void srtf()
        {
            int tiempoGlobal = 0;
            int tiempoEsperaTotal = 0;
            int numProcesosCompletos = 0;
            Boolean demoroMenos = true;

            List<Proceso> aux = lista.OrderBy(x => x.tlleg).ToList();

            while (numProcesosCompletos < aux.Count()) {
                foreach (Proceso i in aux)
                {
                    if (i.tlleg <= tiempoGlobal && i.tcpu > 0)
                    {
                        demoroMenos = true;
                        foreach (Proceso j in aux)
                        {
                            if (j.tcpu < i.tcpu && j.tlleg <= tiempoGlobal && !j.completado)
                            {
                                demoroMenos = false;

                                break;
                            }
                        }

                        if (demoroMenos) {

                            i.tcom = tiempoGlobal;
                            i.tcpu -= 1;

                            if (i.tfin > 0)
                            {
                                i.tesp += (i.tcom - i.tfin);
                                tiempoEsperaTotal += (i.tcom - i.tfin);
                            }
                            else
                            {
                                i.tesp += (i.tcom - i.tlleg);
                                tiempoEsperaTotal += (i.tcom - i.tlleg);
                            }

                            i.tfin = 1 + tiempoGlobal;

                        }

                    }
                    if (i.tcpu <= 0 && !i.completado) {
                        numProcesosCompletos++;
                        i.completado = true;

                    }
                    if (demoroMenos)
                    {
                        break;
                    }

                }
                tiempoGlobal += 1;
            }
            lista = aux;
            lista = lista.OrderBy(x => x.tlleg).ToList();
            modelo.Clear();
            rellenar();

        }


        public void sjf()
        {

            List<Proceso> aux = lista.OrderBy(x => x.tlleg).ToList();
            int tiempoCpu = aux.FindIndex(x => x.tcpu == 0);
            int anterior = 0;
          
            for (int i = 0; i < aux.Count(); i++)
            {
                if (aux[i].tlleg == 0)
                {
                    aux[i].tcom = anterior;
                    aux[i].tfin = anterior + aux[i].tcpu;
                    aux[i].tesp = aux[i].tcom - aux[i].tlleg;
                    anterior = aux[i].tfin;
                    aux[i].paso = true;
                    tiempoCpu = aux[i].tcpu;
                }
                else
                {
                    Proceso p = menor(aux, tiempoCpu);
                    p.tcom = anterior;
                    p.tfin = anterior + p.tcpu;
                    p.tesp = p.tcom - p.tlleg;
                    anterior = p.tfin;
                    p.paso = true;
                    tiempoCpu += p.tcpu;
                    aux[aux.FindIndex(x => x.id == p.id)] = p;
                }
            }

            lista = aux;
            modelo.Clear();
            rellenar();
        }

        public Proceso menor(List<Proceso> a, int b)
        {
            Proceso p = new Proceso();
            int anterior = 99;
            foreach (Proceso i in a)
            {
                if (i.paso == false && i.tcpu < b && i.tlleg <= b)
                {
                    if (i.tcpu < anterior)
                    {
                        p = i;
                        anterior = i.tcpu;
                    }
                }
            }
            return p;
        }
   

        public void fifo()
        {
            int anterior = 0;
            foreach (Proceso i in lista.OrderBy(x => x.tlleg).ToList())
            {
                i.tcom = anterior;
                i.tfin = anterior + i.tcpu;
                i.tesp = i.tcom - i.tlleg;
                anterior = i.tfin;
            }
            modelo.Clear();
            rellenar();
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
            fila["Proceso"] = id.Text;
            fila["T. Lleg"] = tllegada.Text;
            fila["T. CPU"] = tcpu.Text;  
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
            lista.Clear();
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
                if(comboBox.SelectedIndex == 1)
                {
                    sjf();
                }
                if(comboBox.SelectedIndex == 2)
                {
                    srtf();
                }
            }
            else
            {
                MessageBox.Show("Ingrese entre 4 y 6 procesos!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
