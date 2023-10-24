using AutoMapper;
using Locacao.Commands.Equipamentos.Command;
using Locacao.Domain.Entity;
using Locacao.Queries.Equipamentos.Dto;

namespace Locacao.API.Mapper
{
    public class CommandToDomainProfile : Profile
    {
        public CommandToDomainProfile()
        {
            CreateMap<InserirEquipamentoCommand, Equipamento> ();
        }
    }
}
