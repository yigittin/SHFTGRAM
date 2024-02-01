namespace SHFTGRAMAPP.Models.User
{
    public class UserCommentDto
    {
        public Guid? Id { get; set; }
        public string Comment { get; set; }
        public Guid UserId { get; set; }
        public Guid CommenterId { get; set; }
        public int Point { get; set; }
    }
}
