using Locacao.Domain.Entity;
using Locacao.Infra.SqlServer.Mapping;
using Microsoft.EntityFrameworkCore;
using Utils;

namespace Locacao.Infra.SqlServer.Data
{
    public class LocacaoDbContext : DbContext
    {
        public LocacaoDbContext(DbContextOptions<LocacaoDbContext> options) : base(options) { }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<ItemOrcamento> ItemOrcamentos { get; set; }
        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<SaidaEquipamento> SaidaEquipamentos { get; set; }
        public DbSet<EntradaEquipamento> EntradaEquipamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CidadeMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new EquipamentoMap());
            modelBuilder.ApplyConfiguration(new EstoqueMap());
            modelBuilder.ApplyConfiguration(new ItemOrcamentoMap());
            modelBuilder.ApplyConfiguration(new OrcamentoMap());
            modelBuilder.ApplyConfiguration(new SaidaEquipamentoMap());
            modelBuilder.ApplyConfiguration(new EntradaEquipamentoMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Variables.DefaultConnection);
        }
    }
}
