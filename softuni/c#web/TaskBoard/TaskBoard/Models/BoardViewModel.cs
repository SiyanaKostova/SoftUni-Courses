using System.ComponentModel.DataAnnotations;
using TaskBoard.Data;

namespace TaskBoard.Models
{
    public class BoardViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.BoardMaxName, MinimumLength = DataConstants.BoardMinName)]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>();
    }
}