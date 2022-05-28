using ComicsApp.Models;
using ComicsApp.Repositories.Interfaces;
using ComicsApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ComicsApp.Services
{
    public class ComicService : IComicService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public ComicService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IQueryable<Comic> GetComicsByName(string comicName)
        {
            var comics = GetAllQueryable();




            if (!String.IsNullOrEmpty(comicName))
            {
                comics = _repositoryWrapper.ComicRepository.FindByCondition(s => s.ComicName!.Contains(comicName));
            }
            //else if (locationType == "textual_locations")
            //{
            //    locations = _repositoryWrapper.LocationRepository.FindByCondition(l => l.IsNumber == false).ToList();
            //}

            return comics;
        }


        public IQueryable<Comic> GetComicsById(int id)
        {
            var comics =GetAllQueryable();

            if (id!=0)
            {
                comics = _repositoryWrapper.ComicRepository.FindByCondition(c => c.ComicId==id);
            }
            //else if (locationType == "textual_locations")
            //{
            //    locations = _repositoryWrapper.LocationRepository.FindByCondition(l => l.IsNumber == false).ToList();
            //}

            return comics;
        }



        public IQueryable<Comic> GetAllQueryable()
        {
            return _repositoryWrapper.ComicRepository.FindAll();
        }

        public IQueryable<Comic> GetByCondition(Expression<Func<Comic, bool>> expression)
        {
            return _repositoryWrapper.ComicRepository.FindByCondition(expression);
        }


        public void AddComic(Comic comic)
        {
            _repositoryWrapper.ComicRepository.Create(comic);
        }

        /*
                public void SearchMovie(Movie movie)
                {
                    _repositoryWrapper.MovieRepository.Search(movie);
                }
        */
        public void UpdateComic(Comic comic)
        {
            _repositoryWrapper.ComicRepository.Update(comic);
        }

        public void DeleteComic(Comic comic)
        {
            _repositoryWrapper.ComicRepository.Delete(comic);
        }

        public void Save()
        {
            _repositoryWrapper.Save();
        }

        //public async Task<IActionResult> GetDetails(int? id)
        //{
        //    var comic = await _repositoryWrapper.ComicRepository.GetComicContext.Comics;
        //        .Include(c => c.Author)
        //        .Include(c => c.Publisher)
        //        .FirstOrDefaultAsync(m => m.ComicId == id);
        //}

        public async System.Threading.Tasks.Task SaveAsync()
        {
            await _repositoryWrapper.AuthorRepository.SaveAsync();
        }

        public IQueryable<Author> GetAuthors()
        {
            return _repositoryWrapper.AuthorRepository.FindAll();
        }

        public IQueryable<Publisher> GetPublishers()
        {
            return _repositoryWrapper.PublisherRepository.FindAll();
        }
    }
}
