using Locacao.Commands.Authorization.Command;
using Locacao.Commands.Authorization.Dto;
using Locacao.Domain.Repositories;
using MediatR;

namespace Locacao.Commands.Authorization.Handler
{
    public class FindUserCommandHandler : IRequestHandler<FindUserCommand, IEnumerable<UsuarioDto>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public FindUserCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioDto>> Handle(FindUserCommand request, CancellationToken cancellationToken)
        { 
            var usuarios = await _usuarioRepository.FindAll();            

            var result = usuarios.AsQueryable().Select(p => new UsuarioDto
            {
                Id = p.Id,
                Nome = p.Nome
            });

            return result;
        }
    }
}
