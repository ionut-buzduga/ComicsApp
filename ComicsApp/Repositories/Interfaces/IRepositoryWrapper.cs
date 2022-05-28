using ComicsApp.Models;

namespace ComicsApp.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        

        IComicRepository ComicRepository { get; }
        IAuthorRepository AuthorRepository { get; }

        IPublisherRepository PublisherRepository { get; }
        void Save();
    }
}
