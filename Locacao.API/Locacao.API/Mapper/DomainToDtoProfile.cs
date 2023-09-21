using AutoMapper;
using Locacao.Domain.Entity;
using Locacao.Queries.Equipamentos.Dto;

namespace Locacao.API.Mapper
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<Equipamento, EquipamentoDto>();
        }
    }
}
