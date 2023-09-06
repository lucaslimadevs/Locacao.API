namespace Locacao.Domain.Entity
{
    public class Estoque : Entity
    {
        public Guid IdEquipamento { get; set; }
        public int QuantidadeDisponivel { get; set; }

        public virtual Equipamento? Equipamento { get; set; }
    }
}
