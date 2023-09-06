using Locacao.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.SqlServer.Mapping
{
    public class ItemOrcamentoMap : IEntityTypeConfiguration<ItemOrcamento>
    {
        public void Configure(EntityTypeBuilder<ItemOrcamento> builder)
        {
            builder.ToTable("TBLITEMORCAMENTO");
            
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IDORCAMENTO")
                .IsRequired();

            builder.Property(e => e.Quantidade)
                .IsRequired();

            builder.Property(c => c.IdOrcamento)
                .IsRequired();

            builder.Property(c => c.IdEquipamento)
                .IsRequired();

            builder.Property(c => c.Ativo)
                .IsRequired();

            builder.HasOne(e => e.Orcamento)
                .WithMany()
                .HasForeignKey(e => e.IdOrcamento);

            builder.HasOne(e => e.Equipamento)
                .WithMany()
                .HasForeignKey(e => e.IdEquipamento);
        }
    }
}
