using Microsoft.EntityFrameworkCore.Storage;

namespace Locacao.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        void Dispose();
        IDbContextTransaction BeginTransaction();
    }
}
