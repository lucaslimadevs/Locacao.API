using MediatR;

namespace Locacao.Commands.Equipamentos.Command
{
    public class AtualizarEquipamentoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public decimal PrecoDiario { get; set; }
        public decimal PrecoSemanal { get; set; }
        public decimal PrecoMensal { get; set; }
    }
}
