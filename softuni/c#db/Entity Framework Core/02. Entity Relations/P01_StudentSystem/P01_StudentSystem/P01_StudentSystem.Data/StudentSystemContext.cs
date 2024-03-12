using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        //public StudentSystemContext(DbContextOptions options)
        //    : base(options)
        //{
        //}

        //private const string ConnectionString = "Server=DESKTOP-58M2VQU\\SQLEXPRESS;Database=StudentSystem;Integrated Security=True";

        //public DbSet<Student> Students { get; set; }
        //public DbSet<Course> Courses { get; set; }
        //public DbSet<Resource> Resources { get; set; }
        //public DbSet<Homework> Homeworks { get; set; }
        //public DbSet<StudentCourse> StudentsCourses { get; set; }

        ////protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        ////{
        ////    optionsBuilder.UseSqlServer(ConnectionString);
        ////}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<StudentCourse>()
        //        .HasKey(sc => new { sc.StudentId, sc.CourseId });
        //}
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-58M2VQU\\SQLEXPRESS;Database=StudentSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
        }

    }
}
