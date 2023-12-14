using KutuphaneProgrami.Data.Repositories;
using System;

namespace KutuphaneProgrami.Data.UnitOfWork
{
    public interface IUnitofWork : IDisposable
    {
        IRepository<A> GetRepository<A>() where A : class;

        int SavaChanges();

    }
}
