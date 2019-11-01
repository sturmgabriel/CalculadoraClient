using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraClient
{
    public partial class Form1 : Form
    {
        static string[] original = new string[] { " ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        static string[] cripto = new string[] { "@", "z", "y", "x", "w", "v", "u", "t", "s", "r", "q", "p", "o", "n", "m", "l", "k", "j", "i", "h", "g", "f", "e", "d", "c", "b", "a" };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strValor1 = text1.ToString();
            string strValor2 = text2.ToString();
            string operador = comboBox1.ToString();

            string strValor1_cripto = Criptografar(strValor1);
            string strValor2_cripto = Criptografar(strValor2);
            string operador_cripto = Criptografar(operador);

            string strValor1_bin = binarizar(strValor1_cripto);
            string strValor2_bin = binarizar(strValor2_cripto);
            string operador_bin = binarizar(operador_cripto);
        }

        private string binarizar(string strValor1_cripto)
        {
            throw new NotImplementedException();
        }
        
        private string Criptografar(string valor)
        {
            int numero = valor.Length;

            char[] letras = new char[numero];
            string[] letrascript = new string[numero];

            letras = valor.ToCharArray();


            for (int i = 0; i < letras.Length; i++)
            {
                for (int j = 0; j < original.Length; j++)
                {
                    if (Convert.ToString(letras[i]) == original[j])
                    {
                        letrascript[i] = cripto[j];
                    }
                }

            }

            string palavracripto = "";

            foreach (var item in letrascript)
            {
                palavracripto = palavracripto + "" + item;
            }

            return palavracripto;

        }

        private static void decriptografar(string valor)
        {
            int numero = valor.Length;

            char[] letras = new char[numero];
            string[] letrascript = new string[numero];

            letras = valor.ToCharArray();


            for (int i = 0; i < letras.Length; i++)
            {
                for (int j = 0; j < original.Length; j++)
                {
                    if (Convert.ToString(letras[i]) == cripto[j])
                    {
                        letrascript[i] = original[j];
                    }
                }

            }

            string palavracripto = "";

            foreach (var item in letrascript)
            {
                palavracripto = palavracripto + "" + item;
            }

            Console.WriteLine(palavracripto);
        }


    }
}
