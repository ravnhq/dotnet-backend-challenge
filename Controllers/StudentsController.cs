using BackendChallenge.DTOs;
using BackendChallenge.Infrastructure.Database;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Controllers;

[Route("[Controller]")]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IValidator<AddStudentDto> _validator;

    public StudentsController(
        AppDbContext context,
        IValidator<AddStudentDto> validator)
    {
        _context = context;
        _validator = validator;
    }

    [HttpGet("{studentId:guid}")]
    [ProducesResponseType<StudentResponseDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<StudentResponseDto>> GetStudentById(Guid studentId)
    {
        var student = await _context.Students
            .Where(x => x.Id == studentId)
            .Select(x => new StudentResponseDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CreatedAt = x.CreatedAt,
                EnrolledCourses = x.EnrolledCourses.Select(er => new EnrolledCourseDto
                {
                    Id = er.Id,
                    Name = er.Course!.Name,
                    Credits = er.Credits,
                    EnrolledAt = er.EnrolledAt
                }).ToList()
            }).FirstOrDefaultAsync();

        if (student is null)
        {
            return NotFound();
        }

        return Ok(student);
    }
}