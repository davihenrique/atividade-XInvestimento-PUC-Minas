namespace XInvestimento.Models
{
    public class ClientesPlano
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdPlanoVip { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual PlanoVip PlanoVip { get; set; }
    }
}
