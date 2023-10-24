using AutoMapper;
using Locacao.Domain.Repositories;
using Locacao.Queries.Equipamentos.Dto;
using Locacao.Queries.Equipamentos.Query;
using MediatR;

namespace Locacao.Queries.Equipamentos.Handler
{
    public class BuscarEquipamentoQueryHandler : IRequestHandler<BuscarEquipamentoQuery, IEnumerable<EquipamentoDto>>
    {
        public readonly IEquipamentoRepository _equipamentoRepository;
        public readonly IMapper _mapper;

        public BuscarEquipamentoQueryHandler(IEquipamentoRepository equipamentoRepository, IMapper mapper)
        {
            _equipamentoRepository = equipamentoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EquipamentoDto>> Handle(BuscarEquipamentoQuery request, CancellationToken cancellationToken)
        {
            var resultDb = await _equipamentoRepository.BuscarTodosAsync();

            var result = _mapper.Map<List<EquipamentoDto>>(resultDb);

            return result;
        }
    }
}
