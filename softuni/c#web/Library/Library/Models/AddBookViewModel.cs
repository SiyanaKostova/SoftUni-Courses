using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants;

namespace Library.Models
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(TitleMaximumLength, MinimumLength = TitleMinumumLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(AuthorMaximumLength, MinimumLength = AuthorMinimumLength)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaximumLength, MinimumLength = DescriptionMinumumLength)]
        public string Description { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Url { get; set; } = string.Empty;

        [Required]
        public string Rating { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
