using Microsoft.EntityFrameworkCore;
using StudentEnrollementSystem_Backend.Models;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;

namespace StudentEnrollementSystem_Backend.DB
{
    public class StudentContext : DbContext
    {
        public StudentContext(Microsoft.EntityFrameworkCore.DbContextOptions options) :
        base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
               new Student() { Id = 1, FirstName = "Student1", LastName = "Tan", DoB = new DateTime(2000, 1, 23), Phone = "+6512345678", Email="123@test.com", Address="123 street", Gender="Male", CourseId = 1, Active = true },
               new Student() { Id = 2, FirstName = "Student2", LastName = "Lee", DoB = new DateTime(2001, 4, 12), Phone = "+6523456789", Email = "234@test.com", Address = "234 street", Gender = "Female", CourseId = 2, Active = true }
               );
        }
    }
}
