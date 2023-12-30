using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisVendas.Classes
{
    public class Cliente
    {
        #region "Variáveis"

        private int _id_cliente;
        private string _nome;
        private string _email;
        private string _fone;
        private string _dtnasc;
        private string _sexo;
        private int _ativo;

        #endregion

        #region "Propriedades"

        public int Id_cliente
        {
            get { return _id_cliente; }
            set { _id_cliente = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Fone
        {
            get { return _fone; }
            set { _fone = value; }
        }

        public string Dtnasc
        {
            get { return _dtnasc; }
            set { _dtnasc = value; }
        }

        public string Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }

        public int Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

        #endregion

        #region "Construtores"

        // Construtor padrão
        public Cliente()
        {
            Id_cliente = 0;
            Nome = string.Empty;
            Email = string.Empty;
            Fone = string.Empty;
            Dtnasc = string.Empty;
            Sexo = string.Empty;
            Ativo = 0;
        }

        // Construtor para inserir um cliente
        public Cliente(string nome,
                      string email,
                      string fone,
                      string dtnasc,
                      string sexo,
                      int ativo)
        {
            Nome = nome;
            Email = email;
            Fone = fone;
            Dtnasc = dtnasc;
            Sexo = sexo;
            Ativo = ativo;
        }

        // Construtor para alterar um cliente
        public Cliente(int _id_cliente,
                      string nome,
                      string email,
                      string fone,
                      string dtnasc,
                      string sexo)
        {
            Id_cliente = _id_cliente;
            Nome = nome;
            Email = email;
            Fone = fone;
            Dtnasc = dtnasc;
            Sexo = sexo;
        }

        // Construtor para Ativar/Desativar um cliente
        public Cliente(int _id_cliente, int ativo)
        {
            Id_cliente = _id_cliente;
            Ativo = ativo;
        }

        // Construtor para o DataGrid buscar um cliente
        public Cliente(int _id_cliente)
        {
            Id_cliente = _id_cliente;
        }

        #endregion

        #region "Métodos"

        // Método para inserir um cliente
        public void InsereCliente()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("INSERT INTO tab_clientes(nome, email, fone, dtnasc, sexo, ativo) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5})", Nome, Email, Fone, Dtnasc, Sexo, Ativo);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Cliente inserido!", "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        // Método para alterar um cliente
        public void AlteraCliente()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("UPDATE tab_clientes SET nome = '{0}', email = '{1}', fone = '{2}', dtnasc = '{3}', sexo = '{4}' WHERE id_cliente = {5}", Nome, Email, Fone, Dtnasc, Sexo, Id_cliente);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Cliente alterado!", "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        //Método para Excluir um cliente
        public void ExcluiCliente()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("DELETE FROM tab_clientes WHERE id_cliente = {0}", Id_cliente);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Cliente excluído com sucesso!", "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        // Método para Desativar um cliente
        public void DesativaCliente()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("UPDATE tab_clientes SET ativo = 0 WHERE id_cliente = {0}", Id_cliente);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Cliente desativado!", "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        // Método para Ativar um cliente
        public void AtivaCliente()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("UPDATE tab_clientes SET ativo = 1 WHERE id_cliente = {0}", Id_cliente);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Cliente ativado!", "Cadastro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);
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



        // Método para mostrar todos os clientes no ComboBox
        public static dynamic BuscarTodosClientes()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_clientes WHERE ativo = 1";
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Clientes");
                return cn.ds.Tables["Clientes"];
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
                cn.query = "SELECT * FROM tab_clientes WHERE ativo = 1 AND nome LIKE '%" + nome + "%'";
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Clientes");
                return cn.ds.Tables["Clientes"];
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
                cn.query = "SELECT * FROM tab_clientes WHERE ativo = 1 AND id_cliente = " + id;
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Clientes");
                return cn.ds.Tables["Clientes"];
            }
            catch (Exception)
            {

                throw;
            }
        }



        // Método para buscar por fone
        public static dynamic BuscarPorFone(string fone)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_clientes WHERE ativo = 1 AND fone LIKE '%" + fone + "%'";
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Clientes");
                return cn.ds.Tables["Clientes"];
            }
            catch (Exception)
            {

                throw;
            }
        }



        // Método para buscar por email
        public static dynamic BuscarPorEmail(string email)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_clientes WHERE ativo = 1 AND email LIKE '%" + email + "%'";
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Clientes");
                return cn.ds.Tables["Clientes"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para buscar por inativo
        public static dynamic BuscarPorInativo()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_clientes WHERE ativo = 0";
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Clientes");
                return cn.ds.Tables["Clientes"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Método para mostrar todas os clientes no ComboBox
        public static dynamic CarregaCombo()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_clientes WHERE ativo = 1 ORDER BY nome";
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Clientes");
                return cn.ds.Tables["Clientes"];
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
