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
        static string[] original = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "+", "-", "*", "/", "="};

        static string[] cripto = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o"};

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

            gerarArquivoEnvio(strValor1_bin, strValor2_bin, operador_bin);

        }

        private void gerarArquivoEnvio(string strValor1_bin, string strValor2_bin, string operador_bin)
        {
            throw new NotImplementedException();
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
        
        private void button2_Click(object sender, EventArgs e)
        {
            lerArquivoResposta();

            string strValor1 = ""; //valor vindo do arquivo 
            string strValor2 = ""; //valor vindo do arquivo
            string operador = ""; //valor vindo do arquivo
            string resultado = ""; //valor vindo do arquivo

            string strValor1_debin = Debinarizar(strValor1);
            string strValor2_debin = Debinarizar(strValor2);
            string operador_debin = Debinarizar(operador);
            string resultado_debin = Debinarizar(resultado);

            string strValor1_decripto = Decriptografar(strValor1_debin);
            string strValor2_decripto = Decriptografar(strValor2_debin);
            string operador_decripto = Decriptografar(operador_debin);
            string resultado_decripto = Decriptografar(resultado_debin);


        }

        private string Debinarizar(string strValor1_cripto)
        {
            throw new NotImplementedException();
        }

        private string Decriptografar(string strValor1)
        {
            int numero = strValor1.Length;

            char[] letras = new char[numero];
            string[] letrascript = new string[numero];

            letras = strValor1.ToCharArray();


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

            return palavracripto;
        }

        private void lerArquivoResposta()
        {
            throw new NotImplementedException();
        }
    }
}
