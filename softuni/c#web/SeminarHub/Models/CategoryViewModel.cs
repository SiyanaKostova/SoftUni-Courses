using SeminarHub.Data;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = DataConstants.RequireErrorMessage)]
        [StringLength(DataConstants.Category.NameMaxLength, 
            MinimumLength = DataConstants.Category.NameMinLength,
            ErrorMessage = DataConstants.StringLengthErrorMessage)]
        public string Name { get; set; } = null!;
    }
}