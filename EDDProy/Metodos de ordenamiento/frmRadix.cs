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
    public partial class frmRadix : Form
    {
        private List<int> elementos;
        public frmRadix()
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
                MessageBox.Show("Ingresa un número válido.");
            }
        }

        public void OrdenarRadix()
        {
            if (elementos.Count <= 1)
            {
                MessageBox.Show("No hay suficientes elementos para ordenar.");
                return;
            }

            
            int[] arreglo = elementos.ToArray();
            Radix(arreglo);

           
            elementos = new List<int>(arreglo);
            ActualizarLista();
        }

        private void Radix(int[] arr)
        {
            int max = ObtenerMaximo(arr);

            
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                Contar(arr, exp);
            }
        }

        private int ObtenerMaximo(int[] arr)
        {
            int max = arr[0];
            foreach (int num in arr)
            {
                if (num > max)
                    max = num;
            }
            return max;
        }

        private void Contar(int[] arr, int exp)
        {
            int n = arr.Length;
            int[] output = new int[n]; 
            int[] count = new int[10]; 

            
            for (int i = 0; i < n; i++)
            {
                int index = (arr[i] / exp) % 10;
                count[index]++;
            }

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            
            for (int i = n - 1; i >= 0; i--)
            {
                int index = (arr[i] / exp) % 10;
                output[count[index] - 1] = arr[i];
                count[index]--;
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AgregarElemento();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrdenarRadix();
        }
    }
}
