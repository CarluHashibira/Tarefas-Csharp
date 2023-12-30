using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_CalcularFrete
{
    public partial class frmFrete : Form
    {
        public frmFrete()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaDados();
        }

        private void LimpaDados()
        {
            // Resetando os campos
            txbNome.Clear();
            txbValor.Clear();
            cbbEstado.SelectedIndex = 0;
            lblFrete.Text = "";
            lblTotal.Text = "";
            lblValor.Text = "";
            txbNome.Focus();
            lblNome.Text = "";
        }

        private void frmFrete_Load(object sender, EventArgs e)
        {
            cbbEstado.SelectedIndex = 0;
        }

        public Boolean VerificaCampos()
        {
            if (txbNome.Text == string.Empty)
            {
                MessageBox.Show("Campo obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbNome.Focus();
                return false;
            }
            if (txbValor.Text == string.Empty)
            {
                MessageBox.Show("Campo obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbValor.Focus();
                return false;
            }
            if (cbbEstado.Text == "Selecione")
            {
                MessageBox.Show("Campo obrigatório", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbEstado.Focus();
                return false;
            }
            return true;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (VerificaCampos())
            {
                Calculo();
            }
        }

        private void txbValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        public void Calculo()
        {
            //Declarando as variaveis
            string nome = txbNome.Text;
            double valor = Convert.ToDouble(txbValor.Text);
            string estado = cbbEstado.SelectedItem.ToString();
            double frete = 0, total = 0;

            //Calculo do frete
            if (valor > 1000)
            {
                frete = 0;
            }
            else
            {
                switch (estado)
                {
                    case "SP":
                        frete = 5;
                        break;
                    case "RJ":
                        frete = 10;
                        break;
                    case "AM":
                        frete = 20;
                        break;
                    default:
                        frete = 15;
                        break;
                }
            }

            //A variavel total recebe o valor digitado + o frete
            total = valor + frete;

            //Mostrar os valores nos labels
            lblNome.Text = nome;
            lblValor.Text = valor.ToString("c");
            lblFrete.Text = frete.ToString("c");
            lblTotal.Text = total.ToString("c");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lblValor_Click(object sender, EventArgs e)
        {

        }
    }
}
