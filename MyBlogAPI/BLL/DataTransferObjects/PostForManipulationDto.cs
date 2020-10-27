using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.DataTransferObjects
{
    public abstract class PostForManipulationDto
    {
        [Required(ErrorMessage = "Title is a required field.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is a required field.")]
        public string Content { get; set; }
        public string Image { get; set; }

        public IEnumerable<CommentForCreationDto> Comments { get; set; }
    }
}
