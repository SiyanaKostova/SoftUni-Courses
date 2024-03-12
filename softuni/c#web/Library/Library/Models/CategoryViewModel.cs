using Library.Data;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.CategoryNameMaximumLength, MinimumLength = DataConstants.CategoryNameMinimumLength)]
        public string Name { get; set; } = string.Empty;
    }
}