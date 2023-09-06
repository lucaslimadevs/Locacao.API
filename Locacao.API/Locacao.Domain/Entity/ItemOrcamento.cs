namespace Locacao.Domain.Entity
{
    public class ItemOrcamento : Entity
    {
        public int Quantidade { get; set; }
        public Guid IdOrcamento { get; set; }
        public Guid IdEquipamento { get; set; }

        public virtual Orcamento? Orcamento { get; set; }
        public virtual Equipamento? Equipamento { get; set; }
    }
}
