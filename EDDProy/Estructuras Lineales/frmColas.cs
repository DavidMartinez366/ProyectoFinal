using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Estructuras_Lineales
{
    public partial class frmColas : Form
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
        public Nodo bottom = null;
        public frmColas()
        {
            InitializeComponent();
        }
        public void Lista()
        {
            listBox1.Items.Clear();
            Nodo aux = top;
            Nodo aux1 = bottom;
            while (aux != null)
            {
                listBox1.Items.Add(aux.dato);
                aux = aux.siguiente;
            }
        }
        public void agregar(int dato)
        {
            Nodo nuevo = new Nodo(dato);


            if (bottom == null)
            {
                top = nuevo;
                bottom = nuevo;

            }
            else
            {
                bottom.siguiente = nuevo;
                bottom = nuevo;
            }

            Lista();
        }
        public int Eliminar()
        {
            if (bottom == null && top == null)
            {
                MessageBox.Show("la cola esta vacia");
                return -1;

            }
            else
            {
                int dato = top.dato;
                top = top.siguiente;
                if (top == null)
                {
                    bottom = null;

                }
                return dato;

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

        private void button2_Click(object sender, EventArgs e)
        {
            int aux = Eliminar();
            if (aux != -1)
            {
                Lista();
                MessageBox.Show("eliminado " + aux);
            }
        }

        private void frmColas_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            top = null;
            Lista();
        }

        private void button4_Click(object sender, EventArgs e)
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
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
