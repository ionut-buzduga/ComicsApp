namespace ComicsApp.Models
{
    public class Comic
    {
        public int ComicId { get; set; }

        public string? ComicName { get; set; }

        public string? Genre { get; set; }

        public string? URL { get; set; }

        public string? Description { get; set; }

        public DateTime? ComicCreated { get; set; }

        public int? AuthorID { get; set; }

        public int? PublisherID { get; set; }


        public virtual Author? Author { get; set; }

         public virtual Publisher? Publisher { get; set; }


    }
}
