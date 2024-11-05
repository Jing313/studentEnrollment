using Microsoft.EntityFrameworkCore;
using StudentEnrollementSystem_Backend.DB;
using StudentEnrollementSystem_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class CourseRepositoryTests
    {
        private StudentContext _context;
        private CourseRepository _courseRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<StudentContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new StudentContext(options);
            _courseRepository = new CourseRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose(); // Dispose of the context after each test
        }

        [Test]
        public async Task GetCourses_ReturnsAllCourses()
        {
            // Arrange
            _context.Courses.Add(new Course { Name = "Course 1" });
            _context.Courses.Add(new Course { Name = "Course 2" });
            await _context.SaveChangesAsync();

            // Act
            var courses = await _courseRepository.GetCourses();

            // Assert
            Assert.AreEqual(2, courses.Count);
        }

        [Test]
        public async Task AddCourseAsync_AddsCourseToDatabase()
        {
            // Arrange
            var courseToAdd = new Course { Name = "New Course" };

            // Act
            await _courseRepository.AddCourseAsync(courseToAdd);

            // Assert
            var course = await _context.Courses.FindAsync(courseToAdd.Id);
            Assert.IsNotNull(course);
            Assert.AreEqual(courseToAdd.Name, course.Name);
        }

        [Test]
        public async Task UpdateCourseAsync_UpdatesCourseInDatabase()
        {
            // Arrange
            var courseToAdd = new Course { Name = "Course 1" };
            _context.Courses.Add(courseToAdd);
            await _context.SaveChangesAsync();

            // Act
            courseToAdd.Name = "Updated Course Name";
            await _courseRepository.UpdateCourseAsync(courseToAdd);

            // Assert
            var course = await _context.Courses.FindAsync(courseToAdd.Id);
            Assert.AreEqual("Updated Course Name", course.Name);
        }

        [Test]
        public async Task DeleteCourseAsync_RemovesCourseFromDatabase()
        {
            // Arrange
            var courseToAdd = new Course { Name = "Course 1" };
            _context.Courses.Add(courseToAdd);
            await _context.SaveChangesAsync();

            // Act
            await _courseRepository.DeleteCourseAsync(courseToAdd.Id);

            // Assert
            var course = await _context.Courses.FindAsync(courseToAdd.Id);
            Assert.IsNull(course);
        }
    }
}
