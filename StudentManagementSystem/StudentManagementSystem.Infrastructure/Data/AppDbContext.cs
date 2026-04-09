using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Infrastructure.Data;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var student = modelBuilder.Entity<Student>();
        student.ToTable("Student");

        student.HasKey(x => x.Id);
        student.Property(x => x.Name).HasMaxLength(200).IsRequired();
        student.Property(x => x.Email).HasMaxLength(256).IsRequired();
        student.HasIndex(x => x.Email).IsUnique();
        student.Property(x => x.Age).IsRequired();
        student.Property(x => x.Course).HasMaxLength(200).IsRequired();
        student.Property(x => x.CreatedDate).IsRequired();
    }
}

