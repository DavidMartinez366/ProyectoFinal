using EDDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static EDDemo.Estructuras_No_Lineales.ArbolBusqueda;


//using GraphVizWrapper;
//using GraphVizWrapper.Queries;
//using GraphVizWrapper.Commands;   

//using csdot;
//using csdot.Attributes.DataTypes;

namespace EDDemo.Estructuras_No_Lineales
{
    public partial class frmArboles : Form
    {
        ArbolBusqueda miArbol;
        NodoBinario miRaiz;
        ArbolBinarioCompleto verificadorCompleto;
        ArbolBinarioLleno verificadorLleno;
        public frmArboles()
        {
            InitializeComponent();
            miArbol = new ArbolBusqueda();
            miRaiz = null;
            verificadorCompleto = new ArbolBinarioCompleto();
            verificadorLleno = new ArbolBinarioLleno();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int nuevoValor;
            if (int.TryParse(txtDato.Text, out nuevoValor))

                //Obtenemos el nodo Raiz del arbol
                miRaiz = miArbol.RegresaRaiz();

            if (!miArbol.BuscarNodo(nuevoValor, miRaiz))
            {
                // Si el valor no existe, se inserta
                miArbol.InsertaNodo(nuevoValor, ref miRaiz);

                //Limpiamos la cadena donde se concatenan los nodos del arbol 
                miArbol.strArbol = "";

                //Se inserta el nodo con el dato capturado
                miArbol.InsertaNodo(int.Parse(txtDato.Text),
                                    ref miRaiz);

                //Leer arbol completo y mostrarlo en caja de texto
                miArbol.MuestraArbolAcostado(1, miRaiz);
                txtArbol.Text = miArbol.strArbol;

                txtDato.Text = "";
            }
            else
            {
                // Si el valor ya existe mostrar un mensaje
                MessageBox.Show("El valor ya existe en el árbol.");
                txtDato.Text = "";
            }

        }
    
        

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            miArbol = null;
            miRaiz = null;
            miArbol = new ArbolBusqueda();
            txtArbol.Text = "";
            txtDato.Text = "";
            lblRecorridoPreOrden.Text = "";
            lblRecorridoInOrden.Text = "";
            lblRecorridoPostOrden.Text = "";
        }

        private void btnGrafica_Click(object sender, EventArgs e)
        {
            String graphVizString;

            miRaiz = miArbol.RegresaRaiz();
            if (miRaiz == null)
            {
                MessageBox.Show("El arbol esta vacio");
                return;
            }

            StringBuilder b = new StringBuilder();
            b.Append("digraph G { node [shape=\"circle\"]; " + Environment.NewLine);
            b.Append(miArbol.ToDot(miRaiz));
            b.Append("}");
            graphVizString = b.ToString();

            //graphVizString = @" digraph g{ label=""Graph""; labelloc=top;labeljust=left;}";
            //graphVizString = @"digraph Arbol{Raiz->60; 60->40. 60->90; 40->34; 40->50;}";
            Bitmap bm = FileDotEngine.Run(graphVizString);


            frmGrafica graf = new frmGrafica();
            graf.ActualizaGrafica(bm);
            graf.MdiParent = this.MdiParent;
            graf.Show();
        }


        private void btnRecorrer_Click(object sender, EventArgs e)
        {
            //Recorrido en PreOrden
            //Obtenemos el nodo Raiz del arbol
            miRaiz = miArbol.RegresaRaiz();
            miArbol.strRecorrido = "";

            if (miRaiz == null)
            {
                lblRecorridoPreOrden.Text = "El arbol esta vacio";
                return;
            }
            lblRecorridoPreOrden.Text = "";
            miArbol.PreOrden(miRaiz);

            lblRecorridoPreOrden.Text = miArbol.strRecorrido;


            //Recorrido en InOrden
            //Obtenemos el nodo Raiz del arbol
            miRaiz = miArbol.RegresaRaiz();
            miArbol.strRecorrido = "";

            if (miRaiz == null)
            {
                lblRecorridoPostOrden.Text = "El arbol esta vacio";
                return;
            }
            lblRecorridoInOrden.Text = "";
            miArbol.InOrden(miRaiz);
            lblRecorridoInOrden.Text = miArbol.strRecorrido;


            //Recorrido en PostOrden
            //Obtenemos el nodo Raiz del arbol
            miRaiz = miArbol.RegresaRaiz();
            miArbol.strRecorrido = "";

            if (miRaiz == null) {
                lblRecorridoPostOrden.Text = "El arbol esta vacio";
                return;
            }
            lblRecorridoPostOrden.Text = "";
            miArbol.PostOrden(miRaiz);
            lblRecorridoPostOrden.Text = miArbol.strRecorrido;
        }

