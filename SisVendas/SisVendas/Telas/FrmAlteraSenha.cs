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

namespace SisVendas.Telas
{
    public partial class FrmAlteraSenha : Form
    {
        Usuario usuarioLogado = new Usuario();

        public FrmAlteraSenha(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void toolStripAlterar_Click(object sender, EventArgs e)
        {
            if (VerificaVazio())
            {
                string senhaAtual = Crypto.sha256encrypt(txbSenhaAtual.Text);
                senhaAtual = senhaAtual.ToLower();

                string senhaNova = Crypto.sha256encrypt(txbSenha.Text);
                senhaNova = senhaNova.ToLower();

                if (senhaAtual == usuarioLogado.Senha)
                {
                    Usuario TrocaSenha = new Usuario(usuarioLogado.Id_usuario, senhaNova, txbFrase.Text);
                    TrocaSenha.AlteraSenha();
                    MessageBox.Show("Por favor, faça seu login novamente", "Altera Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sua senha atual não confere!", "Altera senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private Boolean VerificaVazio()
        {
            if (txbSenhaAtual.Text == string.Empty)
            {
                MessageBox.Show("Campo senha atual obrigatório", "Altera Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSenhaAtual.Focus();
                return false;
            }
            if (txbSenha.Text == string.Empty)
            {
                MessageBox.Show("Campo nova senha obrigatório", "Altera Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSenha.Focus();
                return false;
            }
            if (txbRepitaSenha.Text == string.Empty)
            {
                MessageBox.Show("Campo repita a senha obrigatório", "Altera Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbRepitaSenha.Focus();
                return false;
            }
            if (txbSenha.Text != txbRepitaSenha.Text)
            {
                MessageBox.Show("As novas senhas não conferem", "Altera Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSenha.Text = string.Empty;
                txbRepitaSenha.Text = string.Empty;
                txbSenha.Focus();
                return false;
            }
            if (txbFrase.Text == string.Empty)
            {
                MessageBox.Show("Campo frase de segurança obrigatório", "Altera Senha", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbFrase.Focus();
                return false;
            }
            return true;
        }

        private void FrmAlteraSenha_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = "Olá " + usuarioLogado.Nome;
        }
    }
}
