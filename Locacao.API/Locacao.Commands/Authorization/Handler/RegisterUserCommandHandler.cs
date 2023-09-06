using Locacao.Commands.Authorization.Command;
using Locacao.Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace Locacao.Commands.Authorization.Handler
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public RegisterUserCommandHandler(
            SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var user = new Usuario
                {
                    Nome = request.Nome,
                    UserName = request.Email,
                    Email = request.Email,
                    DataNascimento = request.DataNascimento,                    
                    EmailConfirmed = true,
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);

                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Erro ao criar usuario: ", ex);
            }

        }
    }
}
