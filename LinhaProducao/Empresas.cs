using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhaProducao
{
    internal class Empresas : Conexao
    {
        public int id;

        public string nome;

        public string cnpj;

        public string email;

        public DateTime data_casdastro;

        public List<Empresas> GetListaEmpresas()
        {

            List<Empresas> listaEmpresas = new List<Empresas>();

            try
            {
                OpenConnection();


                string query = "SELECT * FROM empresas";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empresas empresa = new Empresas();
                            empresa.id              = Convert.ToInt32(reader.GetString("id"));
                            empresa.nome            = reader.GetString("nome");
                            empresa.cnpj            = reader.GetString("cnpj");
                            empresa.email           = reader.GetString("email");
                            empresa.data_casdastro  = DateTime.Parse(reader.GetString("data_cadastro"));
                            listaEmpresas.Add(empresa);
                        }
                    }
                }

                CloseConnection();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

            return listaEmpresas;
        }

        public bool Insert()
        {

            try
            {

                string query = "INSERT INTO `empresas` (`nome`, `cnpj`, `email`) VALUES (@nome, @cnpj, @email);";

                MySqlParameter[] param = new MySqlParameter[]
                {
                new MySqlParameter("@nome", this.nome),
                new MySqlParameter("@cnpj", this.cnpj),
                new MySqlParameter("@email", this.email),
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
