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
    public partial class frmExponente : Form
    {
        public frmExponente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0, n = 0;
            double resultado;
            x = Convert.ToInt32(textBox1.Text);
            n = Convert.ToInt32(textBox2.Text);
            resultado = Math.Pow(x, n);
            textBox3.Text = resultado.ToString();
        }
    }
}
