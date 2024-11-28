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
    public partial class frmListasS : Form
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
        public frmListasS()
        {
            InitializeComponent();
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
        public bool vacia()
        {
            return top == null;
        }

        public void agregar(int dato)
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
                top = nuevo;
                return;
            }
            posicion = 1;
            Nodo aux = top;
            while (posicion < posicion && aux != null)
            {

                anterior = aux;
                aux = aux.siguiente;
                posicion++;

                if (aux.siguiente != null)
                {
                    nuevo.siguiente = aux;
                    anterior.siguiente = nuevo;
                }
                else
                {
                    bottom.siguiente = nuevo;
                    bottom = nuevo;
                }
            }
        }
        public int eliminar(int posicion)
        {
            if (top == null && bottom == null)
            {
                MessageBox.Show("Lista vacía");
                return -1;
            }

            int pos = 1;
            Nodo aux = top;
            Nodo anterior = null;


            while (pos < posicion && aux != null)
            {
                anterior = aux;
                aux = aux.siguiente;
                pos++;
            }

            if (aux != null)
            {
                if (aux == bottom)
                {
                    bottom = anterior;
                }

                if (anterior != null)
                {
                    anterior.siguiente = aux.siguiente;
                }
                else
                {
                    top = aux.siguiente;
                }

                int dato = aux.dato;
                aux = null;
                return dato;
            }
            else
            {
                MessageBox.Show("No se encontró la posición");
                return -1;
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
            if (int.TryParse(textBox1.Text, out dato))
            {
                agregar(dato);
                Lista();
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int posicion;


            if (int.TryParse(textBox1.Text, out posicion))
            {
                int aux = eliminar(posicion);

                if (aux != -1)
                {
                    MessageBox.Show("Dato eliminado");
                    Lista();
                }
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
