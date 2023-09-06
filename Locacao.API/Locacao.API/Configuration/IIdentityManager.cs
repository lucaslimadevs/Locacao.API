using Locacao.Domain.Identity;

namespace Locacao.API.Configuration
{
    public interface IIdentityManager
    {
        Task<LoginDto> GenerateJwt(string email);
    }
}
