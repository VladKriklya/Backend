using System;

namespace BLL.DataTransferObjects
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
    }
}
