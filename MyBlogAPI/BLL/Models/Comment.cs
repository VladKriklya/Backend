using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models
{
    public class Comment
    {
        [Column("CommentId")]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        [ForeignKey(nameof(Post))]
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}
