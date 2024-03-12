using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace SoftUniBazar.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.CategoryNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public IList<Ad> Ads { get; set; } = new List<Ad>();  
    }
}