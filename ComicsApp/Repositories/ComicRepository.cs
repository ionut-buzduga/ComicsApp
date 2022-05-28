using ComicsApp.Models;
using ComicsApp.Repositories.Interfaces;

namespace ComicsApp.Repositories
{
    public class ComicRepository : RepositoryBase<Comic>, IComicRepository
    {
        public ComicRepository(ComicsContext comicsContext)
            : base(comicsContext)
        {
        }
    }
}