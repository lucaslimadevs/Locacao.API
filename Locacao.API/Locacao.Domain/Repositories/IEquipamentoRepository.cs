using Locacao.Domain.Entity;

namespace Locacao.Domain.Repositories
{
    public interface IEquipamentoRepository : IBaseRepository<Equipamento>
    {
        Task<IEnumerable<Equipamento>> BuscarTodosAsync();
        Task<Equipamento?> BuscarPorIdAsync(Guid id);
    }
}
