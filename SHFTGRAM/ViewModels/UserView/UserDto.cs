using SHFTGRAM.ViewModels.PostView;

namespace SHFTGRAMAPP.ViewModels.User
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int? FollowerCount { get; set; }
        public int? FollowingCount { get; set; }
        public List<PostDto>? Posts{ get; set; }
    }
}
