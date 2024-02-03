using AutoMapper;
using Core.User;
using Domain.User;
using EFCore.DbModels;
using SHFTGRAM.ViewModels.PostView;
using SHFTGRAM.ViewModels.UserView;
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
            CreateMap<UpdateUser, UpdateUserDto>().ReverseMap();
            CreateMap<User, UserPageDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
        }
    }
}
