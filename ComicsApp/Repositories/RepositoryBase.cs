using ComicsApp.Models;
using ComicsApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ComicsApp.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ComicsContext ComicsContext { get; set; }

        public RepositoryBase(ComicsContext comicsContext)
        {
            this.ComicsContext = comicsContext;
        }

        
        public IQueryable<T> FindAll()
        {
            return this.ComicsContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ComicsContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.ComicsContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.ComicsContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.ComicsContext.Set<T>().Remove(entity);
        }


        public async Task SaveAsync()
        {
            await this.ComicsContext.SaveChangesAsync();
        }

    }
}
