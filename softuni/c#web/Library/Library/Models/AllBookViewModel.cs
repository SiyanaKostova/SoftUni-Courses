using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants;

namespace Library.Models
{
    public class AllBookViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaximumLength, MinimumLength = TitleMinumumLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(AuthorMaximumLength, MinimumLength = AuthorMinimumLength)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaximumLength, MinimumLength = DescriptionMinumumLength)]
        public string? Description { get; set; }

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [StringLength(RatingMaximumLength, MinimumLength = RatingMinumumLength)]
        public decimal? Rating { get; set; }

        public string Category { get; set; } = null!;
    }
}