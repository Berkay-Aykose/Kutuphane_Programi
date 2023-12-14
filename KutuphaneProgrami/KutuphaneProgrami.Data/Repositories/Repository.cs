using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace KutuphaneProgrami.Data.Repositories
{
    public class Repository<A> : IRepository<A> where A : class
    {
        protected readonly DataContext _dataContext;

        private readonly DbSet<A> _dbSet;

        public Repository(DataContext dataContext) 

        {
           _dataContext = dataContext;
            _dbSet = _dataContext.Set<A>();
        }
        
        public A Add(A entity)
        {
            return _dbSet.Add(entity);
        }

        public A Delete(A entity)
        {
           return _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);

            if (entity == null)
            {
                return;
            }

            Delete(entity);

        }

        public A Get(Expression<Func<A, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }

        public List<A> GetAll()
        {
            return _dbSet.ToList();
        }

        public List<A> GetAll(Expression<Func<A, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public A GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public A Update(A entity)
        {
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
