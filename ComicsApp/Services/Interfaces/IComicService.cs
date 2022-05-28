using ComicsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ComicsApp.Services.Interfaces
{
    public interface IComicService
    {
        IQueryable<Comic> GetComicsByName(string comicName);


        IQueryable<Comic> GetAllQueryable();
        IQueryable<Comic> GetByCondition(Expression<Func<Comic, bool>> expression);

        IQueryable<Comic> GetComicsById(int id);
        void AddComic(Comic comic);
        //void Search(Movie movie);
        void UpdateComic(Comic comic);
        void DeleteComic(Comic comic);
        void Save();

        System.Threading.Tasks.Task SaveAsync();

        IQueryable<Author> GetAuthors();

        IQueryable<Publisher> GetPublishers();


        //  public Task<IActionResult> GetDetails(int? id);
    }
}
