namespace controle_contas_a_pagar_receber.Model
{
    
    public class Cliente
    {

        public int ID { get; set; }
        public int EnderecoID { get; set; }
        public string RazaoSocial_Nome { get; set; }
        public string CNPJ_CPF { get; set; }
        public string ContatoNome { get; set; }
        public string ContatoEmail { get; set; }
        public string ContatoTelefone { get; set; }

    }

}
