using Locacao.Commands.Equipamentos.Command;
using Locacao.Domain.Repositories;
using MediatR;
using Locacao.Domain.Entity;

namespace Locacao.Commands.Equipamentos.Handler
{
    public class InserirEquipamentoCommandHandler : IRequestHandler<InserirEquipamentoCommand, bool>
    {
        public readonly IEquipamentoRepository _equipamentoRepository;
        public readonly IUnitOfWork _unitOfWork;

        public InserirEquipamentoCommandHandler(IEquipamentoRepository equipamentoRepository, IUnitOfWork unitOfWork)
        {
            _equipamentoRepository = equipamentoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(InserirEquipamentoCommand request, CancellationToken cancellationToken)
        {
            var equipamento = new Equipamento(
                request.Nome,
                request.Descricao,
                request.PrecoDiario,
                request.PrecoSemanal,
                request.PrecoMensal
                );

            await _equipamentoRepository.AddAsync(equipamento);

            return await _unitOfWork.CommitAsync();
        }
    }
}
