using System.ComponentModel.DataAnnotations;
using static ForumApp.Infrastructure.Constants.ValidationConstants;

namespace ForumApp.Core.Models
{
    /// <summary>
    /// Post data transfer model
    /// </summary>
    public class PostModel
    {
        /// <summary>
        /// Post identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Post title
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Post content
        /// </summary>
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Content { get; set; } = string.Empty;
    }
}
