using Core.User;
using EFCore;
using EFCore.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SHFTGRAMAPP.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Service.User
{
    public class UserService: IUserService
    {
        private readonly IConfiguration _configs;
        private readonly DataContext _context;
        public UserService(IConfiguration configs, DataContext context)
        {
            _configs = configs;
            _context = context;
        }

        public async Task<EFCore.DbModels.User> UpdateProfile(UpdateUser user,Guid userId)
        {
            try
            {
                var updateUser= await _context.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();
                if (updateUser is null)
                    throw new NotFoundException("User");
                updateUser.BioText = user.BioText;
                updateUser.Phone = user.Phone;

                await _context.SaveChangesAsync();
                return updateUser;
            }
            catch (Exception ex)
            {
                throw new CustomException("Something went wrong : "+ ex.Message);
            }
        }
        public async Task UpdateProfilePicture(string picPath,Guid userId)
        {
            try
            {
                var updateUser = await _context.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();
                if (updateUser is null)
                    throw new NotFoundException("User");
                updateUser.ProfilePicture = picPath;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new CustomException("Something went wrong : " + ex.Message);
            }
        }
        public async Task<EFCore.DbModels.User> GetUserPage(Guid userId)
        {
            try
            {
                var user=await _context.Users.Where(x=>x.UserId == userId).FirstOrDefaultAsync();
                if (user is null)
                    throw new NotFoundException("User");
                return user;
            }catch(Exception ex)
            {
                throw new CustomException("Something went wrong : " + ex.Message);
            }
        }
        public async Task Follow(Guid userId,Guid followedUserId)
        {
            try
            {
                var followedUser = await _context.Users.Where(x => x.UserId == followedUserId).FirstOrDefaultAsync();
                if (followedUser is null)
                    throw new NotFoundException("User");
                var user = await _context.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();
                if(user is null)
                    throw new NotFoundException("User");

                var follower = new Follow()
                {
                    FollowerId=userId,
                    FollowingId=followedUserId
                };
                await _context.AddAsync(follower);
                followedUser.FollowerCount++;
                user.FollowingCount++;
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new CustomException("Something went wrong : " + ex.Message);
            }
        }
        public async Task UnFollow(Guid userId, Guid followedUserId)
        {
            try
            {
                var followedUser = await _context.Users.Where(x => x.UserId == followedUserId).FirstOrDefaultAsync();
                if (followedUser is null)
                    throw new NotFoundException("User");
                var user = await _context.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();
                if (user is null)
                    throw new NotFoundException("User");

                var following=await _context.Follows.Where(x=>x.FollowerId==userId&&x.FollowingId==followedUserId).FirstOrDefaultAsync();
                if(following is null)
                    throw new NotFoundException("User");

                _context.Remove(following);
                followedUser.FollowerCount--;
                user.FollowingCount--;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new CustomException("Something went wrong : " + ex.Message);
            }
        }
        public async Task<List<EFCore.DbModels.User>> SearchUsers(string search)
        {
            return await _context.Users.Where(x => x.UserName.Contains(search)).ToListAsync();
        }
        public async Task<string> GetUserName(Guid id)
        {
            var user = await _context.Users.Where(x => x.UserId == id && x.IsDeleted == false).FirstOrDefaultAsync() ?? throw new NotFoundException("User");
            return user.UserName;
        }
    }
}
