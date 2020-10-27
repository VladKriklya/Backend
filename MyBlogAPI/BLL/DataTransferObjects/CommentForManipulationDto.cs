using System.ComponentModel.DataAnnotations;

namespace BLL.DataTransferObjects
{
    public abstract class CommentForManipulationDto
    {
        [Required(ErrorMessage = "Email is a required field.")]
        [EmailAddress(ErrorMessage = "Incorrect address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Comment Text is a required field.")]
        public string CommentText { get; set; }
    }
}
