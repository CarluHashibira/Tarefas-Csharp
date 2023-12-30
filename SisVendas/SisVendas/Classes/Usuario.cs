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
    public class Usuario
    {
        #region "Variáveis"

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

        // Construtor padrão
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

        // Construtor para Efetuar o Login
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

        // Construtor para inserir um usuário
        public Usuario(string nome,
                      string email,
                      string login,
                      string senha,
                      string frase,
                      int nivel,
                      int ativo)
        {
            Nome = nome;
            Email = email;
            Login = login;
            Senha = senha;
            Frase = frase;
            Nivel = nivel;
            Ativo = ativo;
        }

        // Construtor para alterar um usuário
        public Usuario(int _id_usuario,
                      string nome,
                      string email,
                      string login,
                      int nivel)
        {
            Id_usuario = _id_usuario;
            Nome = nome;
            Email = email;
            Login = login;
            Nivel = nivel;
        }

        // Construtor para alterar a senha de um usuário
        public Usuario(int _id_usuario,
                      string senha,
                      string frase)
        {
            Id_usuario = _id_usuario;
            Senha = senha;
            Frase = frase;
        }

        // Construtor para Ativar/Desativar um usuário
        public Usuario(int _id_usuario, int ativo)
        {
            Id_usuario = _id_usuario;
            Ativo = ativo;
        }

        // Construtor para o DataGrid buscar um usuário
        public Usuario(int _id_usuario)
        {
            Id_usuario = _id_usuario;
        }

        #endregion

        #region "Métodos"

        public static void RealizarLogin(string login, string senha)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE login = '" + login + "'";
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.dr = cn.comando.ExecuteReader();
                if (cn.dr.HasRows)
                {
                    Usuario usuarioLogado = new Usuario();
                    while (cn.dr.Read())
                    {
                        usuarioLogado = new Usuario(Convert.ToInt32(cn.dr["id_usuario"]),
                                                cn.dr["nome"].ToString(),
                                                cn.dr["email"].ToString(),
                                                cn.dr["login"].ToString(),
                                                cn.dr["senha"].ToString(),
                                                cn.dr["frase"].ToString(),
                                                Convert.ToInt32(cn.dr["nivel"]),
                                                Convert.ToInt32(cn.dr["ativo"]));
                    }
                    if (usuarioLogado.Ativo == 1)
                    {
                        if (usuarioLogado.Senha == senha)
                        {
                            Telas.FrmPrincipal TP = new Telas.FrmPrincipal(usuarioLogado);
                            TP.ShowDialog();
                        }
                        else
                        {
                            throw new Exception("Senha inválida!");
                        }
                    }
                    else
                    {
                        throw new Exception("Usuário bloqueado!");
                    }
                }
                else
                {
                    throw new Exception("Usuário não cadastrado!");
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


        // Método para inserir um usuário
        public void InsereUsuario()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("INSERT INTO tab_usuarios(nome, email, login, senha, frase, nivel, ativo) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5}, {6})", Nome, Email, Login, Senha, Frase, Nivel, Ativo);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Usuário inserido!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        // Método para alterar um usuário
        public void AlteraUsuario()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("UPDATE tab_usuarios SET nome = '{0}', email = '{1}', login = '{2}', nivel = '{3}' WHERE id_usuario = {4}", Nome, Email, Login, Nivel, Id_usuario);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Usuário alterado!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        // Método para alterar a senha de um usuário
        public void AlteraSenha()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("UPDATE tab_usuarios SET senha = '{0}', frase = '{1}' WHERE id_usuario = {2}", Senha, Frase, Id_usuario);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Senha alterada!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        // Método para Desativar um usuário
        public void DesativaUsuario()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("UPDATE tab_usuarios SET ativo = 0 WHERE id_usuario = {0}", Id_usuario);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Usuário desativado!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        // Método para Ativar um usuário
        public void AtivaUsuario()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = string.Format("UPDATE tab_usuarios SET ativo = 1 WHERE id_usuario = {0}", Id_usuario);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Usuário ativado!", "Cadastro de Usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
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



        // Método para mostrar todos os usuários ativados no DataGrid
        public static dynamic BuscarTodosUsuarios()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE ativo = 1";
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Usuarios");
                return cn.ds.Tables["Usuarios"];
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Método para mostrar todos os usuários desativados no DataGrid
        public static dynamic BuscarTodosUsuariosDesativados()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_usuarios WHERE ativo = 0";
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "UsuariosDesativados");
                return cn.ds.Tables["UsuariosDesativados"];
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
