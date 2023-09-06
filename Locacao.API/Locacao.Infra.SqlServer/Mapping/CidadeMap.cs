using Locacao.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.SqlServer.Mapping
{
    public class CidadeMap : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("TBLCIDADE");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IDCIDADE")                
                .IsRequired();

            builder.Property(c => c.Nome)                
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(c => c.Cep)                
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.Uf)                
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(c => c.Ativo)                
                .IsRequired();
        }
    }
}
