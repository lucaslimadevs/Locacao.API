using Locacao.Domain.Entity;
using Locacao.Domain.Repositories;
using Locacao.Infra.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.SqlServer.Repositories
{
    public class EquipamentoRepository : BaseRepository<Equipamento>, IEquipamentoRepository
    {
        public EquipamentoRepository(LocacaoDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Equipamento>> BuscarTodos()
        {
            return await DbSet.ToListAsync();
        }
    }
}
