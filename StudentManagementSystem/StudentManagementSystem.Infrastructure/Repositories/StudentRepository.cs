using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Infrastructure.Data;

namespace StudentManagementSystem.Infrastructure.Repositories;

public sealed class StudentRepository(AppDbContext db) : IStudentRepository
{
    public Task<List<Student>> GetAllAsync(CancellationToken cancellationToken) =>
        db.Students.AsNoTracking().OrderByDescending(x => x.Id).ToListAsync(cancellationToken);

    public Task<Student?> GetByIdAsync(int id, CancellationToken cancellationToken) =>
        db.Students.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public Task<bool> EmailExistsAsync(string email, int? excludeStudentId, CancellationToken cancellationToken)
    {
        var normalized = email.Trim();
        return db.Students.AnyAsync(
            x => x.Email == normalized && (!excludeStudentId.HasValue || x.Id != excludeStudentId.Value),
            cancellationToken
        );
    }

    public async Task AddAsync(Student student, CancellationToken cancellationToken)
    {
        db.Students.Add(student);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Student student, CancellationToken cancellationToken)
    {
        db.Students.Update(student);
        await db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Student student, CancellationToken cancellationToken)
    {
        db.Students.Remove(student);
        await db.SaveChangesAsync(cancellationToken);
    }
}

