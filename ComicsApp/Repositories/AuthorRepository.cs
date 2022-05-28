using ComicsApp.Models;
using ComicsApp.Repositories.Interfaces;

namespace ComicsApp.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(ComicsContext comicsContext)
            : base(comicsContext)
        {
        }
    }
}
