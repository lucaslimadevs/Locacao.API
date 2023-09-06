namespace Locacao.Domain.Entity
{
    public class Equipamento : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal PrecoDiario { get; set; }
        public decimal PrecoSemanal { get; set; }
        public decimal PrecoMensal { get; set; }
    }
}
