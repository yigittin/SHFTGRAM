namespace SHFTGRAM.ViewModels.UserView
{
    public class FollowDto
    {
        public int Id { get; set; }
        public Guid FollowerId { get; set; }
        public string FollowerUserName { get; set; }
        public Guid FollowingId { get; set; }
        public string FollowingUserName { get; set; }
    }
}
