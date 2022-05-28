namespace ComicsApp.Models
{
    public class RatingComment
    { 
        public int RatingCommentId { get; set; }

        public int RatingCommentsValue { get; set; }

        public int CommentId { get; set; }

        public Comment? Comment { get; set; }


    }
}
