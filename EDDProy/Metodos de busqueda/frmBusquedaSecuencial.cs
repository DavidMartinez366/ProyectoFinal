using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EDDemo.Metodos_de_busqueda
{
    public partial class frmBusquedaSecuencial : Form
    {
        private List<int> elementos;
        public frmBusquedaSecuencial()
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
                MessageBox.Show("Ingresa un número válido");
            }
        }

        public void BuscarElemento()
        {
            if (int.TryParse(textBox2.Text, out int buscado))
            {
                int indice = -1;
                for (int i = 0; i < elementos.Count; i++)
                {
                    if (elementos[i] == buscado)
                    {
                        indice = i;
                        break;
                    }
                }

                if (indice != -1)
                {
                    MessageBox.Show($"Elemento encontrado en la posición:{indice}");
                }
                else
                {
                    MessageBox.Show("El elemento no existe en la lista");
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarElemento();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuscarElemento();
        }
    }
}
