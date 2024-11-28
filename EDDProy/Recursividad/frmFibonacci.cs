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
    public partial class frmFibonacci : Form
    {
        public frmFibonacci()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cantidad = int.Parse(textBox1.Text);
            if (cantidad <= 0)
            {
                MessageBox.Show("ingresa un numero diferente de 0");
                return;
            }

            listBox1.ClearSelected();
            int[] fibonacci = GenerarFibonacci(cantidad);
            foreach (int num in fibonacci)
            {
                listBox1.Items.Add(num);
            }
        }
        private int[] GenerarFibonacci(int cantidad)
        {
            int[] fibonacci = new int[cantidad];
            if (cantidad >= 1) fibonacci[0] = 0;
            if (cantidad >= 2) fibonacci[1] = 1;
            for (int i = 2; i < cantidad; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }

            return fibonacci;

        }
    }
}
