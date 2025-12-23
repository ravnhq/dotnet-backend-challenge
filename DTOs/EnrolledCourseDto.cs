namespace BackendChallenge.DTOs;

public class EnrolledCourseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Credits { get; set; }
    public DateTime EnrolledAt { get; set; }

    public EnrolledCourseDto(Guid id, string name, int credits, DateTime enrolledAt)
    {
        Id = id;
        Name = name;
        Credits = credits;
        EnrolledAt = enrolledAt;
    }
}
