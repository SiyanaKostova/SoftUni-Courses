using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.StudentsEnrolled = new HashSet<StudentCourse>();
            this.HomeworkSubmissions = new HashSet<Homework>();
            this.Resources = new HashSet<Resource>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(80)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }
        public ICollection<StudentCourse> StudentsEnrolled { get; set; }
        public ICollection<Homework> HomeworkSubmissions { get; set; }
        public ICollection<Resource> Resources { get; set; }
    }
}