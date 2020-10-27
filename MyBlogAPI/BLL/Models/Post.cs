using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models
{
    public class Post
    {
        [Column("PostId")]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
