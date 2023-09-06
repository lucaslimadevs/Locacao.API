namespace Locacao.Domain.Entity
{
    public class SaidaEquipamento : Entity
    {
        public DateTime DataSaida { get; set; }
        public DateTime DataDevolucao { get; set; }
        public Guid IdEquipamento { get; set; }
        public Guid IdOrcamento { get; set; }
        public Guid IdEnderecoSaida { get; set; }

        public virtual Equipamento? Equipamento { get; set; }
        public virtual Orcamento? Orcamento { get; set; }
        public virtual Endereco? EnderecoSaida { get; set; }
    }
}
