using Locacao.Domain.Entity;

namespace Locacao.Domain.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> FindAll();
    }
}
