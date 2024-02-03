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
using System.IdentityModel.Tokens.Jwt;

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
                throw new CustomException("Login failed");
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
        public Guid GetUserId()
        {
            var token = GetUserAccessToken();
            if (!string.IsNullOrEmpty(token))
            {
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                return Guid.Parse(jwt.Claims.First(c => c.Type == ClaimTypes.Name).Value);
            }
            else
            {
                throw new CustomException("User not found");
            }
        }

        public string GetUserAccessToken()
        {
            if (httpContext.Request.Headers.TryGetValue("Authorization", out var headerAuth))
            {
                var jwtToken = headerAuth.First().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                return jwtToken;
            }
            return string.Empty;
        }
        public string GetUserName()
        {
            var token = GetUserAccessToken();
            if (!string.IsNullOrEmpty(token))
            {
                var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
                return jwt.Claims.First(c => c.Type == "UserName").Value;
            }
            else
            {
                throw new CustomException("User not found");
            }
        }

    }

}
