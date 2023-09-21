using Locacao.Domain.Entity;

namespace Locacao.Domain.Repositories
{
    public interface IEquipamentoRepository : IBaseRepository<Equipamento>
    {
        Task<IEnumerable<Equipamento>> BuscarTodos();
    }
}
