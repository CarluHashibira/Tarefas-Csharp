using _06_CRUD.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_CRUD
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (VerificaCampos())
            {
                try
                {
                    string senhaCrypto = Crypto.sha256encrypt(txbSenha.Text);
                    senhaCrypto = senhaCrypto.ToLower();
                    Usuario.RealizarLogin(txbLogin.Text, senhaCrypto);
                    txbLogin.Clear();
                    txbSenha.Clear();
                    txbLogin.Focus();
                }
                catch (Exception erro)
                {

                    MessageBox.Show(erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private Boolean VerificaCampos()
        {
            if (txbLogin.Text == "")
            {
                MessageBox.Show("Campo obrigatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbLogin.Focus();
                return false;
            }
            if (txbSenha.Text == "")
            {
                MessageBox.Show("Campo obrigatorio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSenha.Focus();
                return false;
            }
            return true;
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja fechar o programa?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Pergunta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txbLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEntrar.PerformClick();
            }
        }

        private void txbSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEntrar.PerformClick();
            }
        }
    }
}
