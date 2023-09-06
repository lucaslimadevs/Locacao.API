using Locacao.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.SqlServer.Mapping
{
    public class EstoqueMap : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("TBLESTOQUE");
            
            builder.HasKey(e => e.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IDESTOQUE")
                .IsRequired();

            builder.Property(e => e.QuantidadeDisponivel)
                .IsRequired();

            builder.Property(e => e.IdEquipamento)
                .IsRequired();

            builder.Property(c => c.Ativo)
                .IsRequired();

            builder.HasOne(e => e.Equipamento)
                .WithMany()
                .HasForeignKey(e => e.IdEquipamento);
        }
    }
}
