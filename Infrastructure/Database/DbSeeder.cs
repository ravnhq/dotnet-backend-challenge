using System.Security.Cryptography.X509Certificates;
using BackendChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Infrastructure.Database;

public static class DbSeeder
{
    public static async Task SeedAndCreateDbAsync(AppDbContext context)
    {
        await context.Database.MigrateAsync();
        var currentCourses = await context.Courses.ToListAsync();
        if (currentCourses.Count == 0)
        {
            currentCourses = await AddCoursesAsync(context);
        }

        if (await context.Students.AnyAsync() == false)
        {
            await AddStudentsAsync(context, currentCourses);
        }
    }

    private static async Task AddStudentsAsync(AppDbContext context, List<Course> currentCourses)
    {
        var johnId = Guid.NewGuid();
        var janeId = Guid.NewGuid();

        context.Students.AddRange(
        [
            new Student
                {
                    Id = johnId,
                    FirstName = "John",
                    LastName = "Doe",
                    CreatedAt = DateTime.UtcNow,
                    EnrolledCourses = [
                        new StudentEnrolledCourse
                        {
                            Id = Guid.NewGuid(),
                            StudentId = johnId,
                            Credits = 4,
                            CourseId = currentCourses.First(c => c.Name == "Data Structures").Id,
                            EnrolledAt = DateTime.UtcNow.AddDays(-30)
                        },
                        new StudentEnrolledCourse
                        {
                            Id = Guid.NewGuid(),
                            StudentId = johnId,
                            CourseId = currentCourses.First(c => c.Name == "Thermodynamics").Id,
                            Credits = 3,
                            EnrolledAt = DateTime.UtcNow.AddDays(-25)
                        }
                    ]
                },
                new Student
                {
                    Id = janeId,
                    FirstName = "Jane",
                    LastName = "Smith",
                    CreatedAt = DateTime.UtcNow,
                    EnrolledCourses = [
                        new StudentEnrolledCourse
                        {
                            Id = Guid.NewGuid(),
                            StudentId = janeId,
                            CourseId = currentCourses.First(c => c.Name == "Anatomy 101").Id,
                            Credits = 5,
                            EnrolledAt = DateTime.UtcNow.AddDays(-20)
                        },
                        new StudentEnrolledCourse
                        {
                            Id = Guid.NewGuid(),
                            StudentId = janeId,
                            CourseId = currentCourses.First(c => c.Name == "Constitutional Law").Id,
                            Credits = 4,
                            EnrolledAt = DateTime.UtcNow.AddDays(-15)
                        },
                        new StudentEnrolledCourse
                        {
                            Id = Guid.NewGuid(),
                            StudentId = janeId,
                            CourseId = currentCourses.First(c => c.Name == "Biochemistry").Id,
                            Course = currentCourses.First(c => c.Name == "Biochemistry"),
                            Credits = 3,
                            EnrolledAt = DateTime.UtcNow.AddDays(-10)
                        }
                    ]
                }
        ]);

        await context.SaveChangesAsync();
    }

    private static async Task<List<Course>> AddCoursesAsync(AppDbContext context)
    {

        Course[] courses = [
            new Course
            {
                Id = Guid.NewGuid(),
                Name = "Anatomy 101",
                Faculty = Models.Faculties.Medicine.ToString()
            },
            new Course
            {
                Id = Guid.NewGuid(),
                Name = "Biochemistry",
                Faculty = Models.Faculties.Medicine.ToString()
            },
            new Course
            {
                Id = Guid.NewGuid(),
                Name = "Data Structures",
                Faculty = Models.Faculties.Engineering.ToString()
            },
            new Course
            {
                Id = Guid.NewGuid(),
                Name = "Thermodynamics",
                Faculty = Models.Faculties.Engineering.ToString()
            },
            new Course
            {
                Id = Guid.NewGuid(),
                Name = "Constitutional Law",
                Faculty = Models.Faculties.Law.ToString()
            },
            new Course
            {
                Id = Guid.NewGuid(),
                Name = "Criminal Law",
                Faculty = Models.Faculties.Law.ToString()
            }
        ];
        await context.Courses.AddRangeAsync(courses);
        await context.SaveChangesAsync();

        return courses.ToList();
    }
}