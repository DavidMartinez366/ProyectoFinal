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
    public partial class frmMezclaN : Form
    {
        private List<int> elementos;
        public frmMezclaN()
        {
            elementos = new List<int>();
            InitializeComponent();
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
        public List<int> MezclaOriginal(List<int> lista)
        {
           
            if (lista.Count <= 1)
            {
                return lista;
            }          
            int mitad = lista.Count / 2;
            List<int> izquierda = lista.GetRange(0, mitad);
            List<int> derecha = lista.GetRange(mitad, lista.Count - mitad);           
            izquierda = MezclaOriginal(izquierda);
            derecha = MezclaOriginal(derecha);
            return MezclarListas(izquierda, derecha);
        }

        
        private List<int> MezclarListas(List<int> izquierda, List<int> derecha)
        {
            List<int> resultado = new List<int>();
            int i = 0, j = 0;

           
            while (i < izquierda.Count && j < derecha.Count)
            {
                if (izquierda[i] <= derecha[j])
                {
                    resultado.Add(izquierda[i]);
                    i++;
                }
                else
                {
                    resultado.Add(derecha[j]);
                    j++;
                }
            }

           
            while (i < izquierda.Count)
            {
                resultado.Add(izquierda[i]);
                i++;
            }

         
            while (j < derecha.Count)
            {
                resultado.Add(derecha[j]);
                j++;
            }

            return resultado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarElemento();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (elementos.Count <= 1)
            {
                MessageBox.Show("No hay suficientes elementos para ordenar.");
                return;
            }

            elementos = MezclaOriginal(elementos);         
            ActualizarLista();

        }
    }
}
