namespace BackendChallenge.Models;

public class Student
{
    public required Guid Id { get; set; } = Guid.CreateVersion7();
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<StudentEnrolledCourse> EnrolledCourses { get; set; } = new();
}
