namespace ComicsApp.Models
{
    public class Comment
    {
            public int CommentId { get; set; }

        public string? CommentText { get; set; }

        public DateTime CommentDate_created { get; set; }

        public int UserID { get; set; }

       

        public int ComicID { get; set; }

        public Comic? Comic { get; set; }
    }
}
