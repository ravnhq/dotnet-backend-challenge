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
    public async Task<ActionResult> GetStudentById(Guid studentId)
    {
        var student = await _context.Students
            .Where(x => x.Id == studentId)
            .Select(x => new
            {
                x.Id,
                x.FirstName,
                x.LastName,
                x.CreatedAt,
                EnrollesCoursed = x.EnrolledCourses.Select(er => new
                {
                    er.Id,
                    er.Credits,
                    er.EnrolledAt,
                    er.Course.Name
                }).ToList()
            }).FirstOrDefaultAsync();

        if (student is null)
        {
            return NotFound();
        }

        return Ok(student);
    }
}