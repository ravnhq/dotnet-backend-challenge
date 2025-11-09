namespace BackendChallenge.DTOs;

public class EnrolledCourseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Credits { get; set; }
    public DateTime EnrolledAt { get; set; }
}
