using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using P01_StudentSystem.P01_StudentSystem.Data.Models.Enums;

namespace P01_StudentSystem.P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmissionTime { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Student Student { get; set; }


        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}