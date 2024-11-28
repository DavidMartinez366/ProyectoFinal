using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Metodos_de_ordenamiento
{
    public partial class frmBurbuja : Form
    {
        private List<int> elementos;

        public frmBurbuja()
        {
            InitializeComponent();
            elementos = new List<int>();
        }
        private void ActualizarLista()
        {
            listBox1.Items.Clear();
            foreach (int elemento in elementos)
            {
                listBox1.Items.Add(elemento);
            }
        }
        public void AgregarElemento()
        {
            if (int.TryParse(textBox1.Text, out int dato))
            {
                elementos.Add(dato);
                textBox1.Clear();
                ActualizarLista();
            }
            else
            {
                MessageBox.Show("Ingresa un numero valido");
            }
        }
        public void OrdenarBurbuja()
        {
            int n = elementos.Count;

            if (n <= 1)
            {
                MessageBox.Show("No hay suficientes elementos para ordenar");
                return;
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (elementos[j] > elementos[j + 1])
                    {
                        // Intercambio de valores
                        int temp = elementos[j];
                        elementos[j] = elementos[j + 1];
                        elementos[j + 1] = temp;
                    }
                }
            }
          
            ActualizarLista();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OrdenarBurbuja();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AgregarElemento();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
