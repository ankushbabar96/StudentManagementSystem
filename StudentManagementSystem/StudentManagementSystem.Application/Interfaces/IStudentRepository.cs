using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Application.Interfaces;

public interface IStudentRepository
{
    Task<List<Student>> GetAllAsync(CancellationToken cancellationToken);
    Task<Student?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<bool> EmailExistsAsync(string email, int? excludeStudentId, CancellationToken cancellationToken);
    Task AddAsync(Student student, CancellationToken cancellationToken);
    Task UpdateAsync(Student student, CancellationToken cancellationToken);
    Task DeleteAsync(Student student, CancellationToken cancellationToken);
}

