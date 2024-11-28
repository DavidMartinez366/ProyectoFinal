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
    public partial class frmSumArreglo : Form
    {
        public frmSumArreglo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] valores = textBox3.Text.Split(',');
            int[] arreglo = Array.ConvertAll(valores, int.Parse);
            int suma = arreglo.Sum();
            textBox2.Text = suma.ToString();
        }
    }
}
