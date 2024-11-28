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
    public partial class frmIntercalacion : Form
    {
        private List<int> lista1; 
        private List<int> lista2; 

        public frmIntercalacion()
        {
            InitializeComponent();
            lista1 = new List<int>();
            lista2 = new List<int>();
        }
        private void ActualizarListBox(ListBox listBox, List<int> lista)
        {
            listBox.Items.Clear();
            foreach (int elemento in lista)
            {
                listBox.Items.Add(elemento);
            }
        }

        
        public void AgregarElemento(TextBox textBox, List<int> lista, ListBox listBox)
        {
            if (int.TryParse(textBox.Text, out int dato))
            {
                lista.Add(dato);
                textBox.Clear();
                lista.Sort(); 
                ActualizarListBox(listBox, lista);
            }
            else
            {
                MessageBox.Show("ingresa un número válido.");
            }
        }

       
        public List<int> IntercalarListas()
        {
            List<int> resultado = new List<int>();
            int i = 0, j = 0;

            while (i < lista1.Count && j < lista2.Count)
            {
                if (lista1[i] <= lista2[j])
                {
                    resultado.Add(lista1[i]);
                    i++;
                }
                else
                {
                    resultado.Add(lista2[j]);
                    j++;
                }
            }

            while (i < lista1.Count)
            {
                resultado.Add(lista1[i]);
                i++;
            }

            
            while (j < lista2.Count)
            {
                resultado.Add(lista2[j]);
                j++;
            }

            return resultado;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AgregarElemento(textBox2, lista2, listBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarElemento(textBox1, lista1, listBox1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lista1.Count == 0 && lista2.Count == 0)
            {
                MessageBox.Show("Ambas listas están vacías.");
                return;
            }

            List<int> resultado = IntercalarListas();
            ActualizarListBox(listBox3, resultado);
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
