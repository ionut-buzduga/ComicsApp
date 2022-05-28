using ComicsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ComicsApp.Services.Interfaces
{
    public interface IAuthorService
    {

        IQueryable<Author> GetAllQueryable();
        IQueryable<Author> GetByCondition(Expression<Func<Author, bool>> expression);

       
        void AddAuthor(Author author);
       
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
        void Save();

        System.Threading.Tasks.Task SaveAsync();

    }
}
