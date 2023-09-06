using Locacao.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.SqlServer.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("TBLENDERECO");

            builder.HasKey(e => e.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IDENDERECO")
                .IsRequired();

            builder.Property(e => e.Rua)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(e => e.Cep)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.Numero)
                .IsRequired();

            builder.Property(c => c.IdCidade)
                .IsRequired();

            builder.Property(c => c.IdCliente)
                .IsRequired();

            builder.Property(c => c.Ativo)
                .IsRequired();

            builder.HasOne(e => e.Cidade)
                .WithMany()
                .HasForeignKey(e => e.IdCidade);

            builder.HasOne(e => e.Cliente)
                .WithMany()
                .HasForeignKey(e => e.IdCliente);
        }
    }
}
