using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.Category.NameMaxLength)]
        public string Name { get; set; } = null!;

        public IList<Seminar> Seminars { get; set; } = new List<Seminar>();
    }
}