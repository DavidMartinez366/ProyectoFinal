using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Recursividad
{
    public partial class frmBbinaria : Form
    {
        public frmBbinaria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] arreglo = textBox1.Text.Split(',').Select(int.Parse).ToArray();
            Array.Sort(arreglo);
            int numeroABuscar = int.Parse(textBox2.Text);
            int indice = BusquedaBinaria(arreglo, numeroABuscar);

            if (indice != -1)
            {
                textBox3.Text = indice.ToString();
            }
            else
            {
                textBox3.Text = indice.ToString("No encontrado");
            }
        }
        private int BusquedaBinaria(int[] arreglo, int valor)
        {
            int izquierda = 0;
            int derecha = arreglo.Length - 1;
            while (izquierda <= derecha)
            {
                int medio = (izquierda + derecha) / 2;
                if (arreglo[medio] == valor)
                {
                    return medio;
                }
                else if (arreglo[medio] < valor)
                {

                    izquierda = medio + 1;
                }
                else
                {
                    derecha = medio - 1;
                }
            }
            return -1;
        }
    }
}
