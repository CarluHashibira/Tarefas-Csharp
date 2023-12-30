using _06_CRUD.Classes;
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

namespace _06_CRUD.Telas
{
    public partial class frmPrincipal : Form
    {
        Usuario usuarioLogado = new Usuario();
        string nivelUsu = "";
        public frmPrincipal(Usuario usu)
        {
            InitializeComponent();
            usuarioLogado = usu;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (usuarioLogado.Nivel == 0)
            {
                nivelUsu = "Administrador";
            }
            else
            {
                nivelUsu = "Usuario comum";
                toolStripUsuarios.Visible = false;
            }
            tssUsuario.Text = "Olá " + usuarioLogado.Nome + ", seu nivel de usuario é " + nivelUsu;
            /*dtpNascimento.Format = DateTimePickerFormat.Custom;
            dtpNascimento.CustomFormat = " ";*/
            dgvPessoas.DataSource = Pessoa.BuscaTodasPessoas();
            dgvPessoas.Columns[0].HeaderText = "Código";
            dgvPessoas.Columns[1].HeaderText = "Nome";
            dgvPessoas.Columns[2].HeaderText = "E-mail";
            dgvPessoas.Columns[3].HeaderText = "Fone";
            dgvPessoas.Columns[4].HeaderText = "Foto";
            dgvPessoas.Columns[5].Visible = false;
            dgvPessoas.Columns[6].HeaderText = "Dt Nasc";
            dgvPessoas.Columns[7].HeaderText = "Sexo";
        }

