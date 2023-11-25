using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhaProducao
{
    internal class LinhaProducao : Conexao
    {
        public int id;

        public string nome;

        public int id_empresa;

        public int id_setor;

        public int id_responsavel;

        public DateTime data_cadastro;

        public List<LinhaProducao> GetListaLinhaProducao()
        {

            List<LinhaProducao> listaLinhaProducao = new List<LinhaProducao>();

            try
            {
                OpenConnection();


                string query = "SELECT * FROM linha_producao";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LinhaProducao linhaProducao = new LinhaProducao();
                            linhaProducao.id                    = Convert.ToInt32(reader.GetString("id"));
                            linhaProducao.nome                  = reader.GetString("nome");
                            linhaProducao.id_empresa            = Convert.ToInt32(reader.GetString("id_empresa"));
                            linhaProducao.id_setor              = Convert.ToInt32(reader.GetString("id_setor"));
                            linhaProducao.id_responsavel        = Convert.ToInt32(reader.GetString("id_responsalvel"));
                            linhaProducao.data_cadastro         = DateTime.Parse(reader.GetString("data_cadastro"));
                            listaLinhaProducao.Add(linhaProducao);
                        }
                    }
                }

                CloseConnection();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

            return listaLinhaProducao;
        }

        public bool Insert()
        {

            try
            {

                string query = "INSERT INTO `linha_producao` (`nome`, `id_empresa`, `id_setor`, `id_responsavel`) VALUES (@nome, @id_empresa, @id_setor, @id_responsavel);";

                MySqlParameter[] param = new MySqlParameter[]
                {
                new MySqlParameter("@nome", this.nome),
                new MySqlParameter("@id_empresa", this.id_empresa),
                new MySqlParameter("@id_setor", this.id_setor),
                new MySqlParameter("@id_responsavel", this.id_responsavel),
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
