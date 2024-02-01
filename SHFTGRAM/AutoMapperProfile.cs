using AutoMapper;
using Domain.User;
using SHFTGRAMAPP.Core.User;
using SHFTGRAMAPP.Models.User;
using SHFTGRAMAPP.ViewModels.User;

namespace SHFTGRAM
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserLogin, UserLoginDto>().ReverseMap();
            CreateMap<UserData, UserDto>().ReverseMap();
            CreateMap<UserToken, UserTokenDto>().ReverseMap();
            CreateMap<RegisterUser, RegisterUserDto>().ReverseMap();
            CreateMap<UserComment, UserCommentDto>().ReverseMap();
        }
    }
}
