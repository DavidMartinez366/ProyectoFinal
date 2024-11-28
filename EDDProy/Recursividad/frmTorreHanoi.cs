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
    public partial class frmTorreHanoi : Form
    {
        public frmTorreHanoi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numDiscos = int.Parse(textBox1.Text);
            listBox1.Items.Clear();
            TorreDeHanoi(numDiscos, 'A', 'B', 'C');
        }
        private void TorreDeHanoi(int numDiscos, char Torre1, char Torre2, char aux)
        {
            if (numDiscos == 1)
            {
                listBox1.Items.Add($"Mover disco 1 de {Torre1} a {Torre2}");
            }
            else
            {
                TorreDeHanoi(numDiscos - 1, Torre1, aux, Torre2);
                listBox1.Items.Add($"Mover disco {numDiscos} de {Torre1} a {Torre2}");
                TorreDeHanoi(numDiscos - 1, aux, Torre2, Torre1);
            }
        }
    }

    }
