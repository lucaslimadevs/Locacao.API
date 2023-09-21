namespace Locacao.Queries.Equipamentos.Dto
{
    public record EquipamentoDto
    {
        public Guid Id { get; init; }
        public string Nome { get; init; } = string.Empty;
        public string? Descricao { get; init; }
        public decimal PrecoDiario { get; init; }
        public decimal PrecoSemanal { get; init; }
        public decimal PrecoMensal { get; init; }        
    };
}
