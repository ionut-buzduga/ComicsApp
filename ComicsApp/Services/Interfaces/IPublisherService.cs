using ComicsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ComicsApp.Services.Interfaces
{
    public interface IPublisherService
    {


        IQueryable<Publisher> GetAllQueryable();
        IQueryable<Publisher> GetByCondition(Expression<Func<Publisher, bool>> expression);

        void AddPublisher(Publisher publisher);

        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(Publisher publisher);
        void Save();

        System.Threading.Tasks.Task SaveAsync();
    }
}
