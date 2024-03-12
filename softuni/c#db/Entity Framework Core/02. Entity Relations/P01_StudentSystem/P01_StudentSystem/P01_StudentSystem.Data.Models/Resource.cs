using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01_StudentSystem.P01_StudentSystem.Data.Models.Enums;

namespace P01_StudentSystem.P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(max)")]
        public string Url { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }


        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
