using SisVendas.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisVendas
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private Boolean VerificaVazio()
        {
            if (txbLogin.Text == string.Empty)
            {
                MessageBox.Show("Atenção, digite seu usuário!", "Sistema de Vandas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbLogin.Focus();
                return false;
            }
            if (txbSenha.Text == string.Empty)
            {
                MessageBox.Show("Atenção, digite sua senha!", "Sistema de Vendas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbSenha.Focus();
                return false;
            }
            return true;
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (VerificaVazio())
            {
                try
                {
                    string senhaCrypto = Crypto.sha256encrypt(txbSenha.Text);
                    senhaCrypto = senhaCrypto.ToLower();
                    Usuario.RealizarLogin(txbLogin.Text, senhaCrypto);
                    txbLogin.Text = string.Empty;
                    txbSenha.Text = string.Empty;
                    txbLogin.Focus();
                }
                catch (Exception erro)
                {

                    MessageBox.Show(erro.Message, "Sistema de Vendas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (erro.Message.Contains("Usuário não cadastrado"))
                    {
                        txbLogin.Text = string.Empty;
                        txbLogin.Focus();
                    }
                    if (erro.Message.Contains("Senha inválida"))
                    {
                        txbSenha.Text = string.Empty;
                        txbSenha.Focus();
                    }
                    if (erro.Message.Contains("Usuário bloqueado"))
                    {
                        MessageBox.Show("Favor entre em contato com o Administrador!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
