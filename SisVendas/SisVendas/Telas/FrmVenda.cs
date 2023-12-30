using MySql.Data.MySqlClient;
using SisVendas.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisVendas.Telas
{
    public partial class FrmVenda : Form
    {
        Usuario usuarioLogado = new Usuario();
        decimal total = 0;

        public FrmVenda(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void FrmVenda_Load(object sender, EventArgs e)
        {
            //Carrega o combobox do cliente
            cbbCliente.DataSource = Cliente.BuscarTodosClientes();
            cbbCliente.DisplayMember = "nome";
            cbbCliente.ValueMember = "id_cliente";
            cbbCliente.SelectedIndex = -1;

            //Carrega o combobox do produto
            cbbProduto.DataSource = Produto.BuscarTodosProdutos();
            cbbProduto.DisplayMember = "nome";
            cbbProduto.ValueMember = "id_produto";
            cbbProduto.SelectedIndex = -1;

            //Mostra a data atual
            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy");

            //Formatar o datagrid dos pedidos gerados
            dgvPedidos.DataSource = Pedido.BuscarTodosPedidos();
            dgvPedidos.Columns[0].HeaderText = "Código";
            dgvPedidos.Columns[1].Visible = false;
            dgvPedidos.Columns[2].Visible = false;
            dgvPedidos.Columns[3].Visible = false;
            dgvPedidos.Columns[4].Visible = false;
        }

        private void cbbProduto_DropDownClosed(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)cbbProduto.SelectedItem;
            txbId.Text = drv["id_produto"].ToString();
            txbPreco.Text = drv["valor"].ToString();
            txbEstoque.Text = drv["qtde"].ToString();
            mskQtde.Clear();
            mskQtde.Focus();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRowView drv = (DataRowView)cbbProduto.SelectedItem;
                if (Convert.ToInt32(mskQtde.Text) > 0 && mskQtde.Text != "")
                {
                    if (Convert.ToInt32(mskQtde.Text) <= Convert.ToInt32(drv["qtde"].ToString()))
                    {
                        dgvItens.DataSource = null;
                        dgvItens.ColumnCount = 5;
                        dgvItens.Columns[0].Name = "Código";
                        dgvItens.Columns[1].Name = "Produto";
                        dgvItens.Columns[2].Name = "Qtde";
                        dgvItens.Columns[3].Name = "Preço";
                        dgvItens.Columns[4].Name = "Subtotal";
                        dgvItens.Rows.Add(txbId.Text,
                                          cbbProduto.Text,
                                          mskQtde.Text,
                                          txbPreco.Text,
                                          Convert.ToInt32(mskQtde.Text) *
                                          Convert.ToDecimal(txbPreco.Text));
                        total = total + (Convert.ToInt32(mskQtde.Text) *
                                          Convert.ToDecimal(txbPreco.Text));
                        lblTotal.Text = total.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Verifique a quantidade em estoque", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        mskQtde.Focus();
                    }
                }
            }
            catch (Exception)
            {

                
            }
            
        }

        private void dgvItens_DoubleClick(object sender, EventArgs e)
        {
            if (dgvItens.SelectedRows.Count > 0)
            {
                total = total - Convert.ToDecimal(dgvItens.CurrentRow.Cells[4].Value.ToString());
                lblTotal.Text = total.ToString();
                dgvItens.Rows.Remove(dgvItens.CurrentRow);
            }
        }

        private void toolStripSalvar_Click(object sender, EventArgs e)
        {
            if (VerificaVazio())
            {
                string dataAtual = DateTime.Now.ToString("yyyy-MM-dd");
                Pedido PD = new Pedido(0, int.Parse(cbbCliente.SelectedValue.ToString()), 
                    usuarioLogado.Id_usuario, dataAtual, Convert.ToDecimal(lblTotal.Text));
                List<ItensPedido> itens = new List<ItensPedido>();
                for (int i = 0; i < dgvItens.Rows.Count; i++)
                {
                    ItensPedido item = new ItensPedido(0, 0,
                        Convert.ToInt32(dgvItens.Rows[i].Cells[0].Value),
                        Convert.ToDecimal(dgvItens.Rows[i].Cells[3].Value),
                        Convert.ToInt32(dgvItens.Rows[i].Cells[2].Value),
                        Convert.ToDecimal(dgvItens.Rows[i].Cells[4].Value));
                    itens.Add(item);
                    //dar baixa na quantidade dos produtos 
                    Produto Baixa = new Produto(Convert.ToInt32(dgvItens.Rows[i].Cells[0].Value), Convert.ToInt32(dgvItens.Rows[i].Cells[2].Value), 1);
                    Baixa.BaixaNosProdutos();

                }
                PD.ItensPedido = itens;
                PD.InserePedido(dgvItens.RowCount);
                MessageBox.Show("Pedido gerado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripSalvar.Enabled = false;
                toolStripImprimir.Visible = true;
                toolStripLimpar.Enabled = false;
                dgvPedidos.DataSource = Pedido.BuscarTodosPedidos();
            }
        }

        private Boolean VerificaVazio()
        {
            if (cbbCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbbCliente.Focus();
                return false;
            }

            if (cbbProduto.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um produto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbbProduto.Focus();
                return false;
            }

            if (mskQtde.Text == string.Empty) {
                MessageBox.Show("Digite a quantidade", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mskQtde.Focus();
                return false;
            }

            if (dgvItens.SelectedRows.Count == 0)
            {
                MessageBox.Show("Não há itens adicionados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnAdicionar.Focus();
                return false;
            }
            return true;
        }

        private void Print_PrintPage (object sender, PrintPageEventArgs e)
        {
            //*********************************
            //int UltimoId = Pedido.BuscaId();
            //*********************************

            //Instanciando o objeto gráfico
            Graphics g = e.Graphics;
            //Instanciando o local da imagem
            Image image = Image.FromFile(string.Format("{0}{1}", Application.StartupPath, "\\logo.png"));

            using (Font fontDestaque = new Font("Arial Black", 14),
                        fontPadrao = new Font("Arial", 12),
                        fontData = new Font("Arial", 10))
            {
                //Posicionando o logo
                g.DrawImage(image, 40, 20);
                //Posicionando o titulo
                g.DrawString("SISTEMA DE VENDAS", fontDestaque, Brushes.DarkRed, 100, 30);
                
                //***************************
                //g.DrawString("Pedido número: " + UltimoId, fontDestaque, Brushes.DarkRed, 100, 50);
                //***************************

                //Posicionando o nome do cliente
                g.DrawString("Cliente: " + cbbCliente.Text, fontData, Brushes.Black, 40, 90);

                //Posicionando a data
                string dataAtual = DateTime.Now.ToString("dd/MM/yyyy");
                g.DrawString("Data: " + dataAtual, fontData, Brushes.Black, 40, 110);

                //Criar uma linha divisória
                Pen divisoria = new Pen(Color.Black);
                g.DrawLine(divisoria, 40, 140, 800, 140);

                //Posicionar as legendas
                g.DrawString("Código", fontDestaque, Brushes.Black, 40, 160);
                g.DrawString("Produto", fontDestaque, Brushes.Black, 140, 160);
                g.DrawString("Qtde", fontDestaque, Brushes.Black, 480, 160);
                g.DrawString("Valor", fontDestaque, Brushes.Black, 580, 160);
                g.DrawString("Subtotal", fontDestaque, Brushes.Black, 700, 160);

                //Variável para os conteúdos das próximas linhas
                int linha = 190;

                //Laço para carregar os conteúdos do datagrid
                for (int i = 0; i < dgvItens.RowCount; i++)
                {
                    string Produto = dgvItens.Rows[i].Cells[1].Value.ToString();
                    if (Produto.Length > 35)
                    {
                        Produto = Produto.Substring(0, 35) + "...";
                    }
                    //Definindo alinhamento
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Far;

                    //Impressão do conteúdo do datagrid
                    g.DrawString(Convert.ToString(dgvItens.Rows[i].Cells[0].Value), fontPadrao, Brushes.Black, 60, linha);
                    g.DrawString(Produto, fontPadrao, Brushes.Black, 140, linha);
                    g.DrawString(Convert.ToString(dgvItens.Rows[i].Cells[2].Value), fontPadrao, Brushes.Black, 500, linha);
                    g.DrawString(Convert.ToString(dgvItens.Rows[i].Cells[3].Value), fontPadrao, Brushes.Black, 640, linha, stringFormat);
                    g.DrawString(Convert.ToString(dgvItens.Rows[i].Cells[4].Value), fontPadrao, Brushes.Black, 788, linha, stringFormat);

                    //Incrementando a linha
                    linha = linha + 25;
                }

                //Linha divisória antes do total
                g.DrawLine(divisoria, 40, (linha + 10), 800, (linha + 10));

                //Impressão do total
                g.DrawString("Total", fontDestaque, Brushes.DarkRed, 580, linha + 20);
                g.DrawString(lblTotal.Text, fontDestaque, Brushes.DarkRed, 700, linha + 20);
            }
        }

        private void toolStripImprimir_Click(object sender, EventArgs e)
        {
            using (PrintDocument print = new PrintDocument())
            using (PrintPreviewDialog dialog = new PrintPreviewDialog())
            {
                print.PrintPage += Print_PrintPage;
                dialog.Document = print;
                dialog.ShowDialog();
                toolStripLimpar.Enabled = true;
            }
        }

        private void dgvPedidos_Click(object sender, EventArgs e)
        {
            dgvPedidos.DefaultCellStyle.SelectionBackColor = Color.Tomato;
            MostraPedido();
            toolStripExcluir.Visible = true;
            toolStripSalvar.Enabled = false;

        }

        private void MostraPedido()
        {
            try
            {
                if (dgvPedidos.SelectedRows.Count > 0)
                {
                    toolStripLimpar.PerformClick();
                    dgvItens.DataSource = Pedido.BuscarPorId(int.Parse(dgvPedidos.SelectedRows[0].Cells[0].Value.ToString()));
                    dgvItens.Columns[0].Visible = false;
                    dgvItens.Columns[1].Visible = false;
                    dgvItens.Columns[2].Visible = false;
                    dgvItens.Columns[3].Visible = false;
                    dgvItens.Columns[4].Visible = false;
                    dgvItens.Columns[5].Visible = false;
                    dgvItens.Columns[6].Visible = false;
                    dgvItens.Columns[7].HeaderText = "Código";
                    dgvItens.Columns[8].HeaderText = "Valor";
                    dgvItens.Columns[9].HeaderText = "Qtde";
                    dgvItens.Columns[10].HeaderText = "Subtotal";
                    dgvItens.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvItens.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvItens.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvItens.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    cbbCliente.SelectedValue = dgvPedidos.SelectedRows[0].Cells[1].Value.ToString();
                    lblData.Text = dgvPedidos.SelectedRows[0].Cells[3].Value.ToString();
                    lblTotal.Text = dgvPedidos.SelectedRows[0].Cells[4].Value.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void toolStripLimpar_Click(object sender, EventArgs e)
        {
            cbbCliente.SelectedIndex = -1;
            cbbProduto.SelectedIndex = -1;
            txbId.Clear();
            txbEstoque.Clear();
            txbPreco.Clear();
            mskQtde.Clear();
            lblData.Text = string.Empty;
            lblTotal.Text = string.Empty;
            for (int i = 0; i < dgvItens.RowCount; i++)
            {
                dgvItens.Rows[i].DataGridView.Columns.Clear();
            }
            cbbCliente.Focus();
            toolStripExcluir.Visible = false;
            toolStripSalvar.Enabled = true;
            toolStripImprimir.Visible = false;
            total = 0;
        }

        private void toolStripExcluir_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja excluir este pedido?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Pergunta == DialogResult.Yes)
            {
                ItensPedido ExcluirItem = new ItensPedido(int.Parse(dgvPedidos.SelectedRows[0].Cells[0].Value.ToString()));
                ExcluirItem.ExcluiItensPedido();
                Pedido ExcluirPedido = new Pedido(int.Parse(dgvPedidos.SelectedRows[0].Cells[0].Value.ToString()));
                ExcluirPedido.ExcluiPedido();
                //repor as quantidades dos produtos
                for (int i = 0; i < dgvItens.Rows.Count; i++)
                {
                    Produto Repor = new Produto(Convert.ToInt32(dgvItens.Rows[i].Cells[7].Value), Convert.ToInt32(dgvItens.Rows[i].Cells[9].Value), 1);
                    Repor.ReporProdutos();
                }

                toolStripLimpar.PerformClick();
                dgvPedidos.DataSource = Pedido.BuscarTodosPedidos();
            }
        }
    }
}
