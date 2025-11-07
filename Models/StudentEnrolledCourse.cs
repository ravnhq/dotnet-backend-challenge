namespace BackendChallenge.Models;

public class StudentEnrolledCourse
{
    public required Guid Id { get; set; }
    public required Guid StudentId { get; set; }
    public required Guid CourseId { get; set; }
    public DateTime EnrolledAt { get; set; }
    public required int Credits { get; set; }
    public Course? Course { get; set; }
}
