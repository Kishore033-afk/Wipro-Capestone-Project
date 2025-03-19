using ELearningAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELearningAPI.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("stats")]
        public async Task<ActionResult<object>> GetDashboardStats()
        {
            var stats = new
            {
                TotalCourses = await _context.Courses.CountAsync(),
                ActiveStudents = await _context.Users.CountAsync(u => u.Role == "Student"),
                CompletedLessons = await _context.Enrollments
                    .SelectMany(e => e.Course.Lessons)
                    .CountAsync()
            };

            return Ok(stats);
        }

        [HttpGet("enrollments")]
        public async Task<ActionResult<IEnumerable<object>>> GetEnrollmentProgress()
        {
            var enrollments = await _context.Enrollments
                .Include(e => e.Course)
                .Select(e => new
                {
                    CourseTitle = e.Course.Title,
                    e.Progress
                })
                .ToListAsync();

            return Ok(enrollments);
        }
    }
}