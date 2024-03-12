using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Data.DataConstants;

namespace Library.Data.Models
{
    [Comment("Books for the library")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaximumLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(AuthorMaximumLength)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaximumLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public List<IdentityUserBook> UsersBooks { get; set; } = new List<IdentityUserBook>();
    }
}