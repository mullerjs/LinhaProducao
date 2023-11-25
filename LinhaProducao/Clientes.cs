using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinhaProducao
{
    internal class Clientes : Conexao
    {
        public int id;

        public int id_empresa;

        public string nome;

        public string telefone;

        private string documento;

        public string email;

        public DateTime data_cadastro;

        public string GetDocumento()
        {
            return documento;
        }
        public void SetDocumento(string documento)
        {
            this.documento = documento;
        }

        public List<Clientes> GetListaClientes()
        {

            List<Clientes> listaClientes = new List<Clientes>();

            try
            {
                OpenConnection();


                string query = "SELECT * FROM clientes";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Clientes cliente = new Clientes();
                            cliente.id              = Convert.ToInt32(reader.GetString("id"));
                            cliente.id_empresa      = Convert.ToInt32(reader.GetString("id_empresa"));
                            cliente.nome            = reader.GetString("nome");
                            cliente.telefone        = reader.GetString("telefone");
                            cliente.SetDocumento(reader.GetString("documento"));
                            cliente.email           = reader.GetString("email");
                            cliente.data_cadastro   = DateTime.Parse(reader.GetString("data_cadastro"));
                            listaClientes.Add(cliente);
                        }
                    }
                }

                CloseConnection();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

            return listaClientes;
        }

        public bool Insert()
        {

            try
            {

                string query = "INSERT INTO `clientes` (`id_empresa`, `nome`, `telefone`, `documento`, `email`) VALUES (@id_empresa, @nome, @telefone, @documento, @email);";

                MySqlParameter[] param = new MySqlParameter[]
                {
                new MySqlParameter("@id_empresa", this.id_empresa),
                new MySqlParameter("@nome", this.nome),
                new MySqlParameter("@telefone", this.telefone),
                new MySqlParameter("@documento", this.documento),
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
