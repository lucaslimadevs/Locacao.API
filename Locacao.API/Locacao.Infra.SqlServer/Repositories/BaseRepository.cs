using Locacao.Domain.Repositories;
using Locacao.Infra.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

namespace Locacao.Infra.SqlServer.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;
        public readonly LocacaoDbContext _context;

        public BaseRepository(LocacaoDbContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);            
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entity)
        {
            await DbSet.AddRangeAsync(entity);
        }

        public void Update(TEntity entity)
        {            
            DbSet.Update(entity);
        }
    }
}
