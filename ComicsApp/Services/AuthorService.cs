using ComicsApp.Models;
using ComicsApp.Repositories.Interfaces;
using ComicsApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ComicsApp.Services
{
    public class AuthorService : IAuthorService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AuthorService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }


        public IQueryable<Author> GetAllQueryable()
        {
            return _repositoryWrapper.AuthorRepository.FindAll();
        }

        public IQueryable<Author> GetByCondition(Expression<Func<Author, bool>> expression)
        {
            return _repositoryWrapper.AuthorRepository.FindByCondition(expression);
        }


       

        public void AddAuthor(Author author)
        {
            _repositoryWrapper.AuthorRepository.Create(author);
        }

      
        public void UpdateAuthor(Author author)
        {
            _repositoryWrapper.AuthorRepository.Update(author);
        }

        public void DeleteAuthor(Author author)
        {
            _repositoryWrapper.AuthorRepository.Delete(author);
        }

        public void Save()
        {
            _repositoryWrapper.Save();
        }

        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _repositoryWrapper.AuthorRepository.SaveAsync();
        }


    }
}
