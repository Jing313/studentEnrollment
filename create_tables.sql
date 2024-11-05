CREATE DATABASE StudentEnrollmentDb;
GO

USE StudentEnrollmentDb;
GO

CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    BirthDate DATE,
    Phone VARCHAR(20),
    Email VARCHAR(255),
    Gender VARCHAR(10),
    Address VARCHAR(255)
);

CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Description VARCHAR(MAX),
    StartDate DATE,
    EndDate DATE,
    Fees DECIMAL(18,2),
    Location VARCHAR(50),
	BranchAddress VARCHAR(255),
    ContactPerson VARCHAR(255)
);

CREATE TABLE Subjects (
    SubjectID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,
    Description VARCHAR(MAX),
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID)
);

CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
    CourseID INT FOREIGN KEY REFERENCES Courses(CourseID),
    EnrollmentDate   
 DATE,
    Status VARCHAR(50), 
    Comments VARCHAR(MAX)
);