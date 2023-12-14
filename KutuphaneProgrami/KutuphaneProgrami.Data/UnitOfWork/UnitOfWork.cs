using KutuphaneProgrami.Data.Repositories;
using System;

namespace KutuphaneProgrami.Data.UnitOfWork
{
    public class UnitOfWork : IUnitofWork
    {
        protected readonly DataContext _dataContext;

        public UnitOfWork() 
        {
            _dataContext = new DataContext();
        }

        public IRepository<A> GetRepository<A>() where A : class
        {
            return new Repository<A>(_dataContext);
        }

        public int SavaChanges()
        {
            try
            {
                return _dataContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool disposed = false; 
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
                {
                    _dataContext.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
