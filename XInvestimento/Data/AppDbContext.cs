using Microsoft.EntityFrameworkCore;
using XInvestimento.Models;

namespace XInvestimento.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClientesPlano> ClientesPlanos { get; set; }
        public virtual DbSet<DadosFinaceiro> DadosFinaceiros { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<PlanoVip> PlanoVips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes");

                entity.Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("CPF");

                entity.Property(c => c.NomeCompleto)
                .IsRequired()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<ClientesPlano>(entity =>
            {
                entity.ToTable("ClientesPlano");

                entity.HasOne(cp => cp.Cliente)
                 .WithMany(p => p.ClientesPlano)
                 .HasForeignKey(cp => cp.IdCliente)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_Cliente");

                entity.HasOne(cp => cp.PlanoVip)
                 .WithMany(p => p.ClientesPlano)
                 .HasForeignKey(cp => cp.IdPlanoVip)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_PlanoVip");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("EnderecoCliente");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CEP)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CEP");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UF)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("UF");

                entity.HasOne(e => e.Cliente)
                    .WithMany(c => c.Endereco)
                    .HasForeignKey(e => e.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Endereco");
            });

            modelBuilder.Entity<DadosFinaceiro>(entity =>
            {
                entity.ToTable("FinancieroCliente");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.DadosFinaceiro)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FinanceiroCliente_Cliente");
            });

            modelBuilder.Entity<PlanoVip>(entity =>
            {
                entity.ToTable("PlanoVip");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
