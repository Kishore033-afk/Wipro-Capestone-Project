namespace E_Learning_API.Models
{
public class Lesson
{
    public int Id { get; set; }  
    public string? Title { get; set; }  
    public string? Content { get; set; }  
    public string? VideoUrl { get; set; }  

    // Foreign key - Links lesson to a course
    public int CourseId { get; set; }  
    public Course? Course { get; set; }  
}

}