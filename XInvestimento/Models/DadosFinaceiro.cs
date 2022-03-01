namespace XInvestimento.Models
{
    public class DadosFinaceiro
    {
        public int Id { get; set; }
        public string Conta { get; set; }
        public string Agencia { get; set; }
        public double RendaMensal { get; set; }
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
