using Emplonomy.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Emplonomy.Logic.Abstract
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        List<T> LoadAll();
        List<T> FindMany(Expression<Func<T, bool>> predicate);
        int Count();
        T FindSingle(int id);
        T FindSingle(Expression<Func<T, bool>> predicate);
        T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        void Commit();
    }
}
