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
    public class Pedido
    {
        #region "Propriedades"

        public int Id_pedido { get; set; }

        public int Id_cliente { get; set; }

        public int Id_usuario { get; set; }

        public string Data { get; set; }

        public decimal Total { get; set; }

        public List<ItensPedido> ItensPedido { get; set; }

        #endregion


        #region "Contrutores"

        //Construtor padrão
        public Pedido()
        {
            Id_pedido = 0;
            Id_cliente = 0;
            Id_usuario = 0;
            Data = string.Empty;
            Total = 0;
        }

        //Construtor para excluir um pedido
        public Pedido(int id_pedido)
        {
            Id_pedido = id_pedido;
        }

        //Construtor para inserir um pedido
        public Pedido(int id_pedido,
                      int id_cliente,
                      int id_usuario,
                      string data,
                      decimal total)
        {
            Id_pedido = id_pedido;
            Id_cliente = id_cliente;
            Id_usuario = id_usuario;
            Data = data;
            Total = total;
        }

        #endregion


        #region "Métodos"

        // Método para inserir um pedido e seus itens
        public void InserePedido(int prods)
        {
            long id;
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("INSERT INTO tab_pedidos(id_cliente, id_usuario, data, total) VALUES ({0}, {1},'{2}',{3})", Id_cliente, Id_usuario, Data, Total.ToString(CultureInfo.InvariantCulture));
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                id = cn.comando.LastInsertedId;
                foreach (var item in ItensPedido)
                {
                    item.InsereItem(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        //Método para mostrar todos os pedidos no datagrid
        public static dynamic BuscarTodosPedidos()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_pedidos";
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pedidos");
                return cn.ds.Tables["Pedidos"];
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Método para buscar o último id da tabela pedidos
        public static dynamic BuscaId()
        {
            Conexao cn = new Conexao();
            int codigo = 0;
            cn.AbreConexao();
            cn.query = "SELECT MAX(id_pedido) FROM tab_pedidos";
            cn.comando = new MySqlCommand(cn.query, cn.conexao);
            codigo = (int)cn.comando.ExecuteScalar();
            cn.FechaConexao();
            return codigo;
        }


        //Método para buscar um pedido pelo id
        public static dynamic BuscarPorId(int id)
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = "SELECT * FROM tab_pedidos INNER JOIN tab_itens_pedido " +
                    "ON tab_pedidos.id_pedido = tab_itens_pedido.id_pedido WHERE " +
                    "tab_pedidos.id_pedido = " + id;
                cn.da = new MySqlDataAdapter(cn.query, cn.conexao);
                cn.ds = new DataSet();
                cn.da.Fill(cn.ds, "Pedidos");
                return cn.ds.Tables["Pedidos"];
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Método para excluir o pedido
        public void ExcluiPedido()
        {
            Conexao cn = new Conexao();
            try
            {
                cn.query = String.Format("DELETE FROM tab_pedidos WHERE id_pedido = {0}", Id_pedido);
                cn.comando = new MySqlCommand(cn.query, cn.conexao);
                cn.AbreConexao();
                cn.comando.ExecuteNonQuery();
                MessageBox.Show("Pedido excluído", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
