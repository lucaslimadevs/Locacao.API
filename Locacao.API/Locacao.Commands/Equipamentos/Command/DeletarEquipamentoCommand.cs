using MediatR;

namespace Locacao.Commands.Equipamentos.Command
{
    public class DeletarEquipamentoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
