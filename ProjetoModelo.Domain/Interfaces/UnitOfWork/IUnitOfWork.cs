using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModelo.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();

        Task CommitAsync();

        void Roolback();
    }
}
