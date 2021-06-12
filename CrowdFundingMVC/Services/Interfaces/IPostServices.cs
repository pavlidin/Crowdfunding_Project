using CrowdFundingMVC.Models;
using CrowdFundingMVC.Models.Options;
using System.Collections.Generic;
using System.Linq;

namespace CrowdFundingMVC.Services.Interfaces
{
    public interface IPostServices
    {
        bool DeletePost(int postId);
        List<Post> GetAllPosts(int projectId);
        Result<Post> CreatePost(PostOptions postOptions);
        Result<Post> UpdatePost(PostOptions postOptions);
        IQueryable<Post> SearchPosts( PostOptions postOptions);
        Post FindPostById(int projectId, int postId);
    }
}