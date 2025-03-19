using E_Learning_API.Models;
using ELearningAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning_API.Controllers
{

    [ApiController]
    [Route("api/quizzes")]
    public class QuizController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuizController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{courseId}")]
        public async Task<ActionResult<IEnumerable<Quiz>>> GetQuizzes(int courseId)
        {
            return await _context.Quizzes
                .Where(q => q.CourseId == courseId)
                .Include(q => q.Questions)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Quiz>> CreateQuiz(Quiz quiz)
        {
            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetQuizzes), new { courseId = quiz.CourseId }, quiz);
        }

        [HttpPost("attempt")]
        public async Task<ActionResult<QuizAttempt>> SubmitQuizAttempt(QuizAttempt attempt)
        {
            _context.QuizAttempts.Add(attempt);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetQuizAttempt), new { id = attempt.Id }, attempt);
        }

        [HttpGet("attempts/{id}")]
        public async Task<ActionResult<QuizAttempt>> GetQuizAttempt(int id)
        {
            var attempt = await _context.QuizAttempts.FindAsync(id);
            if (attempt == null) return NotFound();
            return attempt;
        }
    }
}