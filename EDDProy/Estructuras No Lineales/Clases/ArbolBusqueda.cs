using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Estructuras_No_Lineales
{
    public class ArbolBusqueda
    {

        NodoBinario Raiz;
        public String strArbol;
        public String strRecorrido;

        public ArbolBusqueda()
        {
            Raiz = null;
            strArbol = "";
            strRecorrido = "";
        }
        public bool BuscarNodo(int valor, NodoBinario nodo)
        {
            if (nodo == null)
                return false;

            if (nodo.Dato == valor)
                return true;
            else if (valor < nodo.Dato)
                return BuscarNodo(valor, nodo.Izq);
            else
                return BuscarNodo(valor, nodo.Der);
        }


        public Boolean EstaVacio()
        {
            if (Raiz == null)
                return true;
            else
                return false;
        }
        public NodoBinario RegresaRaiz()
        {
            return Raiz;
        }

        public void InsertaNodo(int Dato, ref NodoBinario Nodo)
        {
            if (Nodo == null)
            {
                Nodo = new NodoBinario(Dato);
                // CAMBIO 2

                if (Raiz == null)
                    Raiz = Nodo;
            }
            else if (Dato < Nodo.Dato)
                InsertaNodo(Dato, ref Nodo.Izq);
            else if (Dato > Nodo.Dato)
                InsertaNodo(Dato, ref Nodo.Der);
        }
        public void MuestraArbolAcostado(int nivel, NodoBinario nodo)
        {
            if (nodo == null)
                return;
            MuestraArbolAcostado(nivel + 1, nodo.Der);
            for (int i = 0; i < nivel; i++)
            {
                strArbol = strArbol + "      ";
            }
            strArbol = strArbol + nodo.Dato.ToString() + "\r\n";
            MuestraArbolAcostado(nivel + 1, nodo.Izq);
        }

        public void PodarHojas(ref NodoBinario nodo)
        {
            if (nodo == null)
                return;


            if (nodo.Izq != null && nodo.Izq.Izq == null && nodo.Izq.Der == null)
                nodo.Izq = null;
            else
                PodarHojas(ref nodo.Izq);


            if (nodo.Der != null && nodo.Der.Izq == null && nodo.Der.Der == null)
                nodo.Der = null;
            else
                PodarHojas(ref nodo.Der);


        }
        public void PodarHojas()
        {
            if (Raiz == null)
            {
                MessageBox.Show("El árbol está vacío.");
                return;
            }

            PodarHojas(ref Raiz);
        }
        public void podarArbol(NodoBinario nodo)
        {
            if (nodo == null)
                return;

            podarArbol(nodo.Izq);
            podarArbol(nodo.Der);

            nodo = null;

            return;

        }
        public void podarArbol()
        {
            podarArbol(Raiz);
            Raiz = null;
        }
        public String ToDot(NodoBinario nodo)
        {
            StringBuilder b = new StringBuilder();
            if (nodo.Izq != null)
            {
                b.AppendFormat("{0}->{1} [side=L] {2} ", nodo.Dato.ToString(), nodo.Izq.Dato.ToString(), Environment.NewLine);
                b.Append(ToDot(nodo.Izq));
            }

            if (nodo.Der != null)
            {
                b.AppendFormat("{0}->{1} [side=R] {2} ", nodo.Dato.ToString(), nodo.Der.Dato.ToString(), Environment.NewLine);
                b.Append(ToDot(nodo.Der));
            }
            return b.ToString();
        }


        private void EliminarNodo(ref NodoBinario nodo, int valor)
        {
            if (nodo == null)
                return;

            if (valor < nodo.Dato)
            {

                EliminarNodo(ref nodo.Izq, valor);
            }
            else if (valor > nodo.Dato)
            {

                EliminarNodo(ref nodo.Der, valor);
            }
            else
            {
                if (nodo.Izq == null && nodo.Der == null)
                {

                    nodo = null;
                }
                else if (nodo.Izq != null && nodo.Der == null)
                {

                    nodo = nodo.Izq;
                }
                else if (nodo.Izq == null && nodo.Der != null)
                {

                    nodo = nodo.Der;
                }
                else
                {

                    NodoBinario predecesor = ObtenerPredecesor(nodo.Izq);
                    nodo.Dato = predecesor.Dato;
                    EliminarNodo(ref nodo.Izq, predecesor.Dato);
                }

            }
        }
        public void EliminarNodo(int valor)
        {
            EliminarNodo(ref Raiz, valor);
        }
        private void EliminarNodoConSucesor(ref NodoBinario nodo, int valor)
        {
            if (nodo == null)
                return;

            if (valor < nodo.Dato)
            {

                EliminarNodoConSucesor(ref nodo.Izq, valor);
            }
            else if (valor > nodo.Dato)
            {

                EliminarNodoConSucesor(ref nodo.Der, valor);
            }
            else
            {
                if (nodo.Izq == null && nodo.Der == null)
                {

                    nodo = null;
                }
                else if (nodo.Izq != null && nodo.Der == null)
                {

                    nodo = nodo.Izq;
                }
                else if (nodo.Izq == null && nodo.Der != null)
                {

                    nodo = nodo.Der;
                }
                else
                {

                    NodoBinario sucesor = ObtenerSucesor(nodo.Der);
                    nodo.Dato = sucesor.Dato;
                    EliminarNodoConSucesor(ref nodo.Der, sucesor.Dato);
                }
            }
        }
        private NodoBinario ObtenerSucesor(NodoBinario nodo)
        {
            while (nodo.Izq != null)
            {
                nodo = nodo.Izq;
            }
            return nodo;
        }
        public void EliminarNodoConSucesor(int valor)
        {
            EliminarNodoConSucesor(ref Raiz, valor);
        }

        private NodoBinario ObtenerPredecesor(NodoBinario nodo)
        {
            while (nodo.Der != null)
            {
                nodo = nodo.Der;
            }
            return nodo;

        }
        public string RecorrerPorNiveles(NodoBinario raiz)
        {
            if (raiz == null)
                return "El árbol está vacío.";

            Queue<NodoBinario> cola = new Queue<NodoBinario>();
            StringBuilder resultado = new StringBuilder();

            cola.Enqueue(raiz);

            while (cola.Count > 0)
            {
                NodoBinario nodoActual = cola.Dequeue();
                resultado.Append(nodoActual.Dato + " ");

                if (nodoActual.Izq != null)
                    cola.Enqueue(nodoActual.Izq);
                if (nodoActual.Der != null)
                    cola.Enqueue(nodoActual.Der);
            }

            return resultado.ToString();
        }
        public int ObtenerAltura(NodoBinario nodo)
        {
            if (nodo == null)
                return 0;

            int alturaIzquierda = ObtenerAltura(nodo.Izq);
            int alturaDerecha = ObtenerAltura(nodo.Der);


            return Math.Max(alturaIzquierda, alturaDerecha) + 1;
        }

        public int ContarHojas(NodoBinario nodo)
        {
            if (nodo == null)
                return 0;


            if (nodo.Izq == null && nodo.Der == null)
            {
                return 1;
            }


            int hojasIzq = ContarHojas(nodo.Izq);
            int hojasDer = ContarHojas(nodo.Der);


            return hojasIzq + hojasDer;
        }
        public int ContarNodos(NodoBinario nodo)
        {
            if (nodo == null)
                return 0;


            int nodosIzq = ContarNodos(nodo.Izq);
            int nodosDer = ContarNodos(nodo.Der);


            return 1 + nodosIzq + nodosDer;
        }
        public class ArbolBinarioCompleto
        {
            public bool EsCompleto(NodoBinario raiz)
            {
                if (raiz == null)
                    return true;

                int totalNodos = ContarNodos(raiz);
                return EsCompletoRecursivo(raiz, 0, totalNodos);
            }

            private bool EsCompletoRecursivo(NodoBinario nodo, int indice, int totalNodos)
            {
                if (nodo == null)
                    return true;


                if (indice >= totalNodos)
                    return false;


                return EsCompletoRecursivo(nodo.Izq, 2 * indice + 1, totalNodos) &&
                       EsCompletoRecursivo(nodo.Der, 2 * indice + 2, totalNodos);
            }

            private int ContarNodos(NodoBinario nodo)
            {
                if (nodo == null)
                    return 0;
                return 1 + ContarNodos(nodo.Izq) + ContarNodos(nodo.Der);
            }
        }
        public class ArbolBinarioLleno
        {
            public bool EsLleno(NodoBinario raiz)
            {
                if (raiz == null)
                    return true;

                int altura = ObtenerAltura(raiz);
                return EsLlenoRecursivo(raiz, 0, altura);
            }

            private bool EsLlenoRecursivo(NodoBinario nodo, int nivelActual, int altura)
            {
                if (nodo == null)
                    return true;


                if (nodo.Izq == null && nodo.Der == null)
                    return nivelActual == altura - 1;


                if (nodo.Izq == null || nodo.Der == null)
                    return false;


                return EsLlenoRecursivo(nodo.Izq, nivelActual + 1, altura) &&
                       EsLlenoRecursivo(nodo.Der, nivelActual + 1, altura);
            }

            private int ObtenerAltura(NodoBinario nodo)
            {
                if (nodo == null)
                    return 0;
                return 1 + Math.Max(ObtenerAltura(nodo.Izq), ObtenerAltura(nodo.Der));
            }
        }


        public void PreOrden(NodoBinario nodo)

        {
            if (nodo == null)
                return;

            strRecorrido = strRecorrido + nodo.Dato + ", ";
            PreOrden(nodo.Izq);
            PreOrden(nodo.Der);

            return;
        }

        public void InOrden(NodoBinario nodo)
        {
            if (nodo == null)
                return;

            InOrden(nodo.Izq);
            strRecorrido = strRecorrido + nodo.Dato + ", ";
            InOrden(nodo.Der);

            return;
        }
        public void PostOrden(NodoBinario nodo)
        {
            if (nodo == null)
                return;

            PostOrden(nodo.Izq);
            PostOrden(nodo.Der);
            strRecorrido = strRecorrido + nodo.Dato + ", ";

            return;
        }

    }
}