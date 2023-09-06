namespace Locacao.Domain.Entity
{
    public class EntradaEquipamento : Entity
    {
        public DateTime DataDevolucao { get; set; }
        public string? Observacao { get; set; }
        public Guid IdSaidaEquipamento { get; set; }

        public virtual SaidaEquipamento? SaidaEquipamento { get; set; }
    }
}
