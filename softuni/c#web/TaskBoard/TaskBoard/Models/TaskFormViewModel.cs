using System.ComponentModel.DataAnnotations;
using TaskBoard.Data;

namespace TaskBoard.Models
{
    public class TaskFormViewModel
    {
        [Required]
        [StringLength(DataConstants.TaskMaxTitle, MinimumLength = DataConstants.TaskMinTitle,
            ErrorMessage = "Title should be at least {2} characters long.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(DataConstants.TaskMaxDescription, MinimumLength = DataConstants.TaskMinDescription,
            ErrorMessage ="Description should be at least {2} characters long.")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = new List<TaskBoardModel>();
    }
}
