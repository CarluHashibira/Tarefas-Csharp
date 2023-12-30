using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVendas.Classes
{
    class Conexao
    {
        #region "Variáveis"

        private static string _servidor = @"localhost";
        private static string _baseDeDados = "sisvendas";
        private static string _usuario = "root";
        private static string _senha = "";

        //Linha de conexão para o MySQL com usuário e senha
        private static string _strConexao = "Server=" + _servidor + ";Database=" + _baseDeDados + ";Uid=" + _usuario + ";Pwd=" + _senha;

        public string query;
        public MySqlConnection conexao = new MySqlConnection(_strConexao);
        public MySqlCommand comando;
        public MySqlDataReader dr;
        public MySqlDataAdapter da;
        public DataSet ds;

        #endregion

        #region "Métodos"

        public void AbreConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
            conexao.Open();
        }


        public void FechaConexao()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        #endregion
    }
}
