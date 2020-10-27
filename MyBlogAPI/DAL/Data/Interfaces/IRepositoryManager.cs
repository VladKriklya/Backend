using System.Threading.Tasks;

namespace DAL.Data.Interfaces
{
    public interface IRepositoryManager
    {
        IPostRepository Posts { get; }
        ICommentRepository Comments { get; }
        IAuthRepository Auth { get; }
        Task SaveAsync();
    }
}
