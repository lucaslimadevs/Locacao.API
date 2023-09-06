
using Locacao.Domain.Enum;

namespace Locacao.Domain.Entity
{
    public class Orcamento : Entity
    {
        public DateTime DataEmissao { get; set; }
        public DateTime? DataValidade { get; set; }
        public EnumStatus Status { get; set; }
        public decimal ValorFrete { get; set; }
        public decimal ValorTotal { get; set; }
        public Guid IdCliente { get; set; }

        public virtual Cliente? Cliente { get; set; }
    }
}
