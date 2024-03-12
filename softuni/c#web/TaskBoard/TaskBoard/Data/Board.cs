using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Data
{
    public class Board
    {
        [Key]
        [Comment("Board identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.BoardMaxName)]
        [Comment("Board name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }
}