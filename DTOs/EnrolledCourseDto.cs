namespace BackendChallenge.DTOs;

public record EnrolledCourseDto(Guid Id, string Name, int Credits, DateTime EnrolledAt);
