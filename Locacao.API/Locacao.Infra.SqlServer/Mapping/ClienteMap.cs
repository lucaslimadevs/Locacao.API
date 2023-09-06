using Locacao.Domain.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.SqlServer.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TBLCLIENTE");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("IDCLIENTE")
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Rg)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Ativo)
                .IsRequired();
        }
    }
}
