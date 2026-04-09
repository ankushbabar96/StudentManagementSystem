namespace StudentManagementSystem.Application.Dtos;

public sealed record StudentDto(
    int Id,
    string Name,
    string Email,
    int Age,
    string Course,
    DateTime CreatedDate
);

