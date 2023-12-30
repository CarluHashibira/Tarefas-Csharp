using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisVendas.Classes
{
    public class Produto
    {
        #region "Variáveis"

        private int _id_produto;
        private string _nome;
        private string _foto;
        private string _descricao;
        private int _qtde;
        private decimal _valor;
        private int _ativo;

        #endregion

        #region "Propriedades"

        public int Id_produto
        {
            get { return _id_produto; }
            set { _id_produto = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        public int Qtde
        {
            get { return _qtde; }
            set { _qtde = value; }
        }

        public decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        public int Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

        #endregion

        #region "Construtores"

        // Construtor padrão
        public Produto()
        {
            Id_produto = 0;
            Nome = string.Empty;
            Foto = string.Empty;
            Descricao = string.Empty;
            Qtde = 0;
            Valor = 0;
            Ativo = 0;
        }

        // Construtor para inserir um produto
        public Produto(string nome,
                      string foto,
                      string descricao,
                      int qtde,
                      decimal valor,
                      int ativo)
        {
            Nome = nome;
            Foto = foto;
            Descricao = descricao;
            Qtde = qtde;
            Valor = valor;
            Ativo = ativo;
        }

        // Construtor para alterar um produto
        public Produto(int id_produto,
                      string nome,
                      string descricao,
                      int qtde,
                      decimal valor)
        {
            Id_produto = id_produto;
            Nome = nome;
            Descricao = descricao;
            Qtde = qtde;
            Valor = valor;
        }

        // Construtor para alterar a foto de um produto
        public Produto(int id_produto, string foto)
        {
            Id_produto = id_produto;
            Foto = foto;
        }

        // Construtor para Ativar/Desativar um produto
        public Produto(int id_produto, int ativo)
        {
            Id_produto = id_produto;
            Ativo = ativo;
        }

        // Construtor para o DataGrid buscar um produto
        public Produto(int id_produto)
        {
            Id_produto = id_produto;
        }

        // Construtor para entrada e saída de produto
        public Produto(int id_produto, int qtde, int ativo)
        {
            Id_produto = id_produto;
            Qtde = qtde;
            Ativo = ativo;
        }

        #endregion

        #region "Métodos"

        // Método para inserir um produto
        public void InsereProduto()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("INSERT INTO tab_produtos(nome, foto, descricao, qtde, valor, ativo) VALUES('{0}', '{1}', '{2}', {3}, {4}, {5})", Nome, Foto, Descricao, Qtde, Valor.ToString(CultureInfo.InvariantCulture), Ativo);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Produto inserido!", "Cadastro de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.FechaConexao();
            }
        }


        // Método para alterar um produto
        public void AlteraProduto()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("UPDATE tab_produtos SET nome = '{0}', descricao = '{1}', qtde = {2}, valor = {3} WHERE id_produto = {4}", Nome, Descricao, Qtde, Valor.ToString(CultureInfo.InvariantCulture), Id_produto);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Produto alterado!", "Cadastro de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.FechaConexao();
            }
        }


        //Método para Excluir um produto
        public void ExcluiProduto()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("DELETE FROM tab_produtos WHERE id_produto = {0}", Id_produto);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Produto excluído!", "Cadastro de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.FechaConexao();
            }
        }


        // Método para alterar a foto de um produto
        public void AlteraFoto()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("UPDATE tab_produtos SET foto = '{0}' WHERE id_produto = {1}", Foto, Id_produto);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Foto alterada", "Cadastro de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.FechaConexao();
            }
        }


        // Método para Desativar um produto
        public void DesativaProduto()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("UPDATE tab_produtos SET ativo = 0 WHERE id_produto = {0}", Id_produto);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Produto desativado!", "Cadastro de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.FechaConexao();
            }
        }


        // Método para Ativar um produto
        public void AtivaProduto()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("UPDATE tab_produtos SET ativo = 1 WHERE id_produto = {0}", Id_produto);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Produto ativado!", "Cadastro de Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.FechaConexao();
            }
        }



        // Método para mostrar "todos os produtos" no DataGridView
        public static dynamic BuscarTodosProdutos()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_produtos WHERE ativo = 1";
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Produtos");
                return cn.ds.Tables["Produtos"];
            }
            catch (Exception)
            {

                throw;
            }
        }



        // Método para mostrar "todos os produtos" desativados
        public static dynamic BuscarTodosProdutosDesativados()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_produtos WHERE ativo = 0";
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Produtos");
                return cn.ds.Tables["Produtos"];
            }
            catch (Exception)
            {

                throw;
            }
        }




        // Método para buscar por nome
        public static dynamic BuscarPorNome(string nome)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_produtos WHERE nome LIKE '%" + nome + "%'";
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Produtos");
                return cn.ds.Tables["Produtos"];
            }
            catch (Exception)
            {

                throw;
            }
        }




        // Método para buscar por ID
        public static dynamic BuscarPorID(int id)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_produtos WHERE id_produto = " + id;
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Produtos");
                return cn.ds.Tables["Produtos"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para mostrar "todas os produtos ativos" no ComboBox
        public static dynamic CarregaCombo()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_produtos WHERE ativo = 1 ORDER BY nome";
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Produtos");
                return cn.ds.Tables["Produtos"];
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Método para dar baixa na qtde dos produtos
        public void BaixaNosProdutos()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("UPDATE tab_produtos SET qtade = qtde - {0} WHERE id_produto = {1} AND ativo = {2}", Qtde, Id_produto, Ativo);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {



                throw;
            }
            finally
            {
                cn.FechaConexao();
            }
        }

        // Método para repor produtos
        public void ReporProdutos()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("UPDATE tab_produtos SET qtade = qtde + {0} WHERE id_produto = {1} AND ativo = {2}", Qtde, Id_produto, Ativo);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.FechaConexao();
            }
        }

        #endregion
    }
}
