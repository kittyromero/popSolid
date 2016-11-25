using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibStream;
using System.Threading;
using RegExLib;

namespace StreamN
{
    public partial class FrmClients : Form
    {
        public FrmClients()
        {
            InitializeComponent();
        }
        LibRegEx validar = new LibRegEx();
        Astream str = new Astream();
        Clientes cl = new Clientes();
        Thread th;
        Thread thU;
       
        private void btn_rfc_Click(object sender, EventArgs e)
        {

            c_rfc rfc = new c_rfc();
            rfc.nom = txt_nombre.Text;
            rfc.pat = txt_paterno.Text;
            rfc.mat = txt_materno.Text;
            rfc.nac = txt_nac.Text;
            //rfc.nac = dateTimePicker1.Value.ToString();
         

            txt_rfc.Text = rfc.CalcularRFC();
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
            //Registrar al dataGrid
            if (validar.valNombre(txt_nombre.Text))
            {
                bandera = true;
            }
            else
            {
                bandera = false;
                MessageBox.Show("Error en Nombre");
            }
            if (validar.valNombre(txt_materno.Text))
            {
                bandera = true;
            }
            else
            {
                bandera = false;
                MessageBox.Show("Error en Apellido Materno");
            }
            if (validar.valNombre(txt_paterno.Text))
            {
                bandera = true;
            }
            else
            {
                bandera = false;
                MessageBox.Show("Error en Apellido Paterno");
            }
            if (validar.valDomicilio(txt_direc.Text))
            {
                bandera = true;
            }
            else
            {
                bandera = false;
                MessageBox.Show("Domicilio Incorrecto");
            }
            if (validar.valCorreo(txt_correo.Text))
            {
                bandera = true;
            }
            else
            {
                bandera = false;
                MessageBox.Show("Correo Invalido");
            }
            dataGridView1.Rows.Add(txt_rfc.Text, txt_nombre.Text, txt_paterno.Text, txt_materno.Text, txt_nac.Text, txt_direc.Text, txt_correo.Text, txt_tel.Text );
            
            txt_nombre.Clear();
            txt_paterno.Clear();
            txt_materno.Clear();
            txt_nac.Clear();
            txt_direc.Clear();
            txt_correo.Clear();
            txt_rfc.Clear();
            txt_tel.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            //Usar y crear doc.
            str.LibStream("Cliente.txt", false);
            str.instanciaWriter();
            th = new Thread(guardaMysql);
            thU = new Thread(threadM);
            th.Start();
            thU.Start();
           
        }

        //para actualizar pogressBar
        public void guardaMysql() 
        {
            int contador = dataGridView1.Rows.Count;
            contador = 100 / contador;
            if (contador <=100)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    pmysql.Value += contador;
                    Thread.Sleep(1000);
                    if (pmysql.Value==100)
                    {
                        break;
                        
                    }
                    
                }
                
                guardar();
            }
        }

        //Recorre el dataGrid y lo guarda en la base de datos.
        public void guardar()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                cl.Rfc = dataGridView1[0, i].Value.ToString();
                cl.Nombre = dataGridView1[1, i].Value.ToString();
                cl.Paterno = dataGridView1[2, i].Value.ToString();
                cl.Materno = dataGridView1[3, i].Value.ToString();
                cl.Nac = dataGridView1[4, i].Value.ToString();
                cl.Direc = dataGridView1[5, i].Value.ToString();
                cl.Correo = dataGridView1[6, i].Value.ToString();
                cl.Telefono = dataGridView1[7, i].Value.ToString();
                //for (int j = 0; j < 8; j++)
                //{
                //    cl.Rfc = dataGridView1.Rows[i].Cells[j].Value.ToString();
                //    cl.Nombre = dataGridView1.Rows[i].Cells[j + 1].Value.ToString();
                //    cl.Paterno = dataGridView1.Rows[i].Cells[j + 1].Value.ToString();
                //    cl.Materno = dataGridView1.Rows[i].Cells[j + 1].Value.ToString();
                //    cl.Nac = dataGridView1.Rows[i].Cells[j + 1].Value.ToString();
                //    cl.Direc = dataGridView1.Rows[i].Cells[j + 1].Value.ToString();
                //    cl.Correo = dataGridView1.Rows[i].Cells[j + 1].Value.ToString();
                //    cl.Telefono = dataGridView1.Rows[i].Cells[j + 1].Value.ToString();
                  cl.Conexion();
                  cl.agregarCliente();
                //    break;
                //}
            }
            dataGridView1.Rows.Clear();
        }

        //Crear stream mysql
        public void threadM() 
        {
            int cont = dataGridView1.Rows.Count;
            string valores="";
            cont = 100 / cont;
            if (cont <=100)
            {
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    pbStream.Value += cont;
                    Thread.Sleep(1000);
                 

                    for (int j = 0; j < 8; j++)
                    {
                        valores += dataGridView1.Rows[i].Cells[j].Value.ToString();
                        if (j==7)
                        {
                         valores = valores + "\n";
                        }
                        
                    }
                            str.write(valores);
                  
                  
                    if (pbStream.Value == 100)
                    {
                        break;
                    }
                  
                    
                    
                }
                str.closeW();
            }
        }

        private void pmysql_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

    }
}
