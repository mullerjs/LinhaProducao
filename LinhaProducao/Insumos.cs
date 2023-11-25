using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhaProducao
{
    internal class Insumos : Conexao
    {

        public int id;

        public int id_produto;

        public string nome;

        public decimal quantidade;

        public string unidade;

        public DateTime data_cadastro;

        public List<Insumos> GetListaInsumos()
        {

            List<Insumos> listaInsumos = new List<Insumos>();

            try
            {
                OpenConnection();


                string query = "SELECT * FROM insumos";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Insumos insumo = new Insumos();
                            insumo.id               = Convert.ToInt32(reader.GetString("id"));
                            insumo.id_produto       = Convert.ToInt32(reader.GetString("id_empresa"));
                            insumo.nome             = reader.GetString("nome");
                            insumo.quantidade       = Convert.ToDecimal(reader.GetString("quantidade"));
                            insumo.unidade          = reader.GetString("unidade");
                            insumo.data_cadastro    = DateTime.Parse(reader.GetString("data_cadastro"));
                            listaInsumos.Add(insumo);
                        }
                    }
                }

                CloseConnection();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

            return listaInsumos;
        }

        public bool Insert()
        {

            try
            {

                string query = "INSERT INTO `insumos` (`id_produto, `nome`, `quantidade`, `unidade`) VALUES (@id_produto, @nome, @quantidade, @unidade);";

                MySqlParameter[] param = new MySqlParameter[]
                {
                new MySqlParameter("@id_produto", this.id_produto),
                new MySqlParameter("@nome", this.nome),
                new MySqlParameter("@quantide", this.quantidade),
                new MySqlParameter("@unidade", this.unidade),
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