        private void toolStripSalvar_Click(object sender, EventArgs e)
        {
            if (ValidaDados())
            {
                //Copia a foto
                string Destino = Directory.GetCurrentDirectory();
                CopiarArquivo(txbFoto.Text, @Destino + "\\" + Path.GetFileName(txbFoto.Text));

                //Grava os dados no banco de dados
                string DataBanco = dtpNascimento.Value.ToString("yyyy-MM-dd");
                Pessoa NovaPessoa = new Pessoa(txbNome.Text, txbEmail.Text, mskFone.Text, DataBanco, cbbSexo.SelectedItem.ToString(), Path.GetFileName(txbFoto.Text), 1);
                int id = NovaPessoa.InserePessoa();
                MessageBox.Show("Pessoa inserida", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Criando o log
                string arquivoLog = @Destino + @"\insere.txt";
                if (!File.Exists(arquivoLog))
                
                    File.Create(arquivoLog).Close();
                File.AppendAllText(arquivoLog, "Usuario: " + usuarioLogado.Nome + " - inseriu um registro " + id + " em " + DateTime.Now.ToString() + "\r\n");

                //Atualiza o datagrid
                dgvPessoas.DataSource = Pessoa.BuscaTodasPessoas();

                

            }
        }


        private bool ValidaDados()
        {
            if (txbNome.Text == string.Empty)
            {
                MessageBox.Show("Digite o nome", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbNome.Focus();
                return false;
            }

            if (txbEmail.Text == string.Empty)
            {
                MessageBox.Show("Digite o Email", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbEmail.Focus();
                return false;
            }

            if (mskFone.Text == string.Empty)
            {
                MessageBox.Show("Digite o fone", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mskFone.Focus();
                return false;
            }

            if (dtpNascimento.CustomFormat == "")
            {
                MessageBox.Show("Selecione a data de nascimento", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNascimento.Focus();
                return false;
            }

            if (cbbSexo.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o Sexo", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbSexo.Focus();
                return false;
            }

            if (txbFoto.Text == string.Empty)
            {
                MessageBox.Show("Selecione a foto", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnFoto.Focus();
                return false;
            }
            return true;
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog AbreFoto = new OpenFileDialog();
            AbreFoto.Title = "Selecione uma foto";
            AbreFoto.Filter = "ALL files (*.*)|*.*";
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

                    MessageBox.Show("Erro ao carregar a imagem", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


        static bool CopiarArquivo(string nomeArquivoOrigem, string nomeArquivoDestino)
        {
            if (File.Exists(nomeArquivoOrigem) == false)
            {
                MessageBox.Show("Atenção! \nNão foi possível encontrar a foto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (File.Exists(nomeArquivoDestino) == true)
            {
                if (MessageBox.Show("Atenção! \nJá existe foto com esse nome, deseja substituir a foto?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
                MessageBox.Show("Foto salva!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao salvar a foto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private void dgvPessoas_Click(object sender, EventArgs e)
        {
            toolStripSalvar.Enabled = false;
            toolStripAtualizar.Enabled = true;
            toolStripExcluir.Enabled = true;
            toolStripCancelar.Visible = true;
            btnFoto.Enabled = false;
            picFoto.Enabled = true;
            dgvPessoas.DefaultCellStyle.SelectionBackColor = Color.Tomato;
            try
            {
                MostraPessoa();
            }
            catch (Exception)
            {

                MessageBox.Show("Não há foto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void toolStripCancelar_Click(object sender, EventArgs e)
        {
            LimpaDados();
            toolStripSalvar.Enabled = true;
            toolStripAtualizar.Enabled = false;
            toolStripExcluir.Enabled = false;
            toolStripCancelar.Visible = false;
            toolStripMudaFoto.Visible = false;
            btnFoto.Enabled = true;
            dgvPessoas.DefaultCellStyle.SelectionBackColor = Color.CornflowerBlue;
            txbNome.Enabled = true;
            txbEmail.Enabled = true;
            mskFone.Enabled = true;
            dtpNascimento.Enabled = true;
            cbbSexo.Enabled = true;

        }


        private void LimpaDados()
        {
            txbId.Clear();
            txbNome.Clear();
            txbEmail.Clear();
            mskFone.Clear();
            dtpNascimento.Value = DateTime.Now;
            cbbSexo.SelectedIndex = -1;
            txbFoto.Clear();
            picFoto.Image = null;
            txbNome.Focus();

        }


        private void MostraPessoa()
        {
            if (dgvPessoas.SelectedRows.Count > 0)
            {
                txbId.Text = dgvPessoas.SelectedRows[0].Cells[0].Value.ToString();
                txbNome.Text = dgvPessoas.SelectedRows[0].Cells[1].Value.ToString();
                txbEmail.Text = dgvPessoas.SelectedRows[0].Cells[2].Value.ToString();
                mskFone.Text = dgvPessoas.SelectedRows[0].Cells[3].Value.ToString();
                txbFoto.Text = dgvPessoas.SelectedRows[0].Cells[4].Value.ToString();
                dtpNascimento.Text = dgvPessoas.SelectedRows[0].Cells[6].Value.ToString();
                cbbSexo.Text = dgvPessoas.SelectedRows[0].Cells[7].Value.ToString();
                picFoto.Image = null;
                picFoto.Load(dgvPessoas.SelectedRows[0].Cells[4].Value.ToString());

            }
        }

        private void toolStripAtualizar_Click(object sender, EventArgs e)
        {
            if (ValidaDados())
            {
                string dataBanco = dtpNascimento.Value.ToString("yyyy-MM-dd");
                Pessoa Atualiza = new Pessoa(int.Parse(txbId.Text), txbNome.Text, txbEmail.Text, mskFone.Text, dataBanco, cbbSexo.SelectedItem.ToString());
                Atualiza.AlteraPessoa();
                toolStripCancelar.PerformClick();
                dgvPessoas.DataSource = Pessoa.BuscaTodasPessoas();
                MessageBox.Show("Pessoa atualizada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripExcluir_Click(object sender, EventArgs e)
        {
            DialogResult Pergunta = MessageBox.Show("Deseja excluir esta pessoa?", "aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Pergunta == DialogResult.Yes)
            {
                Pessoa Desativada = new Pessoa(int.Parse(txbId.Text), 0);
                Desativada.DesativaPessoa();
                toolStripCancelar.PerformClick();
                dgvPessoas.DataSource = Pessoa.BuscaTodasPessoas();
                MessageBox.Show("Pessoa excluida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void picFoto_DoubleClick(object sender, EventArgs e)
        {
            if (usuarioLogado.Nivel == 0)
            {
                txbId.Enabled = false;
                txbNome.Enabled = false;
                txbEmail.Enabled = false;
                mskFone.Enabled = false;
                dtpNascimento.Enabled = false;
                cbbSexo.Enabled = false;
                toolStripAtualizar.Enabled = false;
                toolStripExcluir.Enabled = false;
                toolStripMudaFoto.Visible = true;
                toolStripCancelar.Visible = true;
                btnFoto.Enabled = true;
                btnFoto.PerformClick();
            }
            else
            {
                MessageBox.Show("Você não tem permissão para alterar a foto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void toolStripMudaFoto_Click(object sender, EventArgs e)
        {
            //Copia a foto
            string Destino = Directory.GetCurrentDirectory();
            CopiarArquivo(txbFoto.Text, @Destino + "\\" + Path.GetFileName(txbFoto.Text));

            //Atualiza o banco de dados
            Pessoa MudaFoto = new Pessoa(int.Parse(txbId.Text), Path.GetFileName(txbFoto.Text));
            MudaFoto.AlteraFoto();
            toolStripCancelar.PerformClick();
            dgvPessoas.DataSource = Pessoa.BuscaTodasPessoas();
            txbNome.Enabled = true;
            txbEmail.Enabled = true;
            mskFone.Enabled = true;
            dtpNascimento.Enabled = true;
            cbbSexo.Enabled = true;
            toolStripMudaFoto.Enabled = false;
        }

        private void toolStripAlterarSenha_Click(object sender, EventArgs e)
        {
            frmSenha TS = new frmSenha(usuarioLogado );
            TS.ShowDialog();
        }

        private void cbbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbBuscar.SelectedIndex == 0 || cbbBuscar.SelectedIndex == 5)
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
            try
            {
                if (cbbBuscar.SelectedIndex == 0)
                {
                    dgvPessoas.DataSource = Pessoa.BuscaTodasPessoas();
                }
                if (cbbBuscar.SelectedIndex == 1)
                {
                    dgvPessoas.DataSource = Pessoa.BuscaporId(int.Parse(txbBuscar.Text));
                }
                if (cbbBuscar.SelectedIndex == 2)
                {
                    dgvPessoas.DataSource = Pessoa.BuscaporNome(txbBuscar.Text);
                }
                if (cbbBuscar.SelectedIndex == 3)
                {
                    dgvPessoas.DataSource = Pessoa.BuscaporEmail(txbBuscar.Text);
                }
                if (cbbBuscar.SelectedIndex == 4)
                {
                    dgvPessoas.DataSource = Pessoa.BuscaporFone(txbBuscar.Text);
                }
                if (cbbBuscar.SelectedIndex == 5)
                {
                    dgvPessoas.DataSource = Pessoa.BuscaporDesativado();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Verifique o campo de busca", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbBuscar.Focus();
            }
        }

        private void toolStripUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuario TU = new frmUsuario(usuarioLogado);
            TU.ShowDialog();
        }
    }
}
