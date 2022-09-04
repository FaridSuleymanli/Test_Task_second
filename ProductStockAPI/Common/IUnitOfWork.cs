using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace ProductStockAPI.Common
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