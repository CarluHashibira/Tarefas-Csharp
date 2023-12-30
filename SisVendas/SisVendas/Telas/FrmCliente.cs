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
    public partial class FrmCliente : Form
    {
        Usuario usuarioLogado = new Usuario();
        string hoje = DateTime.Now.ToString("dd/mm/yyyy");
        public FrmCliente(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
            
        }

        private Boolean ValidaDados()
        {
            if (txbNome.Text == string.Empty)
            {
                MessageBox.Show("Campo nome obrigatório!", "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbNome.Focus();
                return false;
            }
            if (txbEmail.Text == string.Empty)
            {
                MessageBox.Show("Campo e-mail obrigatório!", "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbEmail.Focus();
                return false;
            }
            if (mskFone.Text == string.Empty)
            {
                // Na propriedade TextMaskedFormat = ExcludePromptAndLiterals
                MessageBox.Show("Campo fone obrigatório!", "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskFone.Focus();
                return false;
            }
            if (dtpNasc.Value.Date == DateTime.Today)
            {
                MessageBox.Show("Selecione a data de nascimento!", "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNasc.Focus();
                return false;
            }
            if (cbbSexo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o sexo!", "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbSexo.Focus();
                return false;
            }
            return true;
        }

        private void LimpaCampos()
        {
            txbId.Text = string.Empty;
            txbNome.Text = string.Empty;
            txbEmail.Text = string.Empty;
            mskFone.Text = string.Empty;
            dtpNasc.Value = DateTime.Now;
            cbbSexo.SelectedIndex = -1;
            txbNome.Focus();
        }

        private void toolStripSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaDados())
            {
                try
                {
                    string dataMysql = dtpNasc.Value.ToString("yyyy-MM-dd");
                    Cliente NovoCliente = new Cliente(txbNome.Text, txbEmail.Text, mskFone.Text, dataMysql, cbbSexo.SelectedItem.ToString(), 1);
                    NovoCliente.InsereCliente();
                    dgvClientes.DataSource = Cliente.BuscarTodosClientes();
                    LimpaCampos();
                    txbNome.Focus();
                }
                catch (Exception erro)
                {

                    MessageBox.Show("Ocorreu um erro: " + erro, "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = Cliente.BuscarTodosClientes();
            dgvClientes.Columns[0].HeaderText = "Código";
            dgvClientes.Columns[1].HeaderText = "Nome";
            dgvClientes.Columns[2].HeaderText = "Email";
            dgvClientes.Columns[3].HeaderText = "Fone";
            dgvClientes.Columns[4].HeaderText = "Dt Nascimento";
            dgvClientes.Columns[5].HeaderText = "Sexo";
            dgvClientes.Columns[6].HeaderText = "Ativo";
        }


        private void MostraCliente()
        {
            try
            {
                if (dgvClientes.SelectedRows.Count > 0)
                {
                    txbId.Text = dgvClientes.SelectedRows[0].Cells[0].Value.ToString();
                    txbNome.Text = dgvClientes.SelectedRows[0].Cells[1].Value.ToString();
                    txbEmail.Text = dgvClientes.SelectedRows[0].Cells[2].Value.ToString();
                    mskFone.Text = dgvClientes.SelectedRows[0].Cells[3].Value.ToString();
                    dtpNasc.Text = dgvClientes.SelectedRows[0].Cells[4].Value.ToString();
                    cbbSexo.Text = dgvClientes.SelectedRows[0].Cells[5].Value.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgvClientes_Click(object sender, EventArgs e)
        {
            toolStripSalvar.Enabled = false;
            toolStripAlterar.Enabled = true;
            toolStripExcluir.Enabled = true;
            toolStripCancelar.Visible = true;
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.Tomato;
            try
            {
                MostraCliente();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void toolStripCancelar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            toolStripSalvar.Enabled = true;
            toolStripAlterar.Enabled = false;
            toolStripAlterar.Visible = true;
            toolStripExcluir.Enabled = false;
            toolStripCancelar.Visible = false;
            txbNome.Enabled = true;
            txbEmail.Enabled = true;
            mskFone.Enabled = true;
            dtpNasc.Enabled = true;
            cbbSexo.Enabled = true;
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            txbNome.Focus();
        }

        private void toolStripAlterar_Click(object sender, EventArgs e)
        {
            if (ValidaDados())
            {
                string dataMysql = dtpNasc.Value.ToString("yyyy-MM-dd");
                Cliente Atualiza = new Cliente(int.Parse(txbId.Text), txbNome.Text, txbEmail.Text, mskFone.Text, dataMysql, cbbSexo.SelectedItem.ToString());
                Atualiza.AlteraCliente();
                LimpaCampos();
                toolStripCancelar.PerformClick();
                dgvClientes.DataSource = Cliente.BuscarTodosClientes();
                txbNome.Focus();
            }
        }

        private void toolStripExcluir_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja excluir este cliente?", "Cadastro de Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Pergunta == DialogResult.Yes)
            {
                if (dgvClientes.SelectedRows[0].Cells[6].Value.ToString() == "0")
                {
                    Cliente Exclui = new Cliente(int.Parse(txbId.Text), 0);
                    Exclui.ExcluiCliente();
                    LimpaCampos();
                    toolStripCancelar.PerformClick();
                    dgvClientes.DataSource = Cliente.BuscarTodosClientes();
                    txbNome.Focus();
                }
                else
                {
                    Cliente Desativa = new Cliente(int.Parse(txbId.Text), 0);
                    Desativa.DesativaCliente();
                    LimpaCampos();
                    toolStripCancelar.PerformClick();
                    dgvClientes.DataSource = Cliente.BuscarTodosClientes();
                    txbNome.Focus();
                }
            }
        }

        private void cbbBusca_DropDownClosed(object sender, EventArgs e)
        {
            if (cbbBusca.SelectedIndex == 0 || cbbBusca.SelectedIndex == 5)
            {
                txbBuscar.Text = string.Empty;
                txbBuscar.Enabled = false;
            }
            else
            {
                txbBuscar.Enabled = true;
                txbBuscar.Text = string.Empty;
                txbBuscar.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbbBusca.SelectedIndex == 0)
            {
                dgvClientes.DataSource = Cliente.BuscarTodosClientes();
            }
            if (cbbBusca.SelectedIndex == 1)
            {
                dgvClientes.DataSource = Cliente.BuscarPorID(int.Parse(txbBuscar.Text));
            }
            if (cbbBusca.SelectedIndex == 2)
            {
                dgvClientes.DataSource = Cliente.BuscarPorNome(txbBuscar.Text);
            }
            if (cbbBusca.SelectedIndex == 3)
            {
                dgvClientes.DataSource = Cliente.BuscarPorEmail(txbBuscar.Text);
            }
            if (cbbBusca.SelectedIndex == 4)
            {
                dgvClientes.DataSource = Cliente.BuscarPorFone(txbBuscar.Text);
            }
            if (cbbBusca.SelectedIndex == 5)
            {
                dgvClientes.DataSource = Cliente.BuscarPorInativo();
            }
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            string meuativo;
            string meuid;

            meuid = dgvClientes.SelectedRows[0].Cells[0].Value.ToString();
            meuativo = dgvClientes.SelectedRows[0].Cells[6].Value.ToString();

            if (usuarioLogado.Nivel == 0 && Convert.ToInt32(meuativo) == 0)
            {
                DialogResult Pergunta = MessageBox.Show("Deseja ativar esse cliente?", "Cadastro de Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Pergunta == DialogResult.Yes)
                {
                    try
                    {
                        Cliente Ativar = new Cliente(int.Parse(txbId.Text), 1);
                        Ativar.AtivaCliente();
                        toolStripSalvar.Enabled = true;
                        toolStripAlterar.Enabled = false;
                        toolStripExcluir.Enabled = false;
                        toolStripCancelar.Visible = false;

                        LimpaCampos();
                        dgvClientes.DataSource = Cliente.BuscarTodosClientes();
                        dgvClientes.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
                    }
                    catch (Exception erro)
                    {

                        MessageBox.Show(erro.Message, "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
