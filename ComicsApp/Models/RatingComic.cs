namespace ComicsApp.Models
{
    public class RatingComic
    {
        public int RatingComicId { get; set; }

        public int RatingComicsValue { get; set; }

        public int ComicId { get; set; }

        public Comic? Comic { get; set; }

        public int UserID { get; set; }

        


    }
}
