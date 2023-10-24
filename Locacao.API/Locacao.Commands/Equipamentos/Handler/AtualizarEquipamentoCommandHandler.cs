using Locacao.Commands.Equipamentos.Command;
using Locacao.Domain.Repositories;
using MediatR;
using Locacao.Domain.Entity;
using AutoMapper;
using Locacao.Infra.SqlServer.Repositories;

namespace Locacao.Commands.Equipamentos.Handler
{
    public class AtualizarEquipamentoCommandHandler : IRequestHandler<AtualizarEquipamentoCommand, bool>
    {
        public readonly IEquipamentoRepository _equipamentoRepository;
        public readonly IUnitOfWork _unitOfWork;        

        public AtualizarEquipamentoCommandHandler(IEquipamentoRepository equipamentoRepository, IUnitOfWork unitOfWork)
        {
            _equipamentoRepository = equipamentoRepository;
            _unitOfWork = unitOfWork;            
        }

        public async Task<bool> Handle(AtualizarEquipamentoCommand request, CancellationToken cancellationToken)
        {
            var equipamento = await _equipamentoRepository.BuscarPorIdAsync(request.Id);

            if (equipamento == null) return false;

            equipamento.AtualizarInformacoes(request.Nome, request.Descricao, request.PrecoDiario, request.PrecoSemanal, request.PrecoMensal);

            _equipamentoRepository.Update(equipamento);

            return await _unitOfWork.CommitAsync();
        }
    }
}
