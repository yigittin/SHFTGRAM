using SHFTGRAM.ViewModels.PostView;

namespace SHFTGRAMAPP.ViewModels.User
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int? FollowerCount { get; set; }
        public int? FollowingCount { get; set; }
        public string BioText { get; set; }
        public List<PostDto>? Posts{ get; set; }
        public bool? IsFollowed { get; set; }
    }
}
