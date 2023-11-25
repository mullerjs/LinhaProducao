using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhaProducao
{
    internal class Etapas : Conexao
    {
        public int id;

        public string nome;

        public int ordem;

        public int id_processo;

        public DateTime data_cadastro;

        public List<Etapas> GetListaEtapas()
        {

            List<Etapas> listaEtapas = new List<Etapas>();

            try
            {
                OpenConnection();


                string query = "SELECT * FROM etapas";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Etapas etapa = new Etapas();
                            etapa.id            = Convert.ToInt32(reader.GetString("id"));
                            etapa.nome          = reader.GetString("nome");
                            etapa.ordem         = Convert.ToInt32(reader.GetString("ordem"));
                            etapa.id_processo   = Convert.ToInt32(reader.GetString("id_processo"));
                            etapa.data_cadastro = DateTime.Parse(reader.GetString("data_cadastro"));
                            listaEtapas.Add(etapa);
                        }
                    }
                }

                CloseConnection();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

            return listaEtapas;
        }

        public bool Insert()
        {

            try
            {

                string query = "INSERT INTO `etapas` (`nome`, `ordem`, `id_processo`) VALUES (@nome, @ordem, @id_processo);";

                MySqlParameter[] param = new MySqlParameter[]
                {
                new MySqlParameter("@nome", this.nome),
                new MySqlParameter("@ordem", this.ordem),
                new MySqlParameter("@id_processo", this.id_processo),
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
