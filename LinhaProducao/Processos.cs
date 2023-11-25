using LinhaProducao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processos
{
    internal class Processos : Conexao
    {
        public int id;

        public string nome;

        public int id_setor;

        public DateTime data_cadastro;

        public List<Processos> GetListaProcessos()
        {

            List<Processos> listaProcessos = new List<Processos>();

            try
            {
                OpenConnection();


                string query = "SELECT * FROM processos";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Processos processos = new Processos();
                            processos.id                    = Convert.ToInt32(reader.GetString("id"));
                            processos.nome                  = reader.GetString("nome");
                            processos.id_setor              = Convert.ToInt32(reader.GetString("id_setor"));
                            processos.data_cadastro         = DateTime.Parse(reader.GetString("data_cadastro"));
                            listaProcessos.Add(processos);
                        }
                    }
                }

                CloseConnection();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

            return listaProcessos;
        }

        public bool Insert()
        {

            try
            {

                string query = "INSERT INTO `processos` (`nome`, `id_setor`) VALUES (@nome, @id_setor);";

                MySqlParameter[] param = new MySqlParameter[]
                {
                new MySqlParameter("@nome", this.nome),
                new MySqlParameter("@id_setor", this.id_setor),
                
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
