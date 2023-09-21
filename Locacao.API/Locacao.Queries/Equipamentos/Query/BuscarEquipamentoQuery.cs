using Locacao.Queries.Equipamentos.Dto;
using MediatR;

namespace Locacao.Queries.Equipamentos.Query
{
    public class BuscarEquipamentoQuery : IRequest<IEnumerable<EquipamentoDto>>
    {
    }
}
