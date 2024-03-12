using System.ComponentModel.DataAnnotations;

namespace Boardgames.Data.Models
{
    public class Creator
    {
        public Creator()
        {
            Boardgames = new List<Boardgame>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(7)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(7)]
        public string LastName { get; set; }

        public virtual ICollection<Boardgame> Boardgames { get; set; } 
    }
}


//•	Id – integer, Primary Key
//•	FirstName – text with length [2, 7] (required)
//•	LastName – text with length [2, 7] (required)
//•	Boardgames – collection of type Boardgame
