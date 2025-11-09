namespace BackendChallenge.DTOs;

public class StudentResponseDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public List<EnrolledCourseDto> EnrolledCourses { get; set; } = new();
}
