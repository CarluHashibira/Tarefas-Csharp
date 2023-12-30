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
    public partial class frmUsuario : Form
    {
        Usuario usuarioLogado = new Usuario();
        public frmUsuario(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            dgvAtivados.DataSource = Usuario.BuscarTodosUsuariosAtivados();
            dgvAtivados.Columns[0].Visible = false;
            dgvAtivados.Columns[1].HeaderText = "Nome";
            dgvAtivados.Columns[2].HeaderText = "Email";
            dgvAtivados.Columns[3].Visible = false;
            dgvAtivados.Columns[4].Visible = false;
            dgvAtivados.Columns[5].HeaderText = "Nivel";
            dgvAtivados.Columns[6].Visible = false;
            dgvAtivados.Columns[7].Visible = false;

            dgvDesativados.DataSource = Usuario.BuscarTodosUsuariosDesativados();
            dgvDesativados.Columns[0].Visible = false;
            dgvDesativados.Columns[1].HeaderText = "Nome";
            dgvDesativados.Columns[2].HeaderText = "Email";
            dgvDesativados.Columns[3].Visible = false;
            dgvDesativados.Columns[4].Visible = false;
            dgvDesativados.Columns[5].HeaderText = "Nivel";
            dgvDesativados.Columns[6].Visible = false;
            dgvDesativados.Columns[7].Visible = false;
        }

        private void dgvDesativados_DoubleClick(object sender, EventArgs e)
        {
            if (dgvAtivados.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvDesativados.SelectedRows[0].Cells[0].Value.ToString());
                DialogResult Pergunta = MessageBox.Show("Deseja reativar esse usuario?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Pergunta == DialogResult.Yes)
                {
                    try
                    {
                        Usuario Ativar = new Usuario(id, 1);
                        Ativar.AtivarUsuario();
                        MessageBox.Show("Usuario ativado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        toolStripSalvar.Enabled = true;
                        toolStripAtualizar.Enabled = false;
                        toolStripExcluir.Enabled = false;
                        toolStripCancelar.Visible = false;
                        LimpaDados();
                        dgvAtivados.DataSource = Usuario.BuscarTodosUsuariosAtivados();
                        dgvDesativados.DataSource = Usuario.BuscarTodosUsuariosDesativados();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

            }
            

        }

        private void LimpaDados()
        {
            txbID.Clear();
            txbNome.Clear();
            txbEmail.Clear();
            txbLogin.Clear();
            txbNome.Focus();
            cbbNivel.SelectedIndex = -1;
            dgvAtivados.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            dgvDesativados.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
        }

        private void dgvAtivados_Click(object sender, EventArgs e)
        {
            MostraUsuario();
        }

        private void MostraUsuario()
        {
            if (dgvAtivados.SelectedRows.Count > 0)
            {
                txbID.Text = dgvAtivados.SelectedRows[0].Cells[0].Value.ToString();
                txbNome.Text = dgvAtivados.SelectedRows[0].Cells[1].Value.ToString();
                txbEmail.Text = dgvAtivados.SelectedRows[0].Cells[2].Value.ToString();
                txbLogin.Text = dgvAtivados.SelectedRows[0].Cells[7].Value.ToString();
                cbbNivel.SelectedIndex = Convert.ToInt32 (dgvAtivados.SelectedRows[0].Cells[5].Value.ToString());
                toolStripSalvar.Enabled = false;
                toolStripAtualizar.Enabled = true;
                toolStripExcluir.Enabled = true;
                toolStripCancelar.Visible = true;
                dgvAtivados.DefaultCellStyle.SelectionBackColor = Color.Tomato;
            }
        }

        private void toolStripCancelar_Click(object sender, EventArgs e)
        {
            LimpaDados();
            toolStripSalvar.Enabled = true;
            toolStripAtualizar.Enabled = false;
            toolStripExcluir.Enabled = false;
            toolStripCancelar.Visible = false;
        }

        private void toolStripSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaDados())
            {


                if (Usuario.VerificarLogin(txbLogin.Text) && Usuario.VerificarEmail(txbEmail.Text))
                {
                    string senhaCrypto = Crypto.sha256encrypt("123");
                    senhaCrypto = senhaCrypto.ToLower();
                    string frase = "padrão";

                    Usuario Novousuario = new Usuario(txbNome.Text, txbEmail.Text, txbLogin.Text, senhaCrypto, frase, cbbNivel.SelectedIndex, 1);
                    Novousuario.InsereUsuario();
                    MessageBox.Show("Usuario inserido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpaDados();
                    dgvAtivados.DataSource = Usuario.BuscarTodosUsuariosAtivados();
                }

            }
        }

        private bool ValidaDados()
        {
            if (txbNome.Text == String.Empty)
            {
                MessageBox.Show("Digite o nome", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbNome.Focus();
                return false;
            }
            if (txbEmail.Text == String.Empty)
            {
                MessageBox.Show("Digite o Email", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbEmail.Focus();
                return false;
            }
            if (txbLogin.Text == String.Empty)
            {
                MessageBox.Show("Digite o Login", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbLogin.Focus();
                return false;
            }
            if (cbbNivel.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o nivel de acesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbNivel.Focus();
                return false;
            }

            return true;
        }

        private void toolStripAtualizar_Click(object sender, EventArgs e)
        {
            if (ValidaDados())
            {
                Usuario Altera = new Usuario(int.Parse(txbID.Text), txbNome.Text, txbEmail.Text, txbLogin.Text, cbbNivel.SelectedIndex);
                Altera.AlteraUsuario();
                MessageBox.Show("Usuario alterado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpaDados();
                dgvAtivados.DataSource = Usuario.BuscarTodosUsuariosAtivados();
                toolStripSalvar.Enabled = true;
                toolStripAtualizar.Enabled = false;
                toolStripExcluir.Enabled = false;
                toolStripCancelar.Visible = false;

            }
        }

        private void toolStripExcluir_Click(object sender, EventArgs e)
        {
            if (txbLogin.Text == "admin")
            {
                MessageBox.Show("Não é possivel excluir o adm", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult Pergunta = MessageBox.Show("Deseja desativar esta pessoa?", "aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Pergunta == DialogResult.Yes)
                {
                    Usuario Deletar = new Usuario(int.Parse(txbID.Text, 0), txbNome.Text, txbEmail.Text, txbLogin.Text, cbbNivel.SelectedIndex);
                    Deletar.DesativarUsuario();
                    toolStripCancelar.PerformClick();
                    dgvAtivados.DataSource = Pessoa.BuscaTodasPessoas();
                    MessageBox.Show("Pessoa desativada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvAtivados.DataSource = Usuario.BuscarTodosUsuariosAtivados();
                    dgvDesativados.DataSource = Usuario.BuscarTodosUsuariosDesativados();
                }
            }
           
        }
    }
}
