using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_Calculadora
{
    public partial class frmCalculadora : Form
    {
        public frmCalculadora()
        {
            InitializeComponent();
        }
        // Criando as variáveis do sistema
        double a;
        double b;
        string c;

        private void btnUm_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "1";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "1";
            }
            btnCalcular.Focus();
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "2";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "2";
            }
            btnCalcular.Focus();
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "3";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "3";
            }
            btnCalcular.Focus();
        }

        private void btnQuatro_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "4";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "4";
            }
            btnCalcular.Focus();
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "5";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "5";
            }
            btnCalcular.Focus();
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "6";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "6";
            }
            btnCalcular.Focus();
        }

        private void btnSete_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "7";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "7";
            }
            btnCalcular.Focus();
        }

        private void btnOito_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "8";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "8";
            }
            btnCalcular.Focus();
        }

        private void btnNove_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "9";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "9";
            }
            btnCalcular.Focus();
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text == "")
            {
                txbEntrada.Text = "0";
            }
            else
            {
                txbEntrada.Text = txbEntrada.Text + "0";
            }
            btnCalcular.Focus();
        }

        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text.Contains(",") == false)
            {
               txbEntrada.Text = txbEntrada.Text + ",";
            } 
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(txbEntrada.Text);
            c = "/";
            txbEntrada.Clear();
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(txbEntrada.Text);
            c = "*";
            txbEntrada.Clear();
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(txbEntrada.Text);
            c = "-";
            txbEntrada.Clear();
        }

        private void btnSomar_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(txbEntrada.Text);
            c = "+";
            txbEntrada.Clear();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            a = 0;
            b = 0;
            c = "";
            txbEntrada.Clear();
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            try
            {
                txbEntrada.Text = txbEntrada.Text.Substring(0, txbEntrada.TextLength - 1);
            }
            catch (Exception)
            {

               
            }
           
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (txbEntrada.Text != string.Empty)
            {
                b = Convert.ToDouble(txbEntrada.Text);
                switch (c)
                {
                    case "/":
                        txbEntrada.Text = Convert.ToString(a / b);
                        break;
                    case "*":
                        txbEntrada.Text = Convert.ToString(a * b);
                        break;
                    case "+":
                        txbEntrada.Text = Convert.ToString(a + b);
                        break;
                    case "-":
                        txbEntrada.Text = Convert.ToString(a - b);
                        break;
                    default:
                        break;
                }
            }
        }

        private void frmCalculadora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                btnUm.PerformClick();
            }
            if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                btnDois.PerformClick();
            }
            if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            {
                btnTres.PerformClick();
            }
            if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
            {
                btnQuatro.PerformClick();
            }
            if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
            {
                btnCinco.PerformClick();
            }
            if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
            {
                btnSeis.PerformClick();
            }
            if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
            {
                btnSete.PerformClick();
            }
            if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
            {
                btnOito.PerformClick();
            }
            if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
            {
                btnNove.PerformClick();
            }
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
            {
                btnZero.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnApagar.PerformClick();
            }
            if (e.KeyCode == Keys.Add)
            {
                btnSomar.PerformClick();
            }
            if (e.KeyCode == Keys.Subtract)
            {
                btnSubtrair.PerformClick();
            }
            if (e.KeyCode == Keys.Multiply)
            {
                btnMultiplicar.PerformClick();
            }
            if (e.KeyCode == Keys.Divide)
            {
                btnDividir.PerformClick();
            }
            if (e.KeyValue == 188 || e.KeyValue == 110) // virgula açpha e numpad
            {
                btnVirgula.PerformClick();
            }
            if (e.KeyValue == 8)
            {
                btnBackspace.PerformClick();
            }
        }
    }
}
