using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraClient
{
    public partial class Form1 : Form
    {
        static string[] original = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "+", "-", "*", "/", "=", ","};

        static string[] cripto = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p"};

        string strValor1_Retorno;
        string operador_Retorno;
        string strValor2_Retorno;
        string resultado_Retorno;

        public Form1()
        {
            InitializeComponent();
        }

        #region Envio
        private void button1_Click(object sender, EventArgs e)
        {
            string strValor1 = text1.Text.ToString();
            string strValor2 = text2.Text.ToString();
            string operador = comboBox1.SelectedItem.ToString();

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
            if (System.IO.File.Exists(@"C:\temp\Envio.txt"))
            {
                try
                {
                    System.IO.File.Delete(@"C:\temp\Envio.txt");
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            string nomeArquivo = @"C:\temp\Envio.txt";

            StreamWriter writer = new StreamWriter(nomeArquivo);

            writer.WriteLine(strValor1_bin);
            writer.WriteLine(operador_bin);
            writer.WriteLine(strValor2_bin);
            writer.Close();

        }

        private string binarizar(string strValor1_cripto)
        {
            int[] numeros = new int[5];

            string ret = "";

            foreach (char c in strValor1_cripto)
            {
                int asc = (int)c;

                ret += Convert.ToString(asc, 2) + " ";
            }

            return (ret);
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

        #endregion

        #region Retorno
        private void button2_Click(object sender, EventArgs e)
        {
            lerArquivoResposta();

            string strValor1_debin = Debinarizar(strValor1_Retorno);
            string strValor2_debin = Debinarizar(strValor2_Retorno);
            string operador_debin = Debinarizar(operador_Retorno);
            string resultado_debin = Debinarizar(resultado_Retorno);

            string strValor1_decripto = Decriptografar(strValor1_debin);
            string strValor2_decripto = Decriptografar(strValor2_debin);
            string operador_decripto = Decriptografar(operador_debin);
            string resultado_decripto = Decriptografar(resultado_debin);

            label4.Text = "Resultado: " + strValor1_decripto + " " + operador_decripto + " " + strValor2_decripto + " = " + resultado_decripto;

        }

        private string Debinarizar(string strValor1_cripto)
        {
            string[] strBin = strValor1_cripto.Trim().Split(' ');
            string rec = "";

            foreach (string ele in strBin)
            {
                char car = (char)Convert.ToInt32(ele, 2);

                rec += car;
            }
            
            return rec;
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
            string[] lines = System.IO.File.ReadAllLines(@"C:\Temp\Retorno.txt");
            
            strValor1_Retorno = Convert.ToString(lines[0]);
            operador_Retorno = Convert.ToString(lines[1]);
            strValor2_Retorno = Convert.ToString(lines[2]);
            resultado_Retorno = Convert.ToString(lines[3]);
            
        }

        #endregion


        private void text1_TextChanged(object sender, EventArgs e)
        {
            text1.Text = Regex.Replace(text1.Text, "[^0-9^,]", "");
        }

        private void text2_TextChanged(object sender, EventArgs e)
        {
            text2.Text = Regex.Replace(text2.Text, "[^0-9^,]", "");
        }
    }
}
