using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDDemo.Estructuras_Lineales;
using EDDemo.Estructuras_Lineales.Clases;
using EDDemo.Estructuras_No_Lineales;
using EDDemo.Metodos_de_busqueda;
using EDDemo.Metodos_de_ordenamiento;
using EDDemo.Recursividad;

namespace EDDemo
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pilasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPilas mPilas = new frmPilas();
            mPilas.MdiParent = this;
            mPilas.Show();
        }

        private void estructurasLinealesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void arbolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArboles mArboles = new frmArboles();
            mArboles.MdiParent = this;
            mArboles.Show();
        }

        private void colasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmColas mColas = new frmColas();
            mColas.MdiParent = this;
            mColas.Show();
        }

        private void listasSimplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListasS mListasS = new frmListasS();
            mListasS.MdiParent = this;
            mListasS.Show();
        }

        private void listasDoblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListasD mListasD = new frmListasD();
            mListasD.MdiParent = this;
            mListasD.Show();
        }

        private void listasCircularesSimplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListasCS mListasCS = new frmListasCS();
            mListasCS.MdiParent = this;
            mListasCS.Show();
        }

        private void listasCircularesDoblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListasC mListasC = new frmListasC();
            mListasC.MdiParent = this;
            mListasC.Show();
        }

        private void factorialDeUnNumeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactorial mFactorial = new frmFactorial();
            mFactorial.MdiParent = this;
            mFactorial.Show();
        }

        private void calculoDeUnExponenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExponente mExponemte = new frmExponente();
            mExponemte.MdiParent = this;
            mExponemte.Show();
        }

        private void sumaDeUnArregloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSumArreglo frmSumArreglo = new frmSumArreglo();
            frmSumArreglo.MdiParent = this; 
            frmSumArreglo.Show();   
        }

        private void secuenciaDeFibonacciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFibonacci mFibonacci = new frmFibonacci();   
            mFibonacci.MdiParent = this;    
            mFibonacci.Show();  
        }

        private void torreDeHanoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBbinaria mBbinaria = new frmBbinaria();
            mBbinaria.MdiParent = this;
            mBbinaria.Show();
        }

        private void torreDeHanoiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTorreHanoi mTorreHanoi = new frmTorreHanoi();    
            mTorreHanoi.MdiParent = this;   
            mTorreHanoi.Show();
        }

        private void metodoBurbujaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBurbuja mBurbuja = new frmBurbuja();
            mBurbuja.MdiParent = this;
            mBurbuja.Show();
        }

        private void intercalacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIntercalacion mIntercalacion = new frmIntercalacion();   
            mIntercalacion.MdiParent = this;
            mIntercalacion.Show();
        }

        private void shellsortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShellsort mShellsort = new frmShellsort();
            mShellsort.MdiParent= this;
            mShellsort.Show();
        }

        private void mezclaNaturalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMezclaN mMezclaN = new frmMezclaN();
            mMezclaN.MdiParent = this;
            mMezclaN.Show();
        }

        private void quickSortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuickSort mQuickSort = new frmQuickSort();
            mQuickSort.MdiParent = this;
            mQuickSort.Show();

        }

        private void radixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRadix frmRadix = new frmRadix();
            frmRadix.MdiParent = this;
            frmRadix.Show();
        }

        private void mezclaDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMezclaD mMezclaD = new frmMezclaD(); 
            mMezclaD.MdiParent = this;
            mMezclaD.Show();
        }

        private void busquedaSecuencialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusquedaSecuencial mBusquedaS = new frmBusquedaSecuencial();
            mBusquedaS.MdiParent = this;
            mBusquedaS.Show();

        }

        private void busquedaHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusquedaHash mBusquedaHash = new frmBusquedaHash();
            mBusquedaHash.MdiParent = this;
            mBusquedaHash.Show();
        }
    }
}
