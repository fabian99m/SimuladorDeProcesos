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
        List<ProcesoSRTF> listaux= new List<ProcesoSRTF>();
        List<ProcesoSRTF> lista_srtf = new List<ProcesoSRTF>();

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
                    if(comboBox.SelectedIndex==0 || comboBox.SelectedIndex == 1)
                    {
                        lista.Add(new Proceso(id.Text, int.Parse(tllegada.Text), int.Parse(tcpu.Text)));
                    } else
                    {
                        lista_srtf.Add(new ProcesoSRTF(id.Text, int.Parse(tllegada.Text), int.Parse(tcpu.Text)));
                        listaux.Add(new ProcesoSRTF(id.Text, int.Parse(tllegada.Text), int.Parse(tcpu.Text)));
                    }
                    
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
           
            List<ProcesoSRTF> lista_aux = new List<ProcesoSRTF>();
            lista_aux = lista_srtf;
            int tiempoT=0;
            String aux_pro = "";
            int mini = 9999;
            String pro_ON = "";

            foreach (ProcesoSRTF i in lista_srtf) {
                tiempoT += i.tcpu;
              
            }
           
            for(int index = 0;index < tiempoT; index++ )
            {
                mini = 9999;
                List<ProcesoSRTF> lista_aux2 = new List<ProcesoSRTF>();
                foreach(ProcesoSRTF j in lista_aux)
                {
                    if (j.tlleg <= index && j.tcpu != 0)
                    {
                        lista_aux2.Add(j);
                    }
                }

                foreach(ProcesoSRTF j in lista_aux2)
                {
                    if (j.tcpu < mini)
                    {
                        mini = j.tcpu;
                        aux_pro = j.id;
                    }
                }

                foreach(ProcesoSRTF j in lista_aux)
                {
                    if (j.id == aux_pro)
                    {
                        if(pro_ON == j.id)
                        {
                            j.tcpu--;
                        } else
                        {
                         foreach(ProcesoSRTF k in lista_srtf)
                            {
                                if(k.id == j.id)
                                {
                                    k.tcom.Add(index);
                                } 
                                if(pro_ON == k.id)
                                {
                                    k.tfin.Add(index);
                                }
                            }
                            pro_ON = j.id;
                            j.tcpu--;
                        }
                    }

                }
                if (tiempoT == index + 1)
                {
                    
                    foreach(ProcesoSRTF j in lista_srtf)
                    {
                        if (aux_pro == j.id)
                        {
                            j.tfin.Add(index + 1);
                        }
                    }
                }
               
            }

           int  retorno = 0;
           int a_ = 0; 
           foreach(ProcesoSRTF j in lista_srtf)

            {
                //j.tfin.Count();
               retorno = j.tfin[j.tfin.Count() - 1] - j.tlleg;
                for (int index = 0; index < j.tcom.Count(); index++)
                {
                    a_ += j.tfin[index] - j.tcom[index];
                }
                j.tesp = retorno - a_;
                retorno = 0;
                a_ = 0;

            }

           int h = 0;
           foreach (ProcesoSRTF j in listaux)
            {
                lista_srtf[h].tcpu = j.tcpu;
                h++;
             
            }
            //listaux.Clear();
            //lista_aux.Clear();
            

            modelo.Clear();
            rellenarSRTF();
        }

        private void rellenarSRTF()
        {

            foreach (ProcesoSRTF i in lista_srtf)
            {
                DataRow fila = modelo.NewRow();
                fila["Proceso"] = i.id;
                fila["T. Lleg"] = i.tlleg;
                fila["T. CPU"] = i.tcpu;
                fila["T. Com"] = imprimir(i.tcom);
                fila["T. Fin"] = imprimir(i.tfin);
                fila["T. Esp"] = i.tesp;
                modelo.Rows.Add(fila);
            }
        }

        private String imprimir(List <int> p)
        {
            String r = "";
            foreach(int i in p)
            {
                r += "" + i + ",";
            }
            return r;
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
               // MessageBox.Show("Bien!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
