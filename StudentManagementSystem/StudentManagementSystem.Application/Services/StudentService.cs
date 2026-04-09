using StudentManagementSystem.Application.Dtos;
using StudentManagementSystem.Application.Exceptions;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.Services;

public sealed class StudentService(IStudentRepository repository) : IStudentService
{
    public async Task<List<StudentDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var students = await repository.GetAllAsync(cancellationToken);
        return students.Select(ToDto).ToList();
    }

    public async Task<StudentDto> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var student = await repository.GetByIdAsync(id, cancellationToken);
        if (student is null)
            throw new NotFoundException($"Student with id {id} not found.");

        return ToDto(student);
    }

    public async Task<StudentDto> CreateAsync(StudentCreateDto dto, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ValidationException("Name is required.");
        if (string.IsNullOrWhiteSpace(dto.Email))
            throw new ValidationException("Email is required.");
        if (dto.Age <= 0)
            throw new ValidationException("Age must be greater than 0.");
        if (string.IsNullOrWhiteSpace(dto.Course))
            throw new ValidationException("Course is required.");

        var emailExists = await repository.EmailExistsAsync(dto.Email, excludeStudentId: null, cancellationToken);
        if (emailExists)
            throw new ValidationException("Email already exists.");

        var student = new Student
        {
            Name = dto.Name.Trim(),
            Email = dto.Email.Trim(),
            Age = dto.Age,
            Course = dto.Course.Trim(),
            CreatedDate = DateTime.UtcNow
        };

        await repository.AddAsync(student, cancellationToken);
        return ToDto(student);
    }

    public async Task<StudentDto> UpdateAsync(int id, StudentUpdateDto dto, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ValidationException("Name is required.");
        if (string.IsNullOrWhiteSpace(dto.Email))
            throw new ValidationException("Email is required.");
        if (dto.Age <= 0)
            throw new ValidationException("Age must be greater than 0.");
        if (string.IsNullOrWhiteSpace(dto.Course))
            throw new ValidationException("Course is required.");

        var student = await repository.GetByIdAsync(id, cancellationToken);
        if (student is null)
            throw new NotFoundException($"Student with id {id} not found.");

        var emailExists = await repository.EmailExistsAsync(dto.Email, excludeStudentId: id, cancellationToken);
        if (emailExists)
            throw new ValidationException("Email already exists.");

        student.Name = dto.Name.Trim();
        student.Email = dto.Email.Trim();
        student.Age = dto.Age;
        student.Course = dto.Course.Trim();

        await repository.UpdateAsync(student, cancellationToken);
        return ToDto(student);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var student = await repository.GetByIdAsync(id, cancellationToken);
        if (student is null)
            throw new NotFoundException($"Student with id {id} not found.");

        await repository.DeleteAsync(student, cancellationToken);
    }

    private static StudentDto ToDto(Student student) =>
        new(
            student.Id,
            student.Name,
            student.Email,
            student.Age,
            student.Course,
            student.CreatedDate
        );
}

