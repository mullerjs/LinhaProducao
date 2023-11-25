using LinhaProducao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemProducaoTemProduto
{
    internal class OrdemProducaoTemProdutos : Conexao
    {
        public int id;

        public int id_ordem;

        public int id_producao;

        public int quantidade;

        public DateTime data_cadastro;

        public List<OrdemProducaoTemProdutos> GetListaOrdemProducaoTemProduto()
        {

            List<OrdemProducaoTemProdutos> listaOrdemProducaoTemProdutos = new List<OrdemProducaoTemProdutos>();

            try
            {
                OpenConnection();


                string query = "SELECT * FROM ordem_producao_tem_produtos";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrdemProducaoTemProdutos ordemProducaoTemProdutos = new OrdemProducaoTemProdutos();
                            ordemProducaoTemProdutos.id = Convert.ToInt32(reader.GetString("id"));
                            ordemProducaoTemProdutos.id_ordem = Convert.ToInt32(reader.GetString("id_ordem"));
                            ordemProducaoTemProdutos.id_producao = Convert.ToInt32(reader.GetString("id_producao"));
                            ordemProducaoTemProdutos.quantidade = Convert.ToInt32(reader.GetString("quantidade"));
                            ordemProducaoTemProdutos.data_cadastro = DateTime.Parse(reader.GetString("data_cadastro"));
                            listaOrdemProducaoTemProdutos.Add(ordemProducaoTemProdutos);
                        }
                    }
                }

                CloseConnection();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

            return listaOrdemProducaoTemProdutos;
        }

        public bool Insert()
        {

            try
            {

                string query = "INSERT INTO `ordem_producao_tem_produtos` (`id_ordem`, `id_producao`, `quantidade`) VALUES (@id_ordem, @id_producao, @quantidade);";

                MySqlParameter[] param = new MySqlParameter[]
                {
                new MySqlParameter("@id_ordem", this.id_ordem),
                new MySqlParameter("@id_producao", this.id_producao),
                new MySqlParameter("@quantidade", this.quantidade),
         
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
