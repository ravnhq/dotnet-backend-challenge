namespace BackendChallenge.DTOs;

public record StudentResponseDto(Guid Id, string FirstName, string LastName, DateTime CreatedAt, List<EnrolledCourseDto> EnrolledCourses);
