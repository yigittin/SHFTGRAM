using Domain.User;
using EFCore;
using EFCore.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SHFTGRAMAPP.Core.Exceptions;

namespace Service.Login
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configs;
        private readonly DataContext _context;

        public LoginService(IConfiguration configs, DataContext dataContext)
        {
            _configs = configs;
            _context = dataContext;
        }
        public async Task<UserToken> Login(string username, string password)
        {
            var conString = _configs.GetConnectionString("Shftgram");
            var valKey = _configs.GetSection("MachineKey:validationKey").Value;
            string encodedPass = EncodePassword(username.ToLowerInvariant() + password, valKey);
            var user = await GetUser(username, encodedPass);
            string token = string.Empty;
            if (user.UserName is not null)
            {
                var role = await GetUserRole(user.UserId);
                token = CreateToken(user, role);
                var rzlt = new UserToken()
                {
                    Role = role,
                    AccessToken = token,
                    UserData = new UserData()
                    {
                        UserId = user.UserId,
                        UserName = user.UserName,
                    }

                };
                var dbUser = await _context.Users.Where(x => x.UserId == user.UserId).FirstOrDefaultAsync();
                dbUser.LastLogin = DateTime.Now;
                dbUser.LastActivateDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return rzlt;
            }
            return null;
        }
        private static string EncodePassword(string password, string valKey)
        {
            string encodedPassword = password;
            System.Security.Cryptography.HMACSHA1 hash = new System.Security.Cryptography.HMACSHA1();
            hash.Key = HexToByte(valKey);
            encodedPassword = Convert.ToBase64String(hash.ComputeHash(System.Text.Encoding.Unicode.GetBytes(password)));
            return encodedPassword;
        }
        private static byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }
        private static bool CheckPassword(string password, string dbpassword, string valKey)
        {
            string pass1 = password;
            string pass2 = dbpassword;
            pass1 = EncodePassword(password, valKey);
            return (pass1 == pass2);

        }
        private string CreateToken(UserData user, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configs["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
                                    {
                                        new Claim(ClaimTypes.Name, user.UserId.ToString()),
                                        new Claim("UserName", user.UserName),
                                        new Claim(ClaimTypes.Role, role),
                                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                                    };
            var token = new JwtSecurityToken(
                issuer: _configs["JWT:ValidIssuer"],
                audience: _configs["JWT:ValidAudience"],
                expires: DateTime.Now.AddYears(1),
                claims: claims,
                signingCredentials: credentials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        public async Task<UserData> GetUser(string username, string password)
        {
            UserData user = new UserData();
            var conString = _configs.GetConnectionString("Shftgram");
            using (var sqlConnection = new SqlConnection(conString))
            {
                try
                {
                    await sqlConnection.OpenAsync();
                    string sSQL = @$"SELECT 
	                                    UserId,
	                                    UserName
                                    FROM
	                                    dbo.Users
                                    WHERE
                                         Password=@Password AND UserName=@Username";

                    SqlCommand command = new SqlCommand(sSQL, sqlConnection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        user.UserId = Guid.Parse(reader["UserId"].ToString());
                        user.UserName = reader["UserName"].ToString();
                    }
                    await reader.CloseAsync();
                    await sqlConnection.CloseAsync();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return user;
        }
        public async Task<List<UserPermission>> GetUserPermissions(Guid UserId)
        {
            List<UserPermission> retList = new List<UserPermission>();
            var conString = _configs.GetConnectionString("Shftgram");
            using (var sqlConnection = new SqlConnection(conString))
            {
                await sqlConnection.OpenAsync();
                string sSQL = @$"SELECT  dbo.Users.UserId, dbo.Users.UserName, dbo.Users.RoleId, dbo.RoleActionType.IslemId, dbo.UserActionType.ActionName
	                        FROM Users
	                        INNER JOIN dbo.RoleActionType ON dbo.RoleActionType.RoleActionTypeId = dbo.Users.RoleId
	                        INNER JOIN dbo.UserActionType ON dbo.UserActionType.UserActionTypeId = dbo.RoleActionType.IslemId
	                        WHERE dbo.Users.UserId =@UserId";
                SqlCommand command = new SqlCommand(sSQL, sqlConnection);
                command.Parameters.AddWithValue("@UserId", UserId);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    UserPermission prms = new UserPermission()
                    {
                        ActionId = Convert.ToInt32(reader["IslemId"]),
                        ActionType = reader["ActionName"].ToString(),
                    };
                    retList.Add(prms);
                }
                await reader.CloseAsync();
                await sqlConnection.CloseAsync();
            }
            return retList;
        }
        public async Task<string> GetUserRole(Guid userId)
        {
            var conString = _configs.GetConnectionString("Shftgram");
            string role = string.Empty;
            using (var sqlConnection = new SqlConnection(conString))
            {
                await sqlConnection.OpenAsync();
                string sSQL = $@"SELECT dbo.Users.UserId, dbo.Users.UserName, dbo.Users.RoleId,RT.RoleName
                                FROM Users
                                INNER JOIN dbo.RoleTypes RT ON RT.RoleTypeId = dbo.Users.RoleId
                                WHERE dbo.Users.UserId = @UserId";
                SqlCommand command = new SqlCommand(sSQL, sqlConnection);
                command.Parameters.AddWithValue("@UserId", userId);
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    role = reader["RoleName"].ToString();
                }
                await reader.CloseAsync();
                await sqlConnection.CloseAsync();
            }
            return role;
        }
        public async Task<UserToken> UserRegister(RegisterUser user)
        {
            var valKey = _configs.GetSection("MachineKey:validationKey").Value;
            var encodedPass = EncodePassword(user.UserName.ToLowerInvariant() + user.Password, valKey);
            var confirmCode = Guid.NewGuid();
            EFCore.DbModels.User newUser = new EFCore.DbModels.User()
            {
                Email = user.Email,
                UserName = user.UserName,
                Password = encodedPass,
                IsConfirmed = false,
                ConfirmationGuid = confirmCode,
                IsDeleted = false,
                IsLocked = false,
                RoleId = Guid.Parse("567ceb59-3058-40ed-8999-f095202939c8"),
                Name = user.Name,
                Surname = user.Surname,
                WrongPasswordCount = 0,
                Phone = user.PhoneNumber,
                RegisterDate = DateTime.Now,
                FollowerCount = 0,
                FollowingCount = 0
            };
            _context.Add(newUser);
            await _context.SaveChangesAsync();
            return await Login(user.UserName, user.Password);
        }
        public async Task<UserData> UserConfirmation(Guid confirmGuid)
        {
            var user = await _context.Users.Where(x => x.ConfirmationGuid == confirmGuid && x.IsDeleted == false).FirstOrDefaultAsync();
            if (user is not null)
            {
                user.IsConfirmed = true;
                await _context.SaveChangesAsync();
                return new UserData()
                {
                    UserId = user.UserId,
                    UserName = user.UserName
                };
            }
            else
                throw new NotFoundException("User");
        }

    }
}
