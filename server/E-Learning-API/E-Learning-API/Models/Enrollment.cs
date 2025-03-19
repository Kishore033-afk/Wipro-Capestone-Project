namespace E_Learning_API.Models
{
public class Enrollment
{
    public int Id { get; set; }  

    // Foreign keys - Links student to a course
    public required int UserId { get; set; }  
    public User? User { get; set; }  
    public int CourseId { get; set; }  
    public Course? Course { get; set; }  

    // Tracks course progress
    public double Progress { get; set; } = 0.0;  
}

}