using Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.User
{
    public interface IUserService
    {
        public Task<EFCore.DbModels.User> UpdateProfile(UpdateUser user, Guid userId);
        public Task UpdateProfilePicture(string picPath, Guid userId);
        public Task<EFCore.DbModels.User> GetUserPage(Guid userId);
        public Task Follow(Guid userId, Guid followedUserId);
        public Task UnFollow(Guid userId, Guid followedUserId);
        public Task<List<EFCore.DbModels.User>> SearchUsers(string search);
        public Task<string> GetUserName(Guid id);
    }
}
