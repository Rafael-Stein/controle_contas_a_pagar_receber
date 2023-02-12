using controle_contas_a_pagar_receber.Model;
using controle_contas_a_pagar_receber.Model.DataBase;
using System;
using System.Data;

namespace controle_contas_a_pagar_receber.Controller
{

  public class ClienteController : IDisposable
  {

    private ConexaoMySQL conexao;

    public int create(Cliente cliente)
    {
      string query = "INSERT INTO cliente (razaoSocial_nome, cnpj_cpf, logradouro, numero, cidade, cep, uf, contatoNome, contatoEmail, contatoTelefone) VALUES (@razaoSocial_nome, @cnpj_cpf,  @logradouro, @numero, @cidade, @cep, @uf, @contatoNome, @contatoEmail, @contatoTelefone);";

      using (this.conexao = new ConexaoMySQL())
      {
        this.conexao.Command.Parameters.AddWithValue("@razaoSocial_nome", cliente.RazaoSocial_Nome);
        this.conexao.Command.Parameters.AddWithValue("@cnpj_cpf", cliente.CNPJ_CPF);
        this.conexao.Command.Parameters.AddWithValue("@logradouro", cliente.Logradouro);
        this.conexao.Command.Parameters.AddWithValue("@numero", cliente.Numero);
        this.conexao.Command.Parameters.AddWithValue("@cidade", cliente.Cidade);
        this.conexao.Command.Parameters.AddWithValue("@cep", cliente.CEP);
        this.conexao.Command.Parameters.AddWithValue("@uf", cliente.UF);
        this.conexao.Command.Parameters.AddWithValue("@contatoNome", cliente.ContatoNome);
        this.conexao.Command.Parameters.AddWithValue("@contatoEmail", cliente.ContatoEmail);
        this.conexao.Command.Parameters.AddWithValue("@contatoTelefone", cliente.ContatoTelefone);

        this.conexao.Command.CommandText = query;

        int rowsAffected = this.conexao.Command.ExecuteNonQuery();

        cliente.ID = (int)this.conexao.Command.LastInsertedId;

      }

      return cliente.ID;

    }

    public Cliente read(int id)
    {
      Cliente cliente = null;
      string query = "SELECT * FROM cliente WHERE id = @id;";

      using (this.conexao = new ConexaoMySQL())
      {
        this.conexao.Command.Parameters.AddWithValue("@id", id);

        this.conexao.Command.CommandText = query;

        this.conexao.Reader = conexao.Command.ExecuteReader();

        while (this.conexao.Reader.Read())
        {
          cliente = new Cliente();
          cliente.ID = id;
          cliente.RazaoSocial_Nome = this.conexao.Reader["razaoSocial_nome"].ToString();
          cliente.CNPJ_CPF = this.conexao.Reader["cnpj_cpf"].ToString();
          cliente.Logradouro = this.conexao.Reader["logradouro"].ToString();
          cliente.Numero = this.conexao.Reader["numero"].ToString();
          cliente.Cidade = this.conexao.Reader["cidade"].ToString();
          cliente.CEP = this.conexao.Reader["cep"].ToString();
          cliente.UF = this.conexao.Reader["uf"].ToString();
          cliente.ContatoNome = this.conexao.Reader["contatoNome"].ToString();
          cliente.ContatoEmail = this.conexao.Reader["contatoEmail"].ToString();
          cliente.ContatoTelefone = this.conexao.Reader["contatoTelefone"].ToString();
        }

      }

      return cliente;

    }

    public Boolean update(Cliente cliente)
    {
      int rowsAffected = 0;
      string query = "UPDATE cliente SET razaoSocial_nome = @razaoSocial_nome, cnpj_cpf = @cnpj_cpf, @logradouro = @logradouro, numero = @numero, cidade = @cidade, cep = @cep, uf = @uf, contatoNome = @contatoNome, contatoEmail = @contatoEmail, contatoTelefone = @contatoTelefone WHERE id = @id;";

      using (this.conexao = new ConexaoMySQL())
      {
        this.conexao.Command.Parameters.AddWithValue("@id", cliente.ID);
        this.conexao.Command.Parameters.AddWithValue("@razaoSocial_nome", cliente.RazaoSocial_Nome);
        this.conexao.Command.Parameters.AddWithValue("@cnpj_cpf", cliente.CNPJ_CPF);
        this.conexao.Command.Parameters.AddWithValue("@logradouro", cliente.Logradouro);
        this.conexao.Command.Parameters.AddWithValue("@numero", cliente.Numero);
        this.conexao.Command.Parameters.AddWithValue("@cidade", cliente.Cidade);
        this.conexao.Command.Parameters.AddWithValue("@cep", cliente.CEP);
        this.conexao.Command.Parameters.AddWithValue("@uf", cliente.UF);
        this.conexao.Command.Parameters.AddWithValue("@contatoNome", cliente.ContatoNome);
        this.conexao.Command.Parameters.AddWithValue("@contatoEmail", cliente.ContatoEmail);
        this.conexao.Command.Parameters.AddWithValue("@contatoTelefone", cliente.ContatoTelefone);

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
      string query = "DELETE FROM cliente WHERE id = @id;";

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
      DataTable tabela = null;

      using (this.conexao = new ConexaoMySQL())
      {
        string query = "SELECT * FROM cliente ORDER BY razaoSocial_nome;";

        this.conexao.Command.CommandText = query;

        this.conexao.Reader = conexao.Command.ExecuteReader();

        if (this.conexao.Reader.HasRows)
        {
          tabela = new DataTable();
          tabela.Columns.Add("id");
          tabela.Columns.Add("razaoSocial_nome");
          tabela.Columns.Add("cnpj_cpf");
          tabela.Columns.Add("logradouro");
          tabela.Columns.Add("numero");
          tabela.Columns.Add("cidade");
          tabela.Columns.Add("cep");
          tabela.Columns.Add("uf");
          tabela.Columns.Add("contatoNome");
          tabela.Columns.Add("contatoEmail");
          tabela.Columns.Add("contatoTelefone");

          while (this.conexao.Reader.Read())
          {
            DataRow row = tabela.NewRow();
            row["id"] = int.Parse(this.conexao.Reader["id"].ToString());
            row["razaoSocial_nome"] = this.conexao.Reader["razaoSocial_nome"].ToString();
            row["cnpj_cpf"] = this.conexao.Reader["cnpj_cpf"].ToString();
            row["logradouro"] = this.conexao.Reader["logradouro"].ToString();
            row["numero"] = this.conexao.Reader["numero"].ToString();
            row["cidade"] = this.conexao.Reader["cidade"].ToString();
            row["cep"] = this.conexao.Reader["cep"].ToString();
            row["uf"] = this.conexao.Reader["uf"].ToString();
            row["contatoNome"] = this.conexao.Reader["contatoNome"].ToString();
            row["contatoEmail"] = this.conexao.Reader["contatoEmail"].ToString();
            row["contatoTelefone"] = this.conexao.Reader["contatoTelefone"].ToString();

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
