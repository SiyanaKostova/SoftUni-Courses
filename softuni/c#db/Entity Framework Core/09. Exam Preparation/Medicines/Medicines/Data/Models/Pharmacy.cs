using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Data.Models
{
    public class Pharmacy
    {
        public Pharmacy()
        {
            Medicines = new List<Medicine>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [MaxLength(14)]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$")]
        public string PhoneNumber { get; set; }

        [Required]
        public bool IsNonStop { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
