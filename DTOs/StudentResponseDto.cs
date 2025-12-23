namespace BackendChallenge.DTOs;

public class StudentResponseDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<EnrolledCourseDto> EnrolledCourses { get; set; }

    public StudentResponseDto(Guid id, string firstName, string lastName, DateTime createdAt, List<EnrolledCourseDto> enrolledCourses)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        CreatedAt = createdAt;
        EnrolledCourses = enrolledCourses;
    }
}
