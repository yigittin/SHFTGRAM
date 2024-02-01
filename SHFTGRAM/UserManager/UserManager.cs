using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Service.Login;
using Domain.User;
using SHFTGRAMAPP.Core.Exceptions;

namespace SHFTGRAM.UserManager
{
    public class UserManager
    {
        private HttpContext httpContext { get; set; }
        private readonly IConfiguration _configs ;
        private readonly ILoginService _loginService;
        public UserManager(HttpContext httpContext, IConfiguration configs, ILoginService loginService)
        {
            this.httpContext = httpContext;
            _configs = configs;
            _loginService = loginService;
        }
       
        public async Task<UserToken> Authorize(string email, string password)
        {
      
            var response = await _loginService.Login(email,password);
            if (response is not null)
            {
                ClaimsIdentity identity = new ClaimsIdentity(GetUserClaims(response), CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                try
                {
                    await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return response;
            }
            else
            {
                throw new CustomException("Giriş yapılamadı");
            }
            
        }

        public async void SignOut()
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        private IEnumerable<Claim> GetUserClaims(UserToken logIn)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("AccessToken", logIn.AccessToken),
                new Claim("Username", logIn.UserData.UserName),
                new Claim("UserId",logIn.UserData.UserId.ToString())
            };
            return claims;
        }
        public string GetUserId()
        {
            if (httpContext.User is not null)
            {
                return httpContext.User.Claims.First(c => c.Type == "UserId").Value;
            }
            else
            {
                throw new CustomException("User not found");
            }
        }

        public string GetUserAccessToken()
        {
            if(httpContext.User is not null)
            {
               return httpContext.User.Claims.First(c => c.Type == "AccessToken").Value;
            }
            else
            {
                throw new CustomException("User not found");
            }
        }
        public async Task<string> GetUserName()
        {
            if (httpContext.User is not null)
            {
                return httpContext.User.Claims.First(c => c.Type == "Username").Value;
            }
            else
            {
                throw new CustomException("User not found");
            }
        }

    }

}
