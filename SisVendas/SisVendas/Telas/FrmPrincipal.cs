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
    public partial class FrmPrincipal : Form
    {
        Usuario usuarioLogado = new Usuario();
        string nivelusu = "";

        public FrmPrincipal(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void menuCliente_Click(object sender, EventArgs e)
        {
            FrmCliente Cliente = new FrmCliente(usuarioLogado);
            Cliente.ShowDialog();
        }

        private void menuProduto_Click(object sender, EventArgs e)
        {
            FrmProduto Produto = new FrmProduto(usuarioLogado);
            Produto.ShowDialog();
        }

        private void menuUsuario_Click(object sender, EventArgs e)
        {
            FrmUsuario Usuario = new FrmUsuario(usuarioLogado);
            Usuario.ShowDialog();
        }

        private void alterarSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAlteraSenha Altera = new FrmAlteraSenha(usuarioLogado);
            Altera.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            if (usuarioLogado.Nivel == 0)
            {
                nivelusu = "administrador";
            }
            else
            {
                nivelusu = "usuário comum";
            }
            this.Text = "Sistema de Vendas - Usuário logado: " + usuarioLogado.Nome + " - Permissão: " + nivelusu;
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVenda Venda = new FrmVenda(usuarioLogado);
            Venda.ShowDialog();
        }
    }
}
