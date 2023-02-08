using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace controle_contas_a_pagar_receber.Model.DataBase
{

  public class ConexaoMySQL : IDisposable
  {

    private MySqlConnection connection;
    public MySqlCommand Command { get; set; }
    public MySqlDataReader Reader { get; set; }

    public ConexaoMySQL()
    {

      try
      {
        this.connection = new MySqlConnection("Server = localhost; Database = controle_contas_a_pagar_receber; Uid = root; Pwd =;");
        this.connection.Open();
        this.Command = this.connection.CreateCommand();
      }
      catch (Exception ex)
      {

        this.Dispose();

        MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message, "Banco de Dados: Conexão.");

      }

    }

    public void Dispose()
    {

      if (this.connection.State == ConnectionState.Open)
      {

        if (this.Reader != null)
        {
          this.Reader.Dispose();
          this.Reader = null;
        }

        if (this.Command != null)
        {
          this.Command.Dispose();
          this.Command = null;
        }

        this.connection.Dispose();
        this.connection = null;

      }

    }

  }

}
