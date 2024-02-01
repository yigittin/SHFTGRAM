using System.Text.Json.Serialization;

namespace SHFTGRAMAPP.ViewModels.User
{
    public class RegisterUserDto
    {
        [JsonPropertyName("username")]
        public string UserName{ get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("email")]
        public string Email{ get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("surname")]
        public string Surname { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
