namespace StudentManagementSystem.Application.Dtos;

public sealed record StudentUpdateDto(
    string Name,
    string Email,
    int Age,
    string Course
);

