using ComicsApp.Models;
using ComicsApp.Repositories.Interfaces;
using ComicsApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ComicsApp.Services
{
    public class PublisherService : IPublisherService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public PublisherService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }



        public IQueryable<Publisher> GetAllQueryable()
        {
            return _repositoryWrapper.PublisherRepository.FindAll();
        }

        public IQueryable<Publisher> GetByCondition(Expression<Func<Publisher, bool>> expression)
        {
            return _repositoryWrapper.PublisherRepository.FindByCondition(expression);
        }

        public void AddPublisher(Publisher publisher)
        {
            _repositoryWrapper.PublisherRepository.Create(publisher);
        }


        public void UpdatePublisher(Publisher publisher)
        {
            _repositoryWrapper.PublisherRepository.Update(publisher);
        }

        public void DeletePublisher(Publisher publisher)
        {
            _repositoryWrapper.PublisherRepository.Delete(publisher);
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
