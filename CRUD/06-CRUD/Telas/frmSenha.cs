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

namespace _06_CRUD.Telas
{
    public partial class frmSenha : Form
    {
        Usuario usuarioLogado = new Usuario();
        public frmSenha(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void toolStripAtualizar_Click(object sender, EventArgs e)
        {
            if (ValidaDados())
            {
                string senhaAtualCrypto = Crypto.sha256encrypt(txbSenhaAtual.Text);
                senhaAtualCrypto = senhaAtualCrypto.ToLower();

                if (senhaAtualCrypto == usuarioLogado.Senha)
                {
                    string senhaNova = Crypto.sha256encrypt(txbSenha.Text);
                    senhaNova = senhaNova.ToLower();
                    int id = usuarioLogado.Id_usuario;
                    Usuario MudaSenha = new Usuario(id, senhaNova, txbFrase.Text);
                    MudaSenha.AlterarSenha();
                    MessageBox.Show("Senha alterada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txbSenhaAtual.Clear();
                    txbSenha.Clear();
                    txbRepitaSenha.Clear();
                    txbFrase.Clear();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Senha atual não confere", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool ValidaDados()
        {
            if (txbSenhaAtual.Text == string.Empty)
            {
                MessageBox.Show("Digite a senha atual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSenhaAtual.Focus();
                return false;
            }

            if (txbSenha.Text == string.Empty)
            {
                MessageBox.Show("Digite a nova senha atual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSenha.Focus();
                return false;
            }

            if (txbRepitaSenha.Text == string.Empty)
            {
                MessageBox.Show("Repita a nova senha", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbRepitaSenha.Focus();
                return false;
            }

            if (txbSenha.Text != txbRepitaSenha.Text)
            {
                MessageBox.Show("As senhas não conferem", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbSenha.Clear();
                txbRepitaSenha.Clear();
                txbSenha.Focus();
                return false;
            }

            if (txbFrase.Text == string.Empty)
            {
                MessageBox.Show("Digite a frase de segurança", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbFrase.Focus();
                return false;
            }
            return true;
        }
    }
}
