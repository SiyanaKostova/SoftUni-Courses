using System.ComponentModel.DataAnnotations;
using TaskBoard.Data;

namespace TaskBoard.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.TaskMaxTitle, MinimumLength = DataConstants.TaskMinTitle)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(DataConstants.TaskMaxDescription, MinimumLength = DataConstants.TaskMinDescription)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Owner { get; set; } = string.Empty;
    }
}
