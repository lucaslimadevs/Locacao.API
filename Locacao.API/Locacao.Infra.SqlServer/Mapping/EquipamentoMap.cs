using Locacao.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.SqlServer.Mapping
{
    public class EquipamentoMap : IEntityTypeConfiguration<Equipamento>
    {
        public void Configure(EntityTypeBuilder<Equipamento> builder)
        {
            builder.ToTable("TBLEQUIPAMENTO");

            builder.HasKey(e => e.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IDEQUIPAMENTO")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Descricao)
                   .HasMaxLength(100)
                   .IsRequired(false);

            builder.Property(e => e.PrecoDiario)
                   .HasColumnType("decimal(10, 2)")
                   .IsRequired();

            builder.Property(e => e.PrecoSemanal)
                   .HasColumnType("decimal(10, 2)")
                   .IsRequired();

            builder.Property(e => e.PrecoMensal)
                   .HasColumnType("decimal(10, 2)")
                   .IsRequired();

            builder.Property(c => c.Ativo)
                .IsRequired();            
        }
    }
}
