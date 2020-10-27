using BLL.Models;
using DAL.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Data.Repository
{
    public class PostRepository: RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void CreatePost(Post post) => Create(post);
        public void DeletePost(Post post) => Delete(post);

        public async Task<IEnumerable<Post>> GetAllPostsAsync(bool trackChanges) =>
             await FindAll(trackChanges)
             .OrderBy(c => c.Title)
              .ToListAsync();

        public async Task<Post> GetPostAsync(Guid id, bool trackChanges) =>
             await FindByCondition(c => c.Id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();

        public async Task<IEnumerable<Post>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
             await FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToListAsync();
    }
}
