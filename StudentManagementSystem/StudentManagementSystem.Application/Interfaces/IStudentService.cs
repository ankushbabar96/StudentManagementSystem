using StudentManagementSystem.Application.Dtos;

namespace StudentManagementSystem.Application.Interfaces;

public interface IStudentService
{
    Task<List<StudentDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<StudentDto> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<StudentDto> CreateAsync(StudentCreateDto dto, CancellationToken cancellationToken);
    Task<StudentDto> UpdateAsync(int id, StudentUpdateDto dto, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}

