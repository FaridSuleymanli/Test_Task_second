using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProductStockAPI.Data;

namespace ProductStockAPI.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _activeTransaction;
        private StockDbContext _activeDbContext;
        private bool _disposed;

        public IUnitOfWork WithContext(StockDbContext activeDbContext)
        {
            _activeDbContext = activeDbContext;
            return this;
        }
        
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            _activeTransaction = await _activeDbContext.Database.BeginTransactionAsync();

            if (_activeTransaction.GetDbTransaction().Connection == _activeDbContext.Database.GetDbConnection())
            {
                await _activeDbContext.Database.UseTransactionAsync(_activeTransaction.GetDbTransaction());
            }

            return _activeTransaction;
        }

        public async Task SaveChangesAsync()
        {
            if (!_activeDbContext.ChangeTracker.HasChanges())
            {
                return;
            }

            await _activeDbContext.SaveChangesAsync();
        }

        public async Task CommitChangesAsync()
        {
            await _activeTransaction?.CommitAsync()!;
        }

        public async Task RollBackAsync()
        {
            await _activeTransaction?.RollbackAsync()!;
        }
        
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _activeDbContext.Dispose();
                    _activeTransaction?.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}