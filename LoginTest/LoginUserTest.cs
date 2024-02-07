using AutoMapper;
using Azure;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Login;
using SHFTGRAM.Controllers;
using SHFTGRAMAPP.ViewModels.User;
using System.Net;
using Xunit;

namespace LoginTest
{
    public class LoginUserTest
    {
        private IConfiguration _configs;
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public LoginUserTest()
        {
            _configs = A.Fake<IConfiguration>();
            _loginService = A.Fake<ILoginService>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public async Task LoginController_LoginUserTest()
        {
            //Arrange
            var userDto = A.Fake<UserLoginDto>();
            var controller = new LoginController(_configs, _loginService, _mapper);            
            //Act
            var result=await controller.Login(userDto);
            //Assert
            result.Should().NotBeNull();
            OkObjectResult objectResponse = Assert.IsType<OkObjectResult>(result.Result);            
            Assert.Equal(200,objectResponse.StatusCode);
        }
    }
}