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
    public partial class frmListasCS : Form
    {
        public frmListasCS()
        {
            InitializeComponent();
        }
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

        public void Lista()
        {
            listBox1.Items.Clear();
            if (top != null)
            {
                Nodo aux = top;
                do
                {
                    listBox1.Items.Add(aux.dato);
                    aux = aux.siguiente;

                }
                while (aux != top);
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
        public void insertar(int posicion, int dato)
        {

            Nodo nuevo = new Nodo(dato);


            if (top == null && bottom == null)
            {
                top = nuevo;
                bottom = nuevo;
                nuevo.siguiente = nuevo;
                nuevo.anterior = nuevo;
                return;
            }


            if (posicion == 0 || posicion == 1)
            {
                nuevo.siguiente = top;
                top.anterior = nuevo;
                top = nuevo;
                bottom.siguiente = top;
                top.anterior = bottom;
                return;
            }


            int pos = 1;
            Nodo aux = top;

            while (pos < posicion && aux.siguiente != top)
            {
                aux = aux.siguiente;
                pos++;
            }


            if (aux != null)
            {
                nuevo.siguiente = aux;
                nuevo.anterior = aux.anterior;
                aux.anterior.siguiente = nuevo;
                aux.anterior = nuevo;
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


            while (pos < posicion && aux != null)
            {

                if (aux.siguiente != top)
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

                    top = aux.siguiente;
                    bottom.siguiente = top;
                    top.anterior = bottom;
                }
                else if (aux == bottom)
                {

                    bottom = aux.anterior;
                    bottom.siguiente = top;
                    top.anterior = bottom;
                }
                else
                {

                    aux.anterior.siguiente = aux.siguiente;
                    aux.siguiente.anterior = aux.anterior;
                }

                int dato = aux.dato;
                aux = null;
                return dato;
            }
            else
            {
                MessageBox.Show("No lo encontramos");
                return 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int dato, posicion;


            if (int.TryParse(textBox1.Text, out dato) && int.TryParse(textBox2.Text, out posicion))
            {
                if (posicion < 1)
                {
                    MessageBox.Show("La posición debe ser 1 o mayor.");
                    return;
                }


                insertar(posicion, dato);


                Lista();
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un dato y una posición válidos.");
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            int posicion;


            if (int.TryParse(textBox1.Text, out posicion))
            {
                if (posicion < 1)
                {
                    MessageBox.Show("La posición debe ser 1 o mayor.");
                    return;
                }


                int datoEliminado = eliminar(posicion);
                if (datoEliminado != 0 && datoEliminado != -1)
                {
                    MessageBox.Show($"Nodo eliminado: {datoEliminado}");
                }


                Lista();
            }
            else
            {
                MessageBox.Show("ingresa una posición válida.");
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
