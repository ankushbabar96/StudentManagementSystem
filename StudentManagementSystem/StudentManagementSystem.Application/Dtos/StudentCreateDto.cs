namespace StudentManagementSystem.Application.Dtos;

public sealed record StudentCreateDto(
    string Name,
    string Email,
    int Age,
    string Course
);

