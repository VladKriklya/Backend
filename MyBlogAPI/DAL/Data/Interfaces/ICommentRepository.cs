using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsAsync(Guid postId, bool trackChanges);
        Task<Comment> GetCommentAsync(Guid postId, Guid id, bool trackChanges);
        void CreateCommentForPost(Guid postId, Comment comment);
        void DeleteComment(Comment comment);
    }
}
