namespace SHFTGRAMAPP.ViewModels.User
{
    public class UserTokenDto
    {
        public UserDto UserData { get; set; }
        public string Role { get; set; }
        public string AccessToken { get; set; }
    }
}
