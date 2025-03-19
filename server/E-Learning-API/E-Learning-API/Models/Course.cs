using E_Learning_API.Models;
using System.ComponentModel.DataAnnotations;

namespace E_Learning_API.Models
{
    public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? Level { get; set; }
    public string? Language { get; set; }
    
    // Relationships
    public int InstructorId { get; set; }
    public User Instructor { get; set; } = null!;
    
    public List<Enrollment> Enrollments { get; set; } = new();
    public List<Lesson> Lessons { get; set; } = new();
    public List<Quiz> Quizzes { get; set; } = new();
}
}