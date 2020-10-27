using System;

namespace BLL.DataTransferObjects
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
    }
}
