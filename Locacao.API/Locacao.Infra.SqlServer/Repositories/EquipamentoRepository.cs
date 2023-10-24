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

        public async Task<Equipamento?> BuscarPorIdAsync(Guid id)
        {
            return await DbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Equipamento>> BuscarTodosAsync()
        {
            return await DbSet.ToListAsync();
        }
    }
}
