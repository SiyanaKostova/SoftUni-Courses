using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.CourseEnrollments = new HashSet<StudentCourse>();
            this.HomeworkSubmissions = new HashSet<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; }
        public ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}