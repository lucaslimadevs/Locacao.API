using Microsoft.AspNetCore.Identity;

namespace Locacao.Domain.Entity
{
    public class Usuario : IdentityUser<Guid>
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }        
    }
}
