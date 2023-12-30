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
    public partial class FrmUsuario : Form
    {
        Usuario usuarioLogado = new Usuario();
        public FrmUsuario(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = Usuario.BuscarTodosUsuarios();
            dgvUsuarios.Columns[0].Visible = false;
            dgvUsuarios.Columns[1].HeaderText = "Nome";
            dgvUsuarios.Columns[2].HeaderText = "E-mail";
            dgvUsuarios.Columns[3].Visible = false;
            dgvUsuarios.Columns[4].Visible = false;
            dgvUsuarios.Columns[5].Visible = false;
            dgvUsuarios.Columns[6].HeaderText = "Nível";
            dgvUsuarios.Columns[7].Visible = false;

            dgvUsuariosDesativados.DataSource = Usuario.BuscarTodosUsuariosDesativados();
            dgvUsuariosDesativados.Columns[0].Visible = false;
            dgvUsuariosDesativados.Columns[1].HeaderText = "Nome";
            dgvUsuariosDesativados.Columns[2].HeaderText = "E-mail";
            dgvUsuariosDesativados.Columns[3].Visible = false;
            dgvUsuariosDesativados.Columns[4].Visible = false;
            dgvUsuariosDesativados.Columns[5].Visible = false;
            dgvUsuariosDesativados.Columns[6].HeaderText = "Nível";
            dgvUsuariosDesativados.Columns[7].Visible = false;
        }

        private void dgvUsuarios_Click(object sender, EventArgs e)
        {
            MostraUsuario();
        }


        private void MostraUsuario()
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    txbId.Text = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                    txbNome.Text = dgvUsuarios.SelectedRows[0].Cells[1].Value.ToString();
                    txbEmail.Text = dgvUsuarios.SelectedRows[0].Cells[2].Value.ToString();
                    txbLogin.Text = dgvUsuarios.SelectedRows[0].Cells[3].Value.ToString();
                    cbbNivel.SelectedIndex = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[6].Value.ToString());
                    toolStripSalvar.Enabled = false;
                    toolStripAlterar.Enabled = true;
                    toolStripExcluir.Enabled = true;
                    toolStripCancelar.Visible = true;
                    dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.Tomato;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dgvUsuariosDesativados_DoubleClick(object sender, EventArgs e)
        {
            string id;
            id = dgvUsuariosDesativados.SelectedRows[0].Cells[0].Value.ToString();
            DialogResult Pergunta = MessageBox.Show("Deseja ativar esse(a) usuário(a)?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Pergunta == DialogResult.Yes)
            {
                Usuario Ativa = new Usuario(int.Parse(id), 1);
                Ativa.AtivaUsuario();
                LimpaCampos();
                toolStripCancelar.PerformClick();
                dgvUsuarios.DataSource = Usuario.BuscarTodosUsuarios();
                dgvUsuariosDesativados.DataSource = Usuario.BuscarTodosUsuariosDesativados();
                txbNome.Focus();
            }
        }

        private void LimpaCampos()
        {
            txbId.Text = string.Empty;
            txbNome.Text = string.Empty;
            txbEmail.Text = string.Empty;
            txbLogin.Text = string.Empty;
            cbbNivel.SelectedIndex = -1;
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
        }

        private void toolStripCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            toolStripSalvar.Enabled = true;
            toolStripAlterar.Enabled = false;
            toolStripExcluir.Enabled = false;
            toolStripCancelar.Visible = false;
            txbNome.Focus();
        }

        private void toolStripSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaDados())
            {
                try
                {
                    string senhaCrypto = Crypto.sha256encrypt("123");
                    senhaCrypto = senhaCrypto.ToLower();
                    string frase = "Padrão";

                    Usuario Novousuario = new Usuario(txbNome.Text, txbEmail.Text, txbLogin.Text, 
                        senhaCrypto, frase, cbbNivel.SelectedIndex, 1);
                    Novousuario.InsereUsuario();
                    LimpaCampos();
                    dgvUsuarios.DataSource = Usuario.BuscarTodosUsuarios();
                    txbNome.Focus();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        private Boolean ValidaDados()
        {
            if (txbNome.Text == string.Empty)
            {
                MessageBox.Show("Campo nome obrigatório!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbNome.Focus();
                return false;
            }
            if (txbEmail.Text == string.Empty)
            {
                MessageBox.Show("Campo e-mail obrigatório!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbEmail.Focus();
                return false;
            }
            if (txbLogin.Text == string.Empty)
            {
                MessageBox.Show("Campo login obrigatório!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbLogin.Focus();
                return false;
            }
            if (cbbNivel.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o nível de acesso do usuário!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbNivel.Focus();
                return false;
            }
            return true;
        }

        private void toolStripAlterar_Click(object sender, EventArgs e)
        {
            if (ValidaDados())
            {
                Usuario AlteraUsuario = new Usuario(int.Parse(txbId.Text), txbNome.Text, 
                    txbEmail.Text, txbLogin.Text, cbbNivel.SelectedIndex);
                AlteraUsuario.AlteraUsuario();
                LimpaCampos();
                dgvUsuarios.DataSource = Usuario.BuscarTodosUsuarios();
                txbNome.Focus();
            }
        }


        private Boolean ValidaDados2()
        {
            if (txbNome.Text == string.Empty)
            {
                MessageBox.Show("Campo nome obrigatório!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbNome.Focus();
                return false;
            }
            if (txbEmail.Text == string.Empty)
            {
                MessageBox.Show("Campo e-mail obrigatório!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbEmail.Focus();
                return false;
            }
            if (txbLogin.Text == string.Empty)
            {
                MessageBox.Show("Campo login obrigatório!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbLogin.Focus();
                return false;
            }
            if (cbbNivel.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o nível de acesso do usuário!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbNivel.Focus();
                return false;
            }
            return true;
        }

        private void toolStripExcluir_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja desativar esse(a) usuário(a)?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Pergunta == DialogResult.Yes)
            {
                Usuario Desativa = new Usuario(int.Parse(txbId.Text), 0);
                Desativa.DesativaUsuario();
                LimpaCampos();
                toolStripCancelar.PerformClick();
                dgvUsuarios.DataSource = Usuario.BuscarTodosUsuarios();
                dgvUsuariosDesativados.DataSource = Usuario.BuscarTodosUsuariosDesativados();
                txbNome.Focus();
            }
        }
    }
}
