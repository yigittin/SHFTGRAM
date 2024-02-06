using EFCore;
using EFCore.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SHFTGRAMAPP.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Post
{
    public class PostService:IPostService
    {
        private readonly IConfiguration _configs;
        private readonly DataContext _context;

        public PostService(IConfiguration configs, DataContext context)
        {
            _configs = configs;
            _context = context;
        }
        public async Task<List<EFCore.DbModels.Post>> GetDashboardForUser(Guid userId)
        {
            try
            {
                var followers=await _context.Follows.Where(x=>x.FollowingId==userId).ToListAsync();
                var postList=new List<EFCore.DbModels.Post>();
                foreach(var f in followers)
                {
                    var postTopFive=await _context.Posts.Where(x=>x.UserId==f.FollowerId&& x.IsDeleted == false).OrderByDescending(x=>x.CreateTime).Take(5).ToListAsync();
                    if(postTopFive.Count>0)
                        postList.InsertRange(0,postTopFive);
                }
                var userLastPost = await _context.Posts.Where(x => x.UserId == userId&&x.IsDeleted==false).OrderByDescending(x => x.CreateTime).Take(1).FirstOrDefaultAsync();
                var userOtherPosts = await _context.Posts.Where(x => x.UserId == userId&& x.IsDeleted == false).OrderByDescending(x => x.CreateTime).Take(5).Skip(1).ToListAsync();
                if (userLastPost is not null)
                    postList.Insert(0,userLastPost);
                postList.AddRange(userOtherPosts);
                return postList;
            }catch(Exception ex)
            {
                throw new CustomException("Something went wrong : " + ex.Message);
            }
        }
        public async Task<EFCore.DbModels.Post> AddOrUpdatePost(EFCore.DbModels.Post post,Guid userId)
        {
            try
            {
                var user = await _context.Users.Where(x => x.UserId == userId && x.IsDeleted == false).FirstOrDefaultAsync() ?? throw new NotFoundException("User");
                if (post.Id == 0)
                {
                    post.IsDeleted = false;
                    post.LikeCount = 0;
                    post.CreatedBy = user.UserName;
                    post.CreateTime = DateTime.Now;
                    post.ModifiedBy = user.UserName;
                    post.ModifiedTime = DateTime.Now;
                    post.UserId = userId;
                    await _context.AddAsync(post);
                }
                else
                {
                    var oldPost = await _context.Posts.Where(x => x.Id == post.Id && x.IsDeleted == false && x.UserId == userId).FirstOrDefaultAsync()?? throw new NotFoundException("Post");
                    if (oldPost.UserId != userId)
                        throw new CustomException("Something went wrong");
                    oldPost.Text = post.Text;
                    oldPost.ModifiedBy = user.UserName;
                    oldPost.ModifiedTime = DateTime.Now;

                }
                await _context.SaveChangesAsync();
                return post;

            }catch(Exception ex)
            {
                throw new CustomException("Something went wrong : " + ex.Message);
            }
        }
        public async Task<EFCore.DbModels.Post> LikePost(int id,Guid userId)
        {
            try
            {                
                var post = await _context.Posts.Where(x => x.Id == id&&x.IsDeleted==false).FirstOrDefaultAsync()??throw new NotFoundException("Post");
                var user=await _context.Users.Where(x=>x.UserId==userId&&x.IsDeleted==false).FirstOrDefaultAsync()?? throw new NotFoundException("User");
                var isLiked = await _context.Likes.Where(x => x.UserId == userId && x.PostId == post.Id).FirstOrDefaultAsync();
                if (isLiked is not null)
                    throw new CustomException("Liked before");

                var newLike = new Likes()
                {
                    PostId=post.Id,
                    UserId=userId                    
                };
                post.LikeCount++;

                await _context.AddAsync(newLike);
                await _context.SaveChangesAsync();
                return post;

            }
            catch (Exception ex)
            {
                throw new CustomException("Something went wrong : " + ex.Message);
            }
        }
        public async Task<List<EFCore.DbModels.Post>> GetUserPosts(Guid userId)
        {
            try
            {
                var user=await _context.Users.Where(x=>x.UserId==userId&&x.IsDeleted==false).FirstOrDefaultAsync();
                if(user is null)
                    throw new NotFoundException("User");
                return await _context.Posts.Where(x => x.UserId == userId && x.IsDeleted == false).OrderByDescending(x=>x.CreateTime).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new CustomException("Something went wrong : " + ex.Message);
            }
        }         
        public async Task<EFCore.DbModels.Post> GetSinglePost(int id)
        {
            return await _context.Posts.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefaultAsync() ?? throw new NotFoundException("Post");
        }
        public async Task DeletePost(int id,Guid userId)
        {
            try
            {
                var post= await _context.Posts.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefaultAsync() ?? throw new NotFoundException("Post");
                var user= await _context.Users.Where(x => x.UserId == userId && x.IsDeleted == false).FirstOrDefaultAsync() ?? throw new NotFoundException("User");
                if (post.UserId != user.UserId)
                    throw new CustomException("Something went wrong");
                post.IsDeleted = true;
                post.ModifiedBy = user.UserName;
                post.ModifiedTime=DateTime.Now;
                await _context.SaveChangesAsync();

            }catch(Exception ex)
            {
                throw new CustomException("Something went wrong : " + ex.Message);
            }
        }
    }
}
