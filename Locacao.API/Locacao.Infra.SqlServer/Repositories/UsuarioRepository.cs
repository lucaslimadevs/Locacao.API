using Locacao.Domain.Entity;
using Locacao.Domain.Repositories;
using Locacao.Infra.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.SqlServer.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(LocacaoDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Usuario>> FindAll()
            => await DbSet.ToListAsync();                                
    }
}
