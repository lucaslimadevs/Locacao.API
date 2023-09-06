using Locacao.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.SqlServer.Mapping
{
    public class SaidaEquipamentoMap : IEntityTypeConfiguration<SaidaEquipamento>
    {
        public void Configure(EntityTypeBuilder<SaidaEquipamento> builder)
        {
            builder.ToTable("TBLSAIDAEQUIPAMENTO");

            builder.HasKey(se => se.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IDSAIDAEQUIPAMENTO")
                .IsRequired();

            builder.Property(se => se.DataSaida)
                .IsRequired();

            builder.Property(se => se.DataDevolucao)
                .IsRequired();

            builder.Property(c => c.IdEquipamento)
                .IsRequired();

            builder.Property(c => c.IdOrcamento)
                .IsRequired();

            builder.Property(c => c.IdEnderecoSaida)
                .IsRequired();

            builder.Property(c => c.Ativo)
                .IsRequired();

            builder.HasOne(se => se.Equipamento)
                .WithMany()
                .HasForeignKey(se => se.IdEquipamento);

            builder.HasOne(se => se.Orcamento)
                .WithMany()
                .HasForeignKey(se => se.IdOrcamento);

            builder.HasOne(se => se.EnderecoSaida)
                .WithMany()
                .HasForeignKey(se => se.IdEnderecoSaida);
        }
    }
}
