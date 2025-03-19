using E_Learning_API.Models;

namespace E_Learning_API.Models
{
 public class Quiz
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int CourseId { get; set; }
    public Course? Course { get; set; }
    public List<Question> Questions { get; set; } = new();
}
}