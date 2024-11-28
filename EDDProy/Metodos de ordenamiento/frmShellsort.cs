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
    public partial class frmShellsort : Form
    {
        private List<int> elementos;

        public frmShellsort()
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
                MessageBox.Show("ingresa un número válido.");
            }
        }

      
        public void OrdenarShellsort()
        {
            int n = elementos.Count;

            if (n <= 1)
            {
                MessageBox.Show("No hay suficientes elementos para ordenar");
                return;
            }        
            for (int interval = n/2; interval > 0; interval /= 2)
            {
                for (int i = interval; i < n; i++)
                {
                    int aux = elementos[i];
                    int j;
                    for (j = i; j >= interval && elementos[j - interval] > aux; j -= interval)
                    {
                        elementos[j] = elementos[j - interval];
                    }
                    elementos[j] = aux;
                }
            }
            ActualizarLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarElemento();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrdenarShellsort();
        }
    }
}
