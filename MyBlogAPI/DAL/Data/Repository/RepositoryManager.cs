using DAL.Data.Interfaces;
using System.Threading.Tasks;

namespace DAL.Data.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;

        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        private IAuthRepository _authRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IPostRepository Posts
        {
            get
            {
                if (_postRepository == null)
                    _postRepository = new PostRepository(_repositoryContext);
                return _postRepository;
            }
        }

        public ICommentRepository Comments
        {
            get
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_repositoryContext);
                return _commentRepository;
            }
        }

        public IAuthRepository Auth
        {
            get
            {
                if (_authRepository == null)
                    _authRepository = new AuthRepository(_repositoryContext);
                return _authRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
