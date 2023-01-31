using controle_contas_a_pagar_receber.Model;
using controle_contas_a_pagar_receber.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Data;

namespace controle_contas_a_pagar_receber.Controller
{

    public class EnderecoController : IDisposable
    {

        private ConexaoMySQL conexao;

        public int create(Endereco endereco)
        {
            string query = "INSERT INTO endereco (logradouro, numero, cidade, cep, uf) VALUES (@logradouro, @numero, @cidade, @cep, @uf);";

            using (this.conexao = new ConexaoMySQL())
            {
                this.conexao.Command.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                this.conexao.Command.Parameters.AddWithValue("@numero", endereco.Numero);
                this.conexao.Command.Parameters.AddWithValue("@cidade", endereco.Cidade);
                this.conexao.Command.Parameters.AddWithValue("@cep", endereco.CEP);
                this.conexao.Command.Parameters.AddWithValue("@uf", endereco.UF);

                this.conexao.Command.CommandText = query;

                int rowsAffected = this.conexao.Command.ExecuteNonQuery();

                endereco.ID = (int)this.conexao.Command.LastInsertedId;

            }

            return endereco.ID;

        }

        public Endereco read(int id)
        {
            Endereco endereco = null;
            string query = "SELECT * FROM endereco WHERE id = @id;";

            using (this.conexao = new ConexaoMySQL())
            {
                this.conexao.Command.Parameters.AddWithValue("@id", id);

                this.conexao.Command.CommandText = query;

                this.conexao.Reader = conexao.Command.ExecuteReader();

                while (this.conexao.Reader.Read())
                {
                    endereco = new Endereco();
                    endereco.ID = id;
                    endereco.Logradouro = this.conexao.Reader["logradouro"].ToString();
                    endereco.Numero = this.conexao.Reader["numero"].ToString();
                    endereco.Cidade = this.conexao.Reader["cidade"].ToString();
                    endereco.CEP = this.conexao.Reader["cep"].ToString();
                    endereco.UF = this.conexao.Reader["uf"].ToString();
                }

            }

            return endereco;

        }

        public Boolean update(Endereco endereco)
        {
            int rowsAffected = 0;
            string query = "UPDATE endereco SET logradouro = @logradouro, numero = @numero, cidade = @cidade, cep = @cep, uf = @uf WHERE id = @id;";

            using (this.conexao = new ConexaoMySQL())
            {
                this.conexao.Command.Parameters.AddWithValue("@id", endereco.ID);
                this.conexao.Command.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                this.conexao.Command.Parameters.AddWithValue("@numero", endereco.Numero);
                this.conexao.Command.Parameters.AddWithValue("@cidade", endereco.Cidade);
                this.conexao.Command.Parameters.AddWithValue("@cep", endereco.CEP);
                this.conexao.Command.Parameters.AddWithValue("@uf", endereco.UF);

                this.conexao.Command.CommandText = query;

                rowsAffected = this.conexao.Command.ExecuteNonQuery();

            }

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;

        }

        public Boolean delete(int id)
        {
            int rowsAffected = 0;
            string query = "DELETE FROM endereco WHERE id = @id;";

            using (this.conexao = new ConexaoMySQL())
            {
                this.conexao.Command.Parameters.AddWithValue("@id", id);

                this.conexao.Command.CommandText = query;

                rowsAffected = this.conexao.Command.ExecuteNonQuery();

            }

            if (rowsAffected > 0)
            {
                return true;
            }

            return false;

        }

        public DataTable obterTodos()
        {
            DataTable tabela = null; //new DataTable("enderecos");

            using (this.conexao = new ConexaoMySQL())
            {
                string query = "SELECT * FROM endereco ORDER BY uf, cep, cidade, logradouro;";

                this.conexao.Command.CommandText = query;

                this.conexao.Reader = conexao.Command.ExecuteReader();

                if (this.conexao.Reader.HasRows)
                {
                    tabela = new DataTable();
                    tabela.Columns.Add("id");
                    tabela.Columns.Add("logradouro");
                    tabela.Columns.Add("numero");
                    tabela.Columns.Add("cidade");
                    tabela.Columns.Add("cep");
                    tabela.Columns.Add("uf");

                    while (this.conexao.Reader.Read())
                    {
                        DataRow row = tabela.NewRow();
                        row["id"] = int.Parse(this.conexao.Reader["id"].ToString());
                        row["logradouro"] = this.conexao.Reader["logradouro"].ToString();
                        row["numero"] = this.conexao.Reader["numero"].ToString();
                        row["cidade"] = this.conexao.Reader["cidade"].ToString();
                        row["cep"] = this.conexao.Reader["cep"].ToString();
                        row["uf"] = this.conexao.Reader["uf"].ToString();

                        tabela.Rows.Add(row);

                    }

                }
            }

            return tabela;

        }

        public void Dispose() 
        {
            this.conexao.Dispose();
        }

    }

}
