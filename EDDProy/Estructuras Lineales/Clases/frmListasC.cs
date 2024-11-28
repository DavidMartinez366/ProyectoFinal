using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Estructuras_Lineales.Clases
{
    public partial class frmListasC : Form
    {
        public frmListasC()
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
        public void insertar(int Dato, int posicion)
        {
            Nodo Nuevo = new Nodo(Dato);



            if (top == null && bottom == null)
            {
                top = Nuevo;
                bottom = Nuevo;
                Nuevo.siguiente = top;
                return;
            }


            if (posicion == 0 || posicion == 1)
            {
                Nuevo.siguiente = top;
                top = Nuevo;
                bottom.siguiente = top;
                return;
            }


            int posicion1 = 1;
            Nodo Aux = top;


            while (posicion1 < posicion - 1 && Aux.siguiente != top)
            {
                Aux = Aux.siguiente;
                posicion1++;
            }


            if (Aux == bottom)
            {
                Nuevo.siguiente = top;
                bottom.siguiente = Nuevo;
                bottom = Nuevo;
            }

            else
            {
                Nuevo.siguiente = Aux.siguiente;
                Aux.siguiente = Nuevo;
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
            Nodo previo = null;
            int dato;


            while (pos < posicion && aux != null)
            {

                if (aux.siguiente != top)
                {
                    previo = aux;
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

                if (aux == bottom)
                {
                    bottom = previo;
                    if (previo != null)
                    {
                        previo.siguiente = aux.siguiente;
                    }
                }
                else
                {

                    if (previo != null)
                    {
                        previo.siguiente = aux.siguiente;
                    }
                    else
                    {

                        top = aux.siguiente;
                        bottom.siguiente = top;
                    }
                }

                dato = aux.dato;
                aux = null;
                return dato;
            }
            else
            {
                MessageBox.Show("No se encontro en la lista");
                return 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int dato;
            int posicion;


            if (int.TryParse(textBox1.Text, out dato) && int.TryParse(textBox2.Text, out posicion))
            {
                if (posicion < 1)
                {
                    MessageBox.Show("el dato ingresado debe ser 1 o mayor");
                    return;

                }
                insertar(dato, posicion);
                Lista();
            }
            else
            {
                MessageBox.Show("ingresa un dato y una posición válidos");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int posicion;


            if (int.TryParse(textBox2.Text, out posicion))
            {
                if (posicion < 1)
                {
                    MessageBox.Show("La posición debe ser 1 o mayor.");
                    return;
                }


                int datoEliminado = eliminar(posicion);
                if (datoEliminado != 0 && datoEliminado != -1)
                {
                    MessageBox.Show($"se elimino el nodo: {datoEliminado}");
                }


                Lista();
            }
            else
            {
                MessageBox.Show("ingresa un dato valido");
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
