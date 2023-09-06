
using Locacao.Domain.Repositories;
using Locacao.Infra.SqlServer.Data;
using Microsoft.EntityFrameworkCore.Storage;


namespace Locacao.Infra.SqlServer.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LocacaoDbContext _context;

        public UnitOfWork(LocacaoDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
