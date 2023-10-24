using Locacao.Commands.Equipamentos.Command;
using Locacao.Domain.Repositories;
using MediatR;

namespace Locacao.Commands.Equipamentos.Handler
{
    public class DeletarEquipamentoCommandHandler : IRequestHandler<DeletarEquipamentoCommand, bool>
    {
        public readonly IEquipamentoRepository _equipamentoRepository;
        public readonly IUnitOfWork _unitOfWork;        

        public DeletarEquipamentoCommandHandler(IEquipamentoRepository equipamentoRepository, IUnitOfWork unitOfWork)
        {
            _equipamentoRepository = equipamentoRepository;
            _unitOfWork = unitOfWork;            
        }

        public async Task<bool> Handle(DeletarEquipamentoCommand request, CancellationToken cancellationToken)
        {
            var equipamento = await _equipamentoRepository.BuscarPorIdAsync(request.Id);

            if (equipamento == null) return false;

            equipamento.DeletarEquipamento();

            _equipamentoRepository.Update(equipamento);

            return await _unitOfWork.CommitAsync();
        }
    }
}
