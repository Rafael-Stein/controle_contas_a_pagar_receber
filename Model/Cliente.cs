namespace controle_contas_a_pagar_receber.Model
{

  public class Cliente
  {

    public int ID { get; set; }
    public string RazaoSocial_Nome { get; set; }
    public string CNPJ_CPF { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Cidade { get; set; }
    public string CEP { get; set; }
    public string UF { get; set; }
    public string ContatoNome { get; set; }
    public string ContatoEmail { get; set; }
    public string ContatoTelefone { get; set; }

  }

}