        private void btnCrearArbol_Click(object sender, EventArgs e)
        {
            
            miArbol = null;
            miRaiz = null;
            miArbol = new ArbolBusqueda();
            txtArbol.Text = "";
            txtDato.Text = "";

            miArbol.strArbol = "";

            Random rnd = new Random();

            for (int nNodos = 1; nNodos <= txtNodos.Value; nNodos++)
            {
                int Dato = rnd.Next(1, 100);

                
                miRaiz = miArbol.RegresaRaiz();

                
                if (!miArbol.BuscarNodo(Dato, miRaiz))
                {
                    
                    miArbol.InsertaNodo(Dato, ref miRaiz);
                }
                else
                {
                    
                    nNodos--; 
                }
            }

            
            miArbol.MuestraArbolAcostado(1, miRaiz);
            txtArbol.Text = miArbol.strArbol;

            txtDato.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int valor;

            
            if (int.TryParse(txtBuscar.Text, out valor))
            {
                
                bool encontrado = miArbol.BuscarNodo(valor, miArbol.RegresaRaiz());

               
                if (encontrado)
                    MessageBox.Show("valor si existe en el arbol");
                else
                    MessageBox.Show("Valor no encontrado en el árbol.");
            }
            else
            {
                lblDatos.Text = "Ingrese un número válido.";
            }
        }

        private void btPodar_Click(object sender, EventArgs e)
        {
            miArbol.PodarHojas();
            miArbol.strArbol = ""; 
            miArbol.MuestraArbolAcostado(0, miArbol.RegresaRaiz());
            txtArbol.Text = miArbol.strArbol;
        }

        private void btPodarT_Click(object sender, EventArgs e)
        {
            miArbol.podarArbol();
            miArbol.strArbol = "";
            miArbol.MuestraArbolAcostado(0, miArbol.RegresaRaiz());
            txtArbol.Text = miArbol.strArbol;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int valor))
            {
                
                miArbol.EliminarNodo(valor);

               
                miArbol.strArbol = ""; 
                miArbol.MuestraArbolAcostado(0, miRaiz); 
                txtArbol.Text = miArbol.strArbol; 
            }
            else
            {
                MessageBox.Show("Ingrese un valor válido para eliminar.");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int valor))
            {
                
                miArbol.EliminarNodoConSucesor(valor);

                
                miArbol.strArbol = ""; 
                miArbol.MuestraArbolAcostado(0, miRaiz); 
                txtArbol.Text = miArbol.strArbol; 
            }
            else
            {
                MessageBox.Show("Ingrese un valor válido para eliminar.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (miRaiz == null)
            {
                MessageBox.Show("El árbol está vacío.");
                return;
            }

            
            string resultado = miArbol.RecorrerPorNiveles(miRaiz);
            label2.Text = resultado;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            if (miRaiz == null)
            {
                MessageBox.Show("El árbol está vacío.");
                return;
            }

           
            int altura = miArbol.ObtenerAltura(miRaiz);

           
            label4.Text = "Altura del árbol: " + altura.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            int cantidadHojas = miArbol.ContarHojas(miRaiz);

            
           label5.Text = "Cantidad de hojas: " + cantidadHojas;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int cantidadNodos = miArbol.ContarNodos(miRaiz);

            label8.Text = "nodos " + cantidadNodos;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            bool esCompleto = verificadorCompleto.EsCompleto(miArbol.RegresaRaiz());

            // Mostrar el resultado en el label
            label9.Text = esCompleto ? "El árbol es COMPLETO" : "El árbol NO es completo";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bool esLleno = verificadorLleno.EsLleno(miArbol.RegresaRaiz());

            // Mostrar el resultado en el label
            label10.Text = esLleno ? "El árbol es LLENO" : "El árbol NO es lleno";
        }
    }
    }
