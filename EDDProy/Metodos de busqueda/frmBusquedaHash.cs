using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Metodos_de_busqueda
{
    public partial class frmBusquedaHash : Form
    {
        private List<int>[] tablaHash;
        public frmBusquedaHash()
        {
            InitializeComponent(); tablaHash = new List<int>[10]; 
            for (int i = 0; i < tablaHash.Length; i++)
            {
                tablaHash[i] = new List<int>();
            }
        }
        private void ActualizarLista()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < tablaHash.Length; i++)
            {
                foreach (int elemento in tablaHash[i])
                {
                    listBox1.Items.Add(elemento);
                }
            }
        }

        private int FuncionHash(int clave)
        {
            return clave % tablaHash.Length; 
        }

        public void AgregarElemento()
        {
            if (int.TryParse(textBox1.Text, out int dato))
            {
                int indice = FuncionHash(dato);
                tablaHash[indice].Add(dato);
                textBox1.Clear();
                ActualizarLista();
            }
           
        }

        public void BuscarElemento()
        {
            if (int.TryParse(textBox2.Text, out int buscado))
            {
                int indice = FuncionHash(buscado);
                if (tablaHash[indice].Contains(buscado))
                {
                    MessageBox.Show($"Elemento {buscado} existe dentro de la lista");
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
