using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Login
{
    public interface ILoginService
    {
        Task<UserToken> Login(string username, string password);
        Task<UserToken> UserRegister(RegisterUser user);
        Task<UserData> UserConfirmation(Guid confirmGuid);
    }
}
