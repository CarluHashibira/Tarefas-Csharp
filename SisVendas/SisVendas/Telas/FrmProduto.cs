using SisVendas.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisVendas.Telas
{
    public partial class FrmProduto : Form
    {
        Usuario usuarioLogado = new Usuario();
        public FrmProduto(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog AbreFoto = new OpenFileDialog();
            AbreFoto.Title = "Selecionar foto";
            AbreFoto.Filter = "All files (*.*)|*.*";
            DialogResult dr = AbreFoto.ShowDialog();
            if (dr == DialogResult.OK)
            {
                try
                {
                    txbFoto.Text = AbreFoto.FileName;
                    picFoto.ImageLocation = txbFoto.Text;
                }
                catch (Exception)
                {

                    MessageBox.Show("Erro ao carregar a foto", "Cadastro de Pessoas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void toolStripSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaDados())
            {
                try
                {
                    string Destino = Directory.GetCurrentDirectory();
                    CopiarArquivo(txbFoto.Text, @Destino + "\\" + Path.GetFileName(txbFoto.Text));

                    Produto NovoProduto = new Produto(txbNome.Text,
                                                      Path.GetFileName(txbFoto.Text),
                                                      txbDescricao.Text,
                                                      Convert.ToInt32(txbQtde.Text),
                                                      Convert.ToDecimal(txbValor.Text),
                                                      1);
                    NovoProduto.InsereProduto();
                    dgvProdutos.DataSource = Produto.BuscarTodosProdutos();
                    LimpaCampos();
                    txbNome.Focus();
                }
                catch (Exception erro)
                {

                    MessageBox.Show("Erro ao salvar: " + erro, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void LimpaCampos()
        {
            txbId.Text = string.Empty;
            txbNome.Text = string.Empty;
            txbValor.Text = string.Empty;
            txbDescricao.Text = string.Empty;
            txbQtde.Text = string.Empty;
            txbFoto.Text = string.Empty;
            picFoto.Image = null;
            txbNome.Focus();
        }



        static bool CopiarArquivo(string nomeArquivoOrigem, string nomeArquivoDestino)
        {
            if (File.Exists(nomeArquivoOrigem) == false)
            {
                MessageBox.Show("Atenção! \nNão foi possível encontrar a foto", "Cadastro de Pessoas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (File.Exists(nomeArquivoDestino) == true)
            {
                if (MessageBox.Show("Atenção! \nJá existe foto com esse nome, deseja substituir a foto?", "Cadastro de Pessoas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }
            try
            {
                Stream s1 = File.Open(@nomeArquivoOrigem, FileMode.Open, FileAccess.ReadWrite);
                Stream s2 = File.Open(@nomeArquivoDestino, FileMode.Create);

                BinaryReader f1 = new BinaryReader(s1);
                BinaryWriter f2 = new BinaryWriter(s2);

                while (true)
                {
                    byte[] buf = new byte[10240];
                    int sz = f1.Read(buf, 0, 10240);
                    if (sz <= 0)
                        break;
                    f2.Write(buf, 0, sz);
                    if (sz < 10240)
                        break;
                }
                f1.Close();
                f2.Close();
                MessageBox.Show("Foto salva!", "Cadastro de Pessoas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao salvar a foto", "Cadastro de Pessoas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        private Boolean ValidaDados()
        {
            if (txbNome.Text == string.Empty)
            {
                MessageBox.Show("Campo nome obrigatório!", "Cadastro de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbNome.Focus();
                return false;
            }
            if (txbValor.Text == string.Empty)
            {
                MessageBox.Show("Campo valor obrigatório!", "Cadastro de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbValor.Focus();
                return false;
            }
            if (txbFoto.Text == string.Empty)
            {
                MessageBox.Show("Campo foto obrigatório!", "Cadastro de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnFoto.Focus();
                return false;
            }
            if (txbQtde.Text == string.Empty)
            {
                MessageBox.Show("Campo Quantidade obrigatório!", "Cadastro de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbQtde.Focus();
                return false;
            }
            if (txbDescricao.Text == string.Empty)
            {
                MessageBox.Show("Campo descrição obrigatório!", "Cadastro de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbDescricao.Focus();
                return false;
            }
            return true;
        }

        private void toolStripAlterar_Click(object sender, EventArgs e)
        {
            if (ValidaDados())
            {
                Produto Atualiza = new Produto(int.Parse(txbId.Text), 
                                               txbNome.Text,
                                               txbDescricao.Text, 
                                               Convert.ToInt32(txbQtde.Text),
                                               Convert.ToDecimal(txbValor.Text));
                Atualiza.AlteraProduto();
                LimpaCampos();
                toolStripCancelar.PerformClick();
                dgvProdutos.DataSource = Produto.BuscarTodosProdutos();
                txbNome.Focus();
            }
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            dgvProdutos.DataSource = Produto.BuscarTodosProdutos();
            dgvProdutos.Columns[0].HeaderText = "Código";
            dgvProdutos.Columns[1].HeaderText = "Nome";
            dgvProdutos.Columns[2].HeaderText = "Foto";
            dgvProdutos.Columns[3].Visible = false;
            dgvProdutos.Columns[4].HeaderText = "Qtde";
            dgvProdutos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProdutos.Columns[5].HeaderText = "Valor";
            dgvProdutos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProdutos.Columns[6].Visible = false;
        }

        private void dgvProdutos_Click(object sender, EventArgs e)
        {
            toolStripSalvar.Enabled = false;
            toolStripAlterar.Enabled = true;
            toolStripExcluir.Enabled = true;
            toolStripCancelar.Visible = true;
            btnFoto.Enabled = false;
            gpbFoto.Enabled = true;
            dgvProdutos.DefaultCellStyle.SelectionBackColor = Color.Tomato;
            try
            {
                MostraProduto();
            }
            catch (Exception)
            {

                MessageBox.Show("Atenção! \nNão há imagem para este produto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void MostraProduto()
        {
            try
            {
                if (dgvProdutos.SelectedRows.Count > 0)
                {
                    txbId.Text = dgvProdutos.SelectedRows[0].Cells[0].Value.ToString();
                    txbNome.Text = dgvProdutos.SelectedRows[0].Cells[1].Value.ToString();
                    txbFoto.Text = dgvProdutos.SelectedRows[0].Cells[2].Value.ToString();
                    picFoto.Image = null;
                    picFoto.Load(dgvProdutos.SelectedRows[0].Cells[2].Value.ToString());
                    txbDescricao.Text = dgvProdutos.SelectedRows[0].Cells[3].Value.ToString();
                    txbQtde.Text = dgvProdutos.SelectedRows[0].Cells[4].Value.ToString();
                    txbValor.Text = dgvProdutos.SelectedRows[0].Cells[5].Value.ToString();
                    if (Convert.ToInt32(dgvProdutos.SelectedRows[0].Cells[6].Value.ToString()) == 0)
                    {
                        toolStripAtivar.Visible = true;
                        toolStripDesativar.Visible = false;
                    }
                    else
                    {
                        toolStripAtivar.Visible = false;
                        toolStripDesativar.Visible = true;
                    }
                }
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
            toolStripExcluir.Visible = true;
            toolStripCancelar.Visible = false;
            toolStripMudaFoto.Visible = false;
            toolStripDesativar.Visible = false;
            toolStripAtivar.Visible = false;
            btnFoto.Enabled = true;
            gpbFoto.Enabled = false;
            txbNome.Enabled = true;
            txbValor.Enabled = true;
            txbDescricao.Enabled = true;
            dgvProdutos.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            txbNome.Focus();
        }

        private void toolStripExcluir_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja excluir este produto?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Pergunta == DialogResult.Yes)
            {
                Produto Exclui = new Produto(int.Parse(txbId.Text));
                Exclui.ExcluiProduto();
                LimpaCampos();
                toolStripCancelar.PerformClick();
                dgvProdutos.DataSource = Produto.BuscarTodosProdutos();
                txbNome.Focus();
            }
        }

        private void toolStripAtivar_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja ativar esse produto?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Pergunta == DialogResult.Yes)
            {
                Produto Ativa = new Produto(int.Parse(txbId.Text));
                Ativa.AtivaProduto();
                LimpaCampos();
                toolStripCancelar.PerformClick();
                dgvProdutos.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
                dgvProdutos.DataSource = Produto.BuscarTodosProdutos();
                txbNome.Focus();
            }
        }

        private void toolStripDesativar_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja desativar esse produto?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Pergunta == DialogResult.Yes)
            {
                Produto Desativa = new Produto(int.Parse(txbId.Text));
                Desativa.DesativaProduto();
                LimpaCampos();
                toolStripCancelar.PerformClick();
                dgvProdutos.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
                dgvProdutos.DataSource = Produto.BuscarTodosProdutos();
                txbNome.Focus();
            }
        }

        private void toolStripMudaFoto_Click(object sender, EventArgs e)
        {
            string Destino = Directory.GetCurrentDirectory();
            CopiarArquivo(txbFoto.Text, @Destino + "\\" + Path.GetFileName(txbFoto.Text));

            Produto MudaFoto = new Produto(int.Parse(txbId.Text), Path.GetFileName(txbFoto.Text));
            MudaFoto.AlteraFoto();
            LimpaCampos();
            toolStripCancelar.PerformClick();
            dgvProdutos.DataSource = Produto.BuscarTodosProdutos();
            txbNome.Enabled = true;
            txbValor.Enabled = true;
            txbQtde.Enabled = true;
            txbDescricao.Enabled = true;
            toolStripMudaFoto.Visible = false;
            toolStripAlterar.Visible = true;
            toolStripExcluir.Visible = true;
            toolStripSalvar.Enabled = true;
            txbNome.Focus();
        }

        private void cbbBusca_DropDownClosed(object sender, EventArgs e)
        {
            if (cbbBusca.SelectedIndex == 0 || cbbBusca.SelectedIndex == 3)
            {
                txbBuscar.Clear();
                txbBuscar.Enabled = false;
            }
            else
            {
                txbBuscar.Enabled = true;
                txbBuscar.Clear();
                txbBuscar.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbbBusca.SelectedIndex == 0)
            {
                dgvProdutos.DataSource = Produto.BuscarTodosProdutos();
            }

            if (cbbBusca.SelectedIndex == 1)
            {
                try
                {
                    dgvProdutos.DataSource = Produto.BuscarPorID(int.Parse(txbBuscar.Text));
                }
                catch (Exception)
                {

                    
                }
                
            }

            if (cbbBusca.SelectedIndex == 2)
            {
                dgvProdutos.DataSource = Produto.BuscarPorNome(txbBuscar.Text);
            }

            if (cbbBusca.SelectedIndex == 3)
            {
                dgvProdutos.DataSource = Produto.BuscarTodosProdutosDesativados();
            }
        }

        private void picFoto_DoubleClick(object sender, EventArgs e)
        {
            toolStripAlterar.Visible = false;
            toolStripAtivar.Visible = false;
            toolStripExcluir.Visible = false;
            toolStripMudaFoto.Visible = true;
            toolStripDesativar.Visible = false;
            toolStripSalvar.Enabled = false;
            btnFoto.Enabled = true;
            btnFoto.PerformClick();
            txbNome.Enabled = false;
            txbValor.Enabled = false;
            txbQtde.Enabled = false;
            txbDescricao.Enabled = false;
        }
    }
}
