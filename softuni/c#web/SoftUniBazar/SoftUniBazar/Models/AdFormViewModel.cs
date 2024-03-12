using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using static SoftUniBazar.Data.DataConstants;

namespace SoftUniBazar.Models
{
    public class AdFormViewModel
    {
        [Required]
        [StringLength(AdNameMaxLength, MinimumLength = AdNameMinLength,
           ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(AdDescriptionMaxLength, MinimumLength = AdDescriptionMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
            = new List<CategoryViewModel>();
    }
}
