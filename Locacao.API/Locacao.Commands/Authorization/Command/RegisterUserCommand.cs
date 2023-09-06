using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Locacao.Commands.Authorization.Command
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }        
    }
}
