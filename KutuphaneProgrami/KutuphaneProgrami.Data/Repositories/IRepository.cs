using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KutuphaneProgrami.Data.Repositories
{
    public interface IRepository<A> where A : class
    {
        List<A> GetAll();
        List<A> GetAll(Expression<Func<A, bool>> predicate);

        A GetById(int id);

        A Get(Expression<Func<A, bool>> predicate);

        A Add(A entity);
        A Update(A entity);
        A Delete(A entity);
        void Delete(int id);

    }
}
