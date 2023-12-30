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
    public class Usuario
    {
        #region "Variaveis"

        private int _id_usuario;
        private string _nome;
        private string _email;
        private string _login;
        private string _senha;
        private string _frase;
        private int _nivel;
        private int _ativo;

        #endregion


        #region "Propriedades"

        public int Id_usuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
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

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        public string Frase
        {
            get { return _frase; }
            set { _frase = value; }
        }

        public int Nivel
        {
            get { return _nivel; }
            set { _nivel = value; }
        }

        public int Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }

        #endregion


        #region "Construtores"

        //Construtor padrão
        public Usuario()
        {
            Id_usuario = 0;
            Nome = string.Empty;
            Email = string.Empty;
            Login = string.Empty;
            Senha = string.Empty;
            Frase = string.Empty;
            Nivel = 0;
            Ativo = 0;
        }

        //Construtor para efetuar o login
        public Usuario(int id_usuario, string nome, string email, string login, string senha, string frase, int nivel, int ativo)
        {
            Id_usuario = id_usuario;
            Nome = nome;
            Email = email;
            Login = login;
            Senha = senha;
            Frase = frase;
            Nivel = nivel;
            Ativo = ativo;
        }

        //Construtor para inserir um usuario
        public Usuario(string nome, string email, string login, string senha, string frase, int nivel, int ativo)
        {
            Nome = nome;
            Email = email;
            Login = login;
            Senha = senha;
            Frase = frase;
            Nivel = nivel;
            Ativo = ativo;
        }

        //Construtor para alterar um usuario
        public Usuario(int id_usuario, string nome, string email, string login, int nivel)
        {
            Id_usuario = id_usuario;
            Nome = nome;
            Email = email;
            Login = login;
            Nivel = nivel;
            
        }

        //Construtor para ativar/desativar um usuario
        public Usuario(int id_usuario, int ativo)
        {
            Id_usuario = id_usuario;
            Ativo = ativo;
        }

        //Construtor para alterar a senha do infeliz
        public Usuario(int id_usuario, string senha, string frase)
        {
            Id_usuario = id_usuario;
            Senha = senha;
            Frase = frase;
        }

        #endregion


        #region "Métodos"

        //Método para efetuar o login
        public static void RealizarLogin(string login, string senha)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE login = '" + login + "'";
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.dr = cn.comando.ExecuteReader();
                if (cn.dr.HasRows)
                {
                    Usuario usuarioLogado = new Usuario();
                    while (cn.dr.Read())
                    {
                        usuarioLogado = new Usuario(Convert.ToInt32(cn.dr["id_usuario"]), cn.dr["nome"].ToString(), cn.dr["email"].ToString(), cn.dr["login"].ToString(), cn.dr["senha"].ToString(),
                                                                     cn.dr["frase"].ToString(), Convert.ToInt32(cn.dr["nivel"]), Convert.ToInt32(cn.dr["ativo"]));
                       
                    }
                    if (usuarioLogado.Ativo == 1)
                    {
                        if (usuarioLogado.Senha == senha)
                        {
                            Telas.frmPrincipal TP = new Telas.frmPrincipal(usuarioLogado);
                            TP.ShowDialog();
                        }
                        else
                        {
                            throw new Exception("Senha inválida");
                        }
                    }
                    else
                    {
                        throw new Exception("Usuario bloqueado\nEntre em contato com Administrador");
                    }
                }
                else
                {
                    throw new Exception("Usuario não encontrado");
                }
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


        //Método para alterar a senha do usuario
        public void AlterarSenha()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_usuarios SET senha = '{0}', frase = '{1}' WHERE id_usuario = {2}", Senha, Frase, Id_usuario);
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

        //Método para buscar todos os usuarios ativados
        public static dynamic BuscarTodosUsuariosAtivados()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE ativo = 1";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "usuario");
                return cn.ds.Tables["usuario"];
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Método para buscar todos os usuarios Desativados
        public static dynamic BuscarTodosUsuariosDesativados()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE ativo = 0";
                cn.da = new SqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "usuario");
                return cn.ds.Tables["usuario"];
            }
            catch (Exception)
            {

                throw;
            }
        }



        //Método para ativar um usuario
        public void AtivarUsuario()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_usuarios SET ativo = 1 WHERE id_usuario = {0}", Id_usuario);
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Método para Desativar um usuario
        public void DesativarUsuario()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_usuarios SET ativo = 0 WHERE id_usuario = {0}", Id_usuario);
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Método para inserir um usuario
        public void InsereUsuario()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("INSERT INTO tab_usuarios (nome, email, senha, frase, nivel, ativo, login) VALUES('{0}', '{1}', '{2}', '{3}', {4}, {5}, '{6}')", Nome, Email, Senha, Frase, Nivel, Ativo, Login);
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
        }


        //Método para alterar um usuario
        public void AlteraUsuario()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("UPDATE tab_usuarios SET nome = '{0}', email = '{1}', login = '{2}', nivel = {3} WHERE id_usuario = {4}", Nome, Email, Login, Nivel, Id_usuario);
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

        //Método para verificar se login ja foi cadastrado
        public static bool VerificarLogin(string login)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE login ='" + login + "'";
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.dr = cn.comando.ExecuteReader();
                if (cn.dr.HasRows)
                {
                    MessageBox.Show("ATENÇÃO!! LOGIN EXISTENTE!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
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

        //Método para verificar se email ja foi cadastrado
        public static bool VerificarEmail(string email)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE email ='" + email + "'";
                cn.comando = new SqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.dr = cn.comando.ExecuteReader();
                if (cn.dr.HasRows)
                {
                    MessageBox.Show("ATENÇÃO!! EMAIL EXISTENTE!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
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
