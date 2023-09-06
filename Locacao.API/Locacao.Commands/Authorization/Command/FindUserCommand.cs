using Locacao.Commands.Authorization.Dto;
using MediatR;

namespace Locacao.Commands.Authorization.Command
{
    public class FindUserCommand : IRequest<IEnumerable<UsuarioDto>>
    {
    }
}
