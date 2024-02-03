using AutoMapper;
using Domain.User;
using Microsoft.AspNetCore.Mvc;
using Service.Login;
using SHFTGRAM.ViewModels;
using SHFTGRAMAPP.Core.Exceptions;
using SHFTGRAMAPP.ViewModels.User;

namespace SHFTGRAM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private IConfiguration _configs;
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;
        public LoginController(IConfiguration configuration, ILoginService loginService, IMapper mapper)
        {
            _configs = configuration;
            _loginService = loginService;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<BaseResult<UserToken>>> Login([FromBody] UserLoginDto userLogin)
        {
            try
            {
                var userData = await _loginService.Login(userLogin.UserName, userLogin.Password);
                if (userData is null)
                {
                    return NotFound(new ResponseResult("User not found",false));
                }
                return Ok(new BaseResult<UserToken>("Login Success", userData));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseResult(ex.Message,false));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult(ex.Message, false));
            }
        }
        [HttpPost("Register")]
        public async Task<ActionResult<BaseResult<UserTokenDto>>> Register(RegisterUserDto user)
        {
            try
            {
                var reg = _mapper.Map<RegisterUser>(user);
                var rez = await _loginService.UserRegister(reg);
                var userDataDto = _mapper.Map<UserDto>(rez.UserData);
                var userToken = new UserTokenDto()
                {
                    AccessToken = rez.AccessToken,
                    Role = rez.Role,
                    UserData = userDataDto
                };
                return Ok(new BaseResult<UserTokenDto>("Register Success", userToken));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseResult(ex.Message, false));
            }
            catch (Exception ex)
            {
                return NotFound(new ResponseResult(ex.Message, false));
            }
        }
        [HttpPost("Confirmation")]
        public async Task<ActionResult> Confirmation(string id)
        {
            try
            {
                var user = await _loginService.UserConfirmation(Guid.Parse(id));
                return Ok(new BaseResult<UserData>("Onaylandı", user));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ResponseResult(ex.Message, false));
            }
            catch (Exception ex)
            {
                return NotFound(new ResponseResult(ex.Message, false));
            }
        }
    }
}
