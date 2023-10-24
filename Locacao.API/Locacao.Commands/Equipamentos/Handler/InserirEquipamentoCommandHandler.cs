using Locacao.Commands.Equipamentos.Command;
using Locacao.Domain.Repositories;
using MediatR;
using Locacao.Domain.Entity;
using AutoMapper;

namespace Locacao.Commands.Equipamentos.Handler
{
    public class InserirEquipamentoCommandHandler : IRequestHandler<InserirEquipamentoCommand, bool>
    {
        public readonly IEquipamentoRepository _equipamentoRepository;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public InserirEquipamentoCommandHandler(IEquipamentoRepository equipamentoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _equipamentoRepository = equipamentoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(InserirEquipamentoCommand request, CancellationToken cancellationToken)
        {
            var equipamento = _mapper.Map<Equipamento>(request);

            await _equipamentoRepository.AddAsync(equipamento);

            return await _unitOfWork.CommitAsync();
        }
    }
}
