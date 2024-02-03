using SHFTGRAM.ViewModels.PostView;

namespace SHFTGRAM.ViewModels.UserView
{
    public class UserPageDto
    {
        public string Username { get; set; }
        public string BioText { get; set; }
        public List<PostDto> Posts{ get; set; }
    }
}
