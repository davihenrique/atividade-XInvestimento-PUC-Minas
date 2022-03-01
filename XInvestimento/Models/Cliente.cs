namespace XInvestimento.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNacimento { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual ICollection<ClientesPlano> ClientesPlano { get; set; }
        public virtual ICollection<Endereco> Endereco { get; set; }
        public virtual ICollection<DadosFinaceiro> DadosFinaceiro { get; set; }
    }
}
