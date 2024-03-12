using System.ComponentModel.DataAnnotations;
using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Models
{
    public class AddSeminarsViewModel
    {
        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(Seminar.TopicMaxLength, 
            MinimumLength = Seminar.TopicMinLength, 
            ErrorMessage = StringLengthErrorMessage)]
        public string Topic { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(Seminar.LecturerMaxLength,
            MinimumLength = Seminar.LecturerMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Lecturer { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        [StringLength(Seminar.DetailsMaxLength, 
            MinimumLength = Seminar.DetailsMinLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Details { get; set; } = null!;

        [Required(ErrorMessage = RequireErrorMessage)]
        public string DateAndTime { get; set; } = null!;

        [Range(Seminar.DurationMin, Seminar.DurationMax, ErrorMessage = IntLengthErrorMessage)]
        public int Duration { get; set; }

        [Required(ErrorMessage = RequireErrorMessage)]
        public int CategoryId { get; set; }

        public IList<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}