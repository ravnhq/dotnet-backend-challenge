using BackendChallenge.Infrastructure.Database;
using BackendChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Controllers;

[Route("[Controller]")]
public class CoursesController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public CoursesController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetCoursesAsync()
    {
        var courses = await _appDbContext.Courses.ToListAsync();
        return Ok(courses);
    }
}