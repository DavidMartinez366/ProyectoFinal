using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo
{
    public partial class frmPilas : Form
    {
        public class Nodo
        {
            public int dato;
            public Nodo siguiente;
            public Nodo nuevo;
            public Nodo aux;
            public Nodo(int Dato)
            {
                this.dato = Dato;
                this.siguiente = null;
            }
        }
        public Nodo top = null;
        public frmPilas()
        {
            InitializeComponent();
        }
        public void Lista()
        {
            listBox1.Items.Clear();
            Nodo aux = top;
            while (aux != null)
            {
                listBox1.Items.Add(aux.dato);
                aux = aux.siguiente;
            }
        }
        public void agregar(int dato)
        {
            Nodo nuevo = new Nodo(dato);
            nuevo.siguiente = top;
            top = nuevo;
            Lista();
        }

        private int Eliminar()
        {
            if (vacia())
            {
                MessageBox.Show("tu pila esta vacia");
                return -1;
            }
            else
            {
                int aux = 0;
                aux = top.dato;
                top = top.siguiente;
                Lista();
                return aux;

            }
        }
        public bool vacia()
        {
            return top == null;
        }

        public bool Buscar(int dato)
        {
            Nodo aux = top;
            while (aux != null)
            {
                if (aux.dato == dato)
                {
                    MessageBox.Show("el valor esta dentro de la pila");
                    return true;
                }
                aux = aux.siguiente;

            }

            MessageBox.Show("El valor no esta dentro de la pila.");
            return false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int dato;
            if (int.TryParse(textBox1.Text, out dato))
            {
                agregar(dato);


            }
        }

    

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            top = null;
            Lista();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int dato;
            if (int.TryParse(textBox1.Text, out dato))
            {
                Buscar(dato);
            }
            else
            {
                MessageBox.Show("ingresa un dato valido");
            }
        }
    }
}
