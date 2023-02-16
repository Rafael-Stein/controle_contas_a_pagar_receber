using controle_contas_a_pagar_receber.Controller;
using controle_contas_a_pagar_receber.Model;
using System.Windows.Forms;

namespace controle_contas_a_pagar_receber.view
{

  public partial class ClienteUI : Form
  {
    private ClienteController controller;

    public ClienteUI()
    {
      this.InitializeComponent();

      this.preencherDataGrid();

    }

    private void preencherDataGrid()
    {
      using (ClienteController controller = new ClienteController())
      {
        this.dataGridViewClientes.DataSource = controller.obterTodos();

        this.estiloDataGrid();
      }
    }

    private void estiloDataGrid()
    {

      if (this.dataGridViewClientes.Rows.Count > 0)
      {
        this.dataGridViewClientes.Columns["id"].HeaderText = "id";
        this.dataGridViewClientes.Columns["id"].Visible = false;
        this.dataGridViewClientes.Columns["razaoSocial_nome"].HeaderText = "Razão Social / Nome";
        this.dataGridViewClientes.Columns["razaoSocial_nome"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewClientes.Columns["razaoSocial_nome"].Width = 250;
        this.dataGridViewClientes.Columns["cnpj_cpf"].HeaderText = "CNPJ / CPF";
        this.dataGridViewClientes.Columns["cnpj_cpf"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        this.dataGridViewClientes.Columns["cnpj_cpf"].CellTemplate.Style.Format = "";
        this.dataGridViewClientes.Columns["cnpj_cpf"].Width = 125;
        this.dataGridViewClientes.Columns["logradouro"].HeaderText = "logradouro";
        this.dataGridViewClientes.Columns["logradouro"].Visible = false;
        this.dataGridViewClientes.Columns["numero"].HeaderText = "numero";
        this.dataGridViewClientes.Columns["numero"].Visible = false;
        this.dataGridViewClientes.Columns["cidade"].HeaderText = "cidade";
        this.dataGridViewClientes.Columns["cidade"].Visible = false;
        this.dataGridViewClientes.Columns["cep"].HeaderText = "cep";
        this.dataGridViewClientes.Columns["cep"].Visible = false;
        this.dataGridViewClientes.Columns["uf"].HeaderText = "uf";
        this.dataGridViewClientes.Columns["uf"].Visible = false;
        this.dataGridViewClientes.Columns["contatoNome"].HeaderText = "Nome do Contato";
        this.dataGridViewClientes.Columns["contatoNome"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewClientes.Columns["contatoNome"].Width = 150;
        this.dataGridViewClientes.Columns["contatoEmail"].HeaderText = "contatoEmail";
        this.dataGridViewClientes.Columns["contatoEmail"].Visible = false;
        this.dataGridViewClientes.Columns["contatoTelefone"].HeaderText = "Telefone";
        this.dataGridViewClientes.Columns["contatoTelefone"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        this.dataGridViewClientes.Columns["contatoTelefone"].Width = 150;

        this.dataGridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      }

    }

    private void buttonNovo_Click(object sender, System.EventArgs e)
    {
      this.groupBoxDadosCliente.Enabled = true;

      this.buttonNovo.Enabled = true;
      this.buttonEditar.Enabled = false;
      this.buttonSalvar.Enabled = true;
      this.buttonExcluir.Enabled = false;

      this.limparCampos();

      this.textBoxRazaoSocial_nome.Focus();
    }

    private void buttonEditar_Click(object sender, System.EventArgs e)
    {
      this.groupBoxDadosCliente.Enabled = true;

      this.buttonNovo.Enabled = true;
      this.buttonEditar.Enabled = false;
      this.buttonSalvar.Enabled = true;
      this.buttonExcluir.Enabled = true;

      this.textBoxRazaoSocial_nome.Focus();
    }

    private void buttonSalvar_Click(object sender, System.EventArgs e)
    {

      this.groupBoxDadosCliente.Enabled = false;

      this.buttonNovo.Enabled = true;
      this.buttonEditar.Enabled = false;
      this.buttonSalvar.Enabled = false;
      this.buttonExcluir.Enabled = true;

      using (ClienteController controller = new ClienteController())
      {
        Cliente entity = new Cliente();
        entity.ID = int.Parse(this.textBoxID.Text);
        entity.RazaoSocial_Nome = this.textBoxRazaoSocial_nome.Text;
        entity.CNPJ_CPF = this.textBoxCNPJ_CPF.Text;
        entity.Logradouro = this.textBoxLogradouro.Text;
        entity.Numero = this.textBoxNumero.Text;
        entity.Cidade = this.textBoxCidade.Text;
        entity.CEP = this.textBoxCEP.Text;
        entity.UF = this.textBoxUF.Text;
        entity.ContatoNome = this.textBoxContatoNome.Text;
        entity.ContatoEmail = this.textBoxContatoEmail.Text;
        entity.ContatoTelefone = this.textBoxContatoTelefone.Text;

        if (entity.ID == 0)
        {
          entity.ID = controller.create(entity);

          this.textBoxID.Text = entity.ID.ToString();
        }
        else
        {
          controller.update(entity);
        }

      }

      this.preencherDataGrid();

    }

    private void buttonExcluir_Click(object sender, System.EventArgs e)
    {

      this.groupBoxDadosCliente.Enabled = false;

      this.buttonNovo.Enabled = true;
      this.buttonEditar.Enabled = false;
      this.buttonSalvar.Enabled = false;
      this.buttonExcluir.Enabled = false;

      using (ClienteController controller = new ClienteController())
      {
        int id = int.Parse(this.textBoxID.Text);

        if (id > 0)
        {
          controller.delete(id);
        }

      }

      this.limparCampos();

      this.preencherDataGrid();
    }

    private void buttonCancelar_Click(object sender, System.EventArgs e)
    {
      this.groupBoxDadosCliente.Enabled = false;

      this.buttonNovo.Enabled = true;
      this.buttonEditar.Enabled = false;
      this.buttonSalvar.Enabled = false;
      this.buttonExcluir.Enabled = false;

      this.limparCampos();
    }

    private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
    {

      if (this.dataGridViewClientes.CurrentRow.Index < this.dataGridViewClientes.Rows.Count - 1)
      {

        this.groupBoxDadosCliente.Enabled = false;

        this.buttonNovo.Enabled = true;
        this.buttonEditar.Enabled = true;
        this.buttonSalvar.Enabled = false;
        this.buttonExcluir.Enabled = true;

        using (ClienteController controller = new ClienteController())
        {
          Cliente entity = new Cliente();
          entity.ID = int.Parse(this.dataGridViewClientes.CurrentRow.Cells[0].Value.ToString());

          entity = controller.read(entity.ID);

          this.textBoxID.Text = entity.ID.ToString();
          this.textBoxRazaoSocial_nome.Text = entity.RazaoSocial_Nome;
          this.textBoxCNPJ_CPF.Text = entity.CNPJ_CPF;
          this.textBoxLogradouro.Text = entity.Logradouro;
          this.textBoxNumero.Text = entity.Numero;
          this.textBoxCidade.Text = entity.Cidade;
          this.textBoxCEP.Text = entity.CEP;
          this.textBoxUF.Text = entity.UF;
          this.textBoxContatoNome.Text = entity.ContatoNome;
          this.textBoxContatoEmail.Text = entity.ContatoEmail;
          this.textBoxContatoTelefone.Text = entity.ContatoTelefone;
        }

      }

    }

    private void limparCampos()
    {
      this.textBoxID.Text = "0";
      this.textBoxRazaoSocial_nome.Text = string.Empty;
      this.textBoxCNPJ_CPF.Text = string.Empty;
      this.textBoxLogradouro.Text = string.Empty;
      this.textBoxNumero.Text = string.Empty;
      this.textBoxCidade.Text = string.Empty;
      this.textBoxCEP.Text = string.Empty;
      this.textBoxUF.Text = string.Empty;
      this.textBoxContatoNome.Text = string.Empty;
      this.textBoxContatoEmail.Text = string.Empty;
      this.textBoxContatoTelefone.Text = string.Empty;
    }

  }

}
