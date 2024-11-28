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
    public partial class frmFactorial : Form
    {
        public frmFactorial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int factorial = 0;
            int total = 1;
            factorial = Convert.ToInt32(textBox1.Text);

            for (int i = 1; i <= factorial; i++)
            {
                total = total * i;
            }
            textBox2.Text = total.ToString();
        }
    }
}
