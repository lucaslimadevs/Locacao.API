using Locacao.Commands.Authorization.Command;
using Locacao.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Locacao.Commands.Authorization.Handler
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
    {
        private readonly SignInManager<Usuario> _signInManager;        

        public LoginUserCommandHandler(
            SignInManager<Usuario> signInManager)
        {
            _signInManager = signInManager;            
        }

        public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, true);

                if (result.Succeeded)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Erro ao efetuar login", ex);
            }

        }
    }
}
