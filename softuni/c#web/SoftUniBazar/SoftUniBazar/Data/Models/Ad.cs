using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace SoftUniBazar.Data.Models
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.AdNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(DataConstants.AdDescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
        public DateTime CreatedOn { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
    }
}