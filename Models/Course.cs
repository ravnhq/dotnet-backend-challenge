namespace BackendChallenge.Models;

public class Course
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Faculty { get; set; }
}
