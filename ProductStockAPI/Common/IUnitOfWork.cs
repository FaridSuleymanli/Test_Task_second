using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace ProductStockAPİ.Common
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync();

        Task SaveChangesAsync();

        Task CommitChangesAsync();

        Task RollBackAsync();

        void Dispose();
    }
}