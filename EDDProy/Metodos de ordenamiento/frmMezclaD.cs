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
    public partial class frmMezclaD : Form
    {
        private List<int> elementos;
        public frmMezclaD()
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

        public void OrdenarMezclaDirecta()
        {
            if (elementos.Count <= 1)
            {
                MessageBox.Show("No hay suficientes elementos para ordenar.");
                return;
            }

            
            int[] arreglo = elementos.ToArray();
            MergeSort(arreglo, 0, arreglo.Length - 1);

           
            elementos = new List<int>(arreglo);
            ActualizarLista();
        }

        private void MergeSort(int[] arr, int izq, int der)
        {
            if (izq < der)
            {
                int centro = izq + (der - izq) / 2;

              
                MergeSort(arr, izq, centro);
                MergeSort(arr, centro + 1, der);

               
                Merge(arr, izq, centro, der);
            }
        }

        private void Merge(int[] arr, int izq, int centro, int der)
        {
            int n1 = centro - izq + 1;
            int n2 = der - centro;

            
            int[] leftArray = new int[n1];
            int[] derarr = new int[n2];

            for (int i = 0; i < n1; i++)
                leftArray[i] = arr[izq + i];
            for (int j = 0; j < n2; j++)
                derarr[j] = arr[centro + 1 + j];

            
            int iizq = 0, ider = 0, k = izq;

            while (iizq < n1 && ider < n2)
            {
                if (leftArray[iizq] <= derarr[ider])
                {
                    arr[k] = leftArray[iizq];
                    iizq++;
                }
                else
                {
                    arr[k] = derarr[ider];
                    ider++;
                }
                k++;
            }

            
            while (iizq < n1)
            {
                arr[k] = leftArray[iizq];
                iizq++;
                k++;
            }

            
            while (ider < n2)
            {
                arr[k] = derarr[ider];
                ider++;
                k++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarElemento();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrdenarMezclaDirecta();
        }
    }
}
