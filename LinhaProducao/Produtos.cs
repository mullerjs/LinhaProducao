using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhaProducao
{
    internal class Produtos : Conexao
    {
        public int id;

        public string nome;

        public int id_empresa;

        public DateTime data_cadastro;

        public List<Produtos> GetListaProdutos()
        {

            List<Produtos> listaProdutos = new List<Produtos>();

            try
            {
                OpenConnection();


                string query = "SELECT * FROM produtos";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produtos produtos = new Produtos();
                            produtos.id                 = Convert.ToInt32(reader.GetString("id"));
                            produtos.nome               = reader.GetString("nome");
                            produtos.id_empresa         = Convert.ToInt32(reader.GetString("id_empresa"));
                            produtos.data_cadastro      = DateTime.Parse(reader.GetString("data_cadastro"));
                            listaProdutos.Add(produtos);
                        }
                    }
                }

                CloseConnection();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

            return listaProdutos;
        }

        public bool Insert()
        {

            try
            {

                string query = "INSERT INTO `produtos` (`nome`, `id_empresa`) VALUES (@nome, @id_empresa);";

                MySqlParameter[] param = new MySqlParameter[]
                {
                new MySqlParameter("@nome", this.nome),
                new MySqlParameter("@id_empresa", this.id_empresa),
            
                };

                this.ExecuteQueryWithParameters(query, param);

                return true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

        }
    }
}
