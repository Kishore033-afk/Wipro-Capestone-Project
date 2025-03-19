using E_Learning_API.Models;

namespace E_Learning_API.Models
{
public class QuizAttempt
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public int Score { get; set; }
    public DateTime AttemptDate { get; set; }

    // Navigation properties
    public User User { get; set; } = null!;
    public Quiz Quiz { get; set; } = null!;
}
}
