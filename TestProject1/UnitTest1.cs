using Microsoft.EntityFrameworkCore;
using StudentEnrollementSystem_Backend.DB;
using StudentEnrollementSystem_Backend.Models;

namespace TestProject1
{
    public class StudentRepositoryTests
    {
        private StudentContext _context;
        private StudentRepository _studentRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<StudentContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new StudentContext(options);
            _studentRepository = new StudentRepository(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose(); // Dispose of the context after each test
        }

        [Test]
        public async Task GetStudents_ReturnsOnlyActiveStudents()
        {
            // Arrange
            _context.Students.Add(new Student { FirstName = "Active Student 1", Active = true });
            _context.Students.Add(new Student { FirstName = "Inactive Student", Active = false });
            _context.Students.Add(new Student { FirstName = "Active Student 2", Active = true });
            await _context.SaveChangesAsync();

            // Act
            var students = await _studentRepository.GetStudents();

            // Assert
            Assert.AreEqual(2, students.Count);
            Assert.IsTrue(students.All(s => s.Active));
        }

        [Test]
        public async Task GetStudentByIdAsync_ReturnsCorrectStudent()
        {
            // Arrange
            var studentToAdd = new Student { FirstName = "John Doe", Active = true };
            _context.Students.Add(studentToAdd);
            await _context.SaveChangesAsync();

            // Act
            var student = await _studentRepository.GetStudentByIdAsync(studentToAdd.Id);

            // Assert
            Assert.IsNotNull(student);
            Assert.AreEqual(studentToAdd.Id, student.Id);
        }

        [Test]
        public async Task AddStudentAsync_AddsStudentToDatabase()
        {
            // Arrange
            var studentToAdd = new Student { FirstName = "Jane Doe", Active = true };

            // Act
            await _studentRepository.AddStudentAsync(studentToAdd);

            // Assert
            var student = await _context.Students.FindAsync(studentToAdd.Id);
            Assert.IsNotNull(student);
            Assert.AreEqual(studentToAdd.FirstName, student.FirstName);
        }

        [Test]
        public async Task UpdateStudentAsync_UpdatesStudentInDatabase()
        {
            // Arrange
            var studentToAdd = new Student { FirstName = "John Doe", Active = true };
            _context.Students.Add(studentToAdd);
            await _context.SaveChangesAsync();

            // Act
            studentToAdd.FirstName = "Updated Name";
            await _studentRepository.UpdateStudentAsync(studentToAdd);

            // Assert
            var student = await _context.Students.FindAsync(studentToAdd.Id);
            Assert.AreEqual("Updated Name", student.FirstName);
        }

        [Test]
        public async Task DeleteStudentAsync_RemovesStudentFromDatabase()
        {
            // Arrange
            var studentToAdd = new Student { FirstName = "John Doe", Active = true };
            _context.Students.Add(studentToAdd);
            await _context.SaveChangesAsync();

            // Act
            await _studentRepository.DeleteStudentAsync(studentToAdd.Id);

            // Assert
            var student = await _context.Students.FindAsync(studentToAdd.Id);
            Assert.IsNull(student);
        }
    }
}