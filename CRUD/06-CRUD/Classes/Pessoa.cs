using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_CRUD.Classes
{
    public class Pessoa
    {
        #region "Variaveis"

        private int _id_pessoa;
        private string _nome;
        private string _email;
        private string _fone;
        private string _dt_nasc;
        private string _sexo;
        private string _foto;
        private int _ativo;

        #endregion


        #region "Propriedades"

        public int Id_pessoa
        {
            get { return _id_pessoa; }
            set { _id_pessoa = value; }
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

        public string Dt_nasc
        {
            get { return _dt_nasc; }
            set { _dt_nasc = value; }
        }

        public string Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }

        public string Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }

        public int Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

        #endregion


        #region "Construtores"

        //Construtor padrao
        public Pessoa()
        {
            Id_pessoa = 0;
            Nome = string.Empty;
            Email = string.Empty;
            Fone = string.Empty;
            Dt_nasc = string.Empty;
            Sexo = string.Empty;
            Foto = string.Empty;
            Ativo = 0;
        }

        //Construtor para inserir uma pessoa
        public Pessoa(string nome, string email, string fone, string dt_nasc, string sexo, string foto, int ativo)
        {
            Nome = nome;
            Email = email;
            Fone = fone;
            Dt_nasc = dt_nasc;
            Sexo = sexo;
            Foto = foto;
            Ativo = ativo;
        }

        //Construtor para alterar uma pessoa
        public Pessoa(int id_pessoa, string nome, string email, string fone, string dt_nasc, string sexo)
        {
            Id_pessoa = id_pessoa;
            Nome = nome;
            Email = email;
            Fone = fone;
            Dt_nasc = dt_nasc;
            Sexo = sexo;
        }

        //Construtor para ativar/desativar uma pessoa
        public Pessoa(int id_pessoa, int ativo)
        {
            Id_pessoa = id_pessoa;
            Ativo = ativo;
        }

        //Construtor para alterar a foto de uma pessoa
        public Pessoa(int id_pessoa, string foto)
        {
            Id_pessoa = id_pessoa;
            Foto = foto;
            
        }

        #endregion


        #region "Métodos"

        //Método para inserir uma pessoa
        public int InserePessoa()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("INSERT INTO tab_pessoas(nome, email, fone, dt_nasc, sexo, foto, ativo) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}); SELECT SCOPE_IDENTITY()", Nome, Email, Fone, Dt_nasc, Sexo, Foto, Ativo);
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                //cn.comando.ExecuteNonQuery(); //Usado somente com insert
                cn.dr = cn.comando.ExecuteReader();
                if (cn.dr.HasRows)
                {
                    while (cn.dr.Read())
                    {
                        return Convert.ToInt32(cn.dr[0]);
                    }
                }
                return 0;
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

        //Método para alterar uma pessoa
        public void AlteraPessoa()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_pessoas SET nome = '{0}', email = '{1}', fone = '{2}', dt_nasc = '{3}', sexo = '{4}' WHERE id_pessoa = {5} ", Nome, Email, Fone, Dt_nasc, Sexo, Id_pessoa);                
                cn.comando = new SqlCommand(cn.query, cn.conexao);
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

        //Método para alterar a foto de uma pessoa
        public void AlteraFoto()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_pessoas SET foto = '{0}' WHERE id_pessoa = {1} ",Foto, Id_pessoa); 
                cn.comando = new SqlCommand(cn.query, cn.conexao);
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

        //Método para ativar uma pessoa
        public void AtivaPessoa()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_pessoas SET ativo = 1 WHERE id_pessoa = {0} ", Id_pessoa); 
                cn.comando = new SqlCommand(cn.query, cn.conexao);
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

        //Método para desativar uma pessoa
        public void DesativaPessoa()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_pessoas SET ativo = 0 WHERE id_pessoa = {0} ", Id_pessoa); 
                cn.comando = new SqlCommand(cn.query, cn.conexao);
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

        //Método para mostrar todas as pessoas no datagrid
        public static dynamic BuscaTodasPessoas()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_pessoas WHERE ativo = 1";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pessoas");
                return cn.ds.Tables["Pessoas"];
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Método para Buscar por ID
        public static dynamic BuscaporId(int id)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_pessoas WHERE ativo = 1 AND id_pessoa = " + id;
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pessoas");
                return cn.ds.Tables["Pessoas"];
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Método para Buscar por Nome
        public static dynamic BuscaporNome(string nome)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_pessoas WHERE ativo = 1 AND nome LIKE '% " + nome + "%'";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pessoas");
                return cn.ds.Tables["Pessoas"];
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Método para Buscar por Email
        public static dynamic BuscaporEmail(string email)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_pessoas WHERE ativo = 1 AND email LIKE '% " + email + "%'";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pessoas");
                return cn.ds.Tables["Pessoas"];
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Método para Buscar por Fone
        public static dynamic BuscaporFone(string fone)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_pessoas WHERE ativo = 1 AND fone LIKE '% " + fone + "%'";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pessoas");
                return cn.ds.Tables["Pessoas"];
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Método para Buscar por Desativados
        public static dynamic BuscaporDesativado()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_pessoas WHERE ativo = 0";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pessoas");
                return cn.ds.Tables["Pessoas"];
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
