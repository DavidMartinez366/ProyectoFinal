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
    public partial class frmListasD : Form
    {
        public class Nodo
        {

            public int dato;
            public Nodo siguiente;
            public Nodo nuevo;
            public Nodo aux;
            public Nodo anterior;

            public Nodo(int Dato)
            {
                this.dato = Dato;
                this.siguiente = null;
                this.anterior = null;


            }
        }
        public Nodo top = null;
        public Nodo bottom = null;
        public int posicion = 0;
        public Nodo anterior = null;
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

        public frmListasD()
        {
            InitializeComponent();
        }
        public bool vacia()
        {
            return top == null;
        }
        public void Insertar(int posicion, int dato)
        {
            Nodo nuevo = new Nodo(dato);


            if (top == null && bottom == null)
            {
                top = nuevo;
                bottom = nuevo;
                return;
            }


            if (posicion == 0 || posicion == 1)
            {
                nuevo.siguiente = top;
                top.anterior = nuevo;
                top = nuevo;
                return;
            }

            int pos = 1;
            Nodo aux = top;


            while (pos < posicion && aux != null)
            {

                if (aux.siguiente != null)
                {
                    aux = aux.siguiente;
                }
                else
                {
                    aux = null;
                }
                pos++;
            }


            if (aux != null)
            {
                nuevo.siguiente = aux;
                nuevo.anterior = aux.anterior;
                if (aux.anterior != null)
                {
                    aux.anterior.siguiente = nuevo;
                }
                aux.anterior = nuevo;
            }
            else
            {
                bottom.siguiente = nuevo;
                nuevo.anterior = bottom;
                bottom = nuevo;
            }
        }
        public int Eliminar(int posicion)
        {

            if (top == null && bottom == null)
            {
                MessageBox.Show("Lista vacía");
                return -1;
            }

            int pos = 1;
            Nodo aux = top;

            while (pos < posicion && aux != null)
            {
                if (aux.siguiente != null)
                {
                    aux = aux.siguiente;
                }
                else
                {
                    aux = null;
                }
                pos++;
            }


            if (aux != null)
            {

                if (aux == top)
                {
                    top = aux.anterior;
                }


                if (aux.anterior != null)
                {
                    aux.anterior.siguiente = aux.siguiente;
                }
                if (aux.siguiente != null)
                {
                    aux.siguiente.anterior = aux.anterior;
                }

                int dato = aux.dato;
                aux = null;
                return dato;
            }
            else
            {

                MessageBox.Show("no es una posicion valida");
                return 0;
            }
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
            int posicion;

            if (int.TryParse(textBox1.Text, out dato) && int.TryParse(textBox1.Text, out posicion))
            {
                Insertar(posicion, dato);
                Lista();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un dato y una posición válidos.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int dato;
            int posicion;

            if (int.TryParse(textBox1.Text, out dato) && int.TryParse(textBox1.Text, out posicion))
            {
                Eliminar(posicion);
                Lista();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un dato y una posición válidos.");
            }
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
    }
}
