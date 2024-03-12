using System.ComponentModel.DataAnnotations;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        public Despatcher()
        {
            Trucks = new List<Truck>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }
    }
}