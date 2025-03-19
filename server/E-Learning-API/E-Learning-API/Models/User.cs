using E_Learning_API.Models;
namespace E_Learning_API.Models
{
   public class User
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string Role { get; set; }

    // Navigation properties
    public List<Enrollment> Enrollments { get; set; } = new();
    public List<QuizAttempt> QuizAttempts { get; set; } = new();
    public List<Course> CreatedCourses { get; set; } = new();
}
}