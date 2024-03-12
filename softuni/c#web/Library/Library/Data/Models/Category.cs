using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    [Comment("Categories for the books")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.CategoryNameMaximumLength)]
        public string Name { get; set; } = string.Empty;

        public List<Book> Books { get; set; } = new List<Book>();
    }
}