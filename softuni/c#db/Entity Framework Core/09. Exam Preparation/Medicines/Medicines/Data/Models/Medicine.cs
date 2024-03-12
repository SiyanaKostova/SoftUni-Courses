using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Medicines.Data.Models.Enums;

namespace Medicines.Data.Models
{
    public class Medicine
    {
        public Medicine()
        {
            PatientsMedicines = new List<PatientMedicine>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 1000.00)]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Producer { get; set; }

        [Required]
        public int PharmacyId { get; set; }

        [ForeignKey(nameof(PharmacyId))]
        public Pharmacy Pharmacy { get; set; }

        public virtual ICollection<PatientMedicine> PatientsMedicines { get; set; }
    }
}