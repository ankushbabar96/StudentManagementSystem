CREATE DATABASE StudentManagementSystemDb;
GO

USE StudentManagementSystemDb;
GO

CREATE TABLE dbo.Student
(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Email NVARCHAR(256) NOT NULL,
    Age INT NOT NULL,
    Course NVARCHAR(200) NOT NULL,
    CreatedDate DATETIME2 NOT NULL
);
GO

CREATE UNIQUE INDEX IX_Student_Email ON dbo.Student(Email);
GO

