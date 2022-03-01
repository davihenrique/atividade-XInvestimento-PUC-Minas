namespace XInvestimento.Models
{
    public class PlanoVip
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public virtual ICollection<ClientesPlano> ClientesPlano { get; set; }
    }
}
