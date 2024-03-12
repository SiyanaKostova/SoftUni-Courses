using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskBoard.Data
{
    public class Task
    {
        [Key]
        [Comment("Task identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.TaskMaxTitle)]
        [Comment("Task title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(DataConstants.TaskMaxDescription)]
        [Comment("Task description")]
        public string Description { get; set; } = string.Empty;

        [Comment("Date of creation")]
        public DateTime? CreatedOn { get; set; }

        [Comment("Board identifier")]
        public int? BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        public Board? Board { get; set; }

        [Required]
        [Comment("Application user identifier")]
        public string OwnerId { get; set; } = string.Empty;

        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;
    }
}