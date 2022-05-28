using ComicsApp.Models;
using ComicsApp.Repositories.Interfaces;

namespace ComicsApp.Repositories
{
    public class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ComicsContext comicsContext)
            : base(comicsContext)
        {
        }
    }
}
