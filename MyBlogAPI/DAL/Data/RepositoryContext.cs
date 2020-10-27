using BLL.Models;
using DAL.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
       : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
