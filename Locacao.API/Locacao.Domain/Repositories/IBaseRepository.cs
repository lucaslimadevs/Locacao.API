namespace Locacao.Domain.Repositories
{
    public interface IBaseRepository<in TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entity);
        void Update(TEntity entity);
    }
}
