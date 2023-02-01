using System;

namespace controle_contas_a_pagar_receber.Model
{
    
    public class Receita
    {

        public int ID { get; set; }
        public int ClienteID { get; set; }
        public string NotaFiscalNumero { get; set; }
        public float Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public string Situacao { get; set; }

    }

}
