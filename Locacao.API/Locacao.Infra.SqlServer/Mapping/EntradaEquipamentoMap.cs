using Locacao.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.SqlServer.Mapping
{
    public class EntradaEquipamentoMap : IEntityTypeConfiguration<EntradaEquipamento>
    {
        public void Configure(EntityTypeBuilder<EntradaEquipamento> builder)
        {
            builder.ToTable("TBLENTRADAEQUIPAMENTO");
            
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IDENTRADAEQUIPAMENTO")
                .IsRequired();

            builder.Property(e => e.DataDevolucao)
                .IsRequired();

            builder.Property(e => e.Observacao)
                .HasMaxLength(255)
                .IsRequired(false);

            builder.Property(c => c.IdSaidaEquipamento)
                .IsRequired();

            builder.Property(c => c.Ativo)
                .IsRequired();

            builder.HasOne(e => e.SaidaEquipamento)
                .WithMany()
                .HasForeignKey(e => e.IdSaidaEquipamento);
        }
    }    
}
