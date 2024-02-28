using Contracts;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System.Linq.Expressions;

namespace Repository.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        #region properties

        protected RepositoryContext RepositoryContext;

        #endregion

        #region constructor
        public RepositoryBase(RepositoryContext repositoryContext) => RepositoryContext = repositoryContext;
        #endregion

        #region methods

        //"trackChanges" parameter.We are going to use
        //it to improve our read-only query performance.When it’s set to false, we
        //attach the AsNoTracking method to our query to inform EF Core that it
        //doesn’t need to track changes for the required entities.This greatly
        //improves the speed of a query.
        public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ? RepositoryContext.Set<T>().Where(expression).AsNoTracking() : RepositoryContext.Set<T>().Where(expression);
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
        #endregion

    }

}
