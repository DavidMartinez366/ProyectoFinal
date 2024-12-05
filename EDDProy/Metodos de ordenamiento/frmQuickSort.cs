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
    public partial class frmQuickSort : Form
    {
        private List<int> elementos;
        public frmQuickSort()
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
                MessageBox.Show("Ingresa un número valido");
            }
        }

        public void OrdenarQuickSort()
        {
            if (elementos.Count <= 1)
            {
                MessageBox.Show("No hay suficientes elementos para ordenar");
                return;
            }

            QuickSort(0, elementos.Count - 1);
            ActualizarLista();
        }

        private void QuickSort(int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(low, high);

                
                QuickSort(low, partitionIndex - 1);
                QuickSort(partitionIndex + 1, high);
            }
        }

        private int Partition(int low, int high)
        {
            int pivot = elementos[high]; 
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (elementos[j] <= pivot)
                {
                    i++;
                    
                    Intercambiar(i, j);
                }
            }

           
            Intercambiar(i + 1, high);
            return i + 1;
        }

        private void Intercambiar(int i, int j)
        {
            int temp = elementos[i];
            elementos[i] = elementos[j];
            elementos[j] = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarElemento();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrdenarQuickSort();
        }
    }
}
