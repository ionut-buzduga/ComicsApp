using ComicsApp.Models;
using ComicsApp.Repositories.Interfaces;

namespace ComicsApp.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ComicsContext _comicsContext;
       
        private IAuthorRepository? _authorRepository;
        private IComicRepository? _comicRepository;
       
        private IPublisherRepository? _publisherRepository;
       

        public IComicRepository ComicRepository
        {
            get
            {
                if (_comicRepository == null)
                {
                    _comicRepository = new ComicRepository(_comicsContext);
                }

                return _comicRepository;
            }
        }

        public IAuthorRepository AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_comicsContext);
                }

                return _authorRepository;
            }
        }

        

        public IPublisherRepository PublisherRepository
        {
            get
            {
                if (_publisherRepository == null)
                {
                    _publisherRepository = new PublisherRepository(_comicsContext);
                }

                return _publisherRepository;
            }
        }

        public RepositoryWrapper(ComicsContext locationContext)
        {
            _comicsContext = locationContext;
        }

       

        public void Save()
        {
            _comicsContext.SaveChanges();
        }
    }
}
