using MediatR;

namespace Locacao.Commands.Authorization.Command
{
    public class LoginUserCommand : IRequest<bool>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
