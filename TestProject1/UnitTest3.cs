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
    public class EnrollmentRepositoryTests
    {
        private StudentContext _context;
        private EnrollmentRepository _enrollmentRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<StudentContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new StudentContext(options);
            _enrollmentRepository = new EnrollmentRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose(); // Dispose of the context after each test
        }

        [Test]
        public async Task GetEnrollments_ReturnsAllEnrollments()
        {
            // Arrange
            _context.Enrollements.Add(new Enrollment { }); // Add some enrollments
            _context.Enrollements.Add(new Enrollment { });
            await _context.SaveChangesAsync();

            // Act
            var enrollments = await _enrollmentRepository.GetEnrollments();

            // Assert
            Assert.AreEqual(2, enrollments.Count);
        }

        [Test]
        public async Task AddEnrollmentAsync_AddsEnrollmentToDatabase()
        {
            // Arrange
            var enrollmentToAdd = new Enrollment {  /* Initialize properties as needed */ };

            // Act
            await _enrollmentRepository.AddEnrollmentAsync(enrollmentToAdd);

            // Assert
            var enrollment = await _context.Enrollements.FindAsync(enrollmentToAdd.Id);
            Assert.IsNotNull(enrollment);
            // Add more assertions to check specific properties if necessary
        }

        [Test]
        public async Task UpdateEnrollmentAsync_UpdatesEnrollmentInDatabase()
        {
            // Arrange
            var enrollmentToAdd = new Enrollment {  /* Initialize properties */ };
            _context.Enrollements.Add(enrollmentToAdd);
            await _context.SaveChangesAsync();

            // Act
            // Modify some properties of enrollmentToAdd
            await _enrollmentRepository.UpdateEnrollmentAsync(enrollmentToAdd);

            // Assert
            var enrollment = await _context.Enrollements.FindAsync(enrollmentToAdd.Id);
            // Assert that the properties were updated correctly
        }

        [Test]
        public async Task DeleteEnrollmentAsync_RemovesEnrollmentFromDatabase()
        {
            // Arrange
            var enrollmentToAdd = new Enrollment {  /* Initialize properties */ };
            _context.Enrollements.Add(enrollmentToAdd);
            await _context.SaveChangesAsync();

            // Act
            await _enrollmentRepository.DeleteEnrollmentAsync(enrollmentToAdd.Id);

            // Assert
            var enrollment = await _context.Enrollements.FindAsync(enrollmentToAdd.Id);
            Assert.IsNull(enrollment);
        }
    }
}
