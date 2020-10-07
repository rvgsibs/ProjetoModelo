using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoModelo.Domain.Interfaces.UnitOfWork;
using ProjetoModelo.Infra.Data.Context;

namespace ProjetoModelo.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly ProjetoModeloContext _projetoModeloContext;

        public UnitOfWork(ProjetoModeloContext projetoModeloContext)
        {
            _projetoModeloContext = projetoModeloContext;
        }
        public void Commit()
        {
            _projetoModeloContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _projetoModeloContext.SaveChangesAsync();
        }

        public void Roolback()
        {
            _projetoModeloContext.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList().ForEach(entry =>
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    default:
                        break;
                }
            });
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected  virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _projetoModeloContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
