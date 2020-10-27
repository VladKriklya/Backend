using BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Data.Interfaces
{
    public interface IPostRepository
    {
        void CreatePost(Post post);
        void DeletePost(Post post);
        Task<Post> GetPostAsync(Guid postId, bool trackChanges);
        Task<IEnumerable<Post>> GetAllPostsAsync(bool trackChanges);
        Task<IEnumerable<Post>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    }
}
