using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Post
{
    public interface IPostService
    {
        public Task<List<EFCore.DbModels.Post>> GetDashboardForUser(Guid userId);
        public Task<EFCore.DbModels.Post> AddOrUpdatePost(EFCore.DbModels.Post post, Guid userId);
        public Task<EFCore.DbModels.Post> LikePost(int id, Guid userId);
        public Task<List<EFCore.DbModels.Post>> GetUserPosts(Guid userId);
        public Task<EFCore.DbModels.Post> GetSinglePost(int id);
        public Task DeletePost(int id, Guid userId);

    }
}
