using System;
using System.Threading.Tasks;

namespace EL.EntityFrameworkCore
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
    }
}
