using Locacao.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.SqlServer.Mapping
{
    public class OrcamentoMap : IEntityTypeConfiguration<Orcamento>
    {
        public void Configure(EntityTypeBuilder<Orcamento> builder)
        {
            builder.ToTable("TBLORCAMENTO");

            builder.HasKey(o => o.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IDORCAMENTO")
                .IsRequired();

            builder.Property(o => o.DataEmissao)
                .IsRequired();

            builder.Property(o => o.DataValidade)
                .IsRequired(false);

            builder.Property(o => o.Status)
                .IsRequired();

            builder.Property(o => o.ValorFrete)
                .IsRequired()
                .HasColumnType("decimal(10, 2)");

            builder.Property(o => o.ValorTotal)
                .IsRequired()
                .HasColumnType("decimal(10, 2)");

            builder.Property(c => c.IdCliente)
                .IsRequired();

            builder.Property(c => c.Ativo)
                .IsRequired();

            builder.HasOne(o => o.Cliente)
                .WithMany()
                .HasForeignKey(o => o.IdCliente);
        }
    }
}
