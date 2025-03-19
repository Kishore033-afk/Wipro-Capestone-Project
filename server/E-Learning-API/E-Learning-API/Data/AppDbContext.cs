using Microsoft.EntityFrameworkCore;
using E_Learning_API.Models;
using System;

namespace ELearningAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuizAttempt> QuizAttempts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureRelationships(modelBuilder);
            SeedInitialData(modelBuilder);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            // User Relationships
            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedCourses)
                .WithOne(c => c.Instructor)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Course Relationships
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Lessons)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Quizzes)
                .WithOne(q => q.Course)
                .HasForeignKey(q => q.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Enrollment Relationships
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.User)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            // Quiz Relationships
            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            // QuizAttempt Relationships
            modelBuilder.Entity<QuizAttempt>()
                .HasOne(qa => qa.User)
                .WithMany(u => u.QuizAttempts)
                .HasForeignKey(qa => qa.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Decimal Precision
            modelBuilder.Entity<Course>()
                .Property(c => c.Price)
                .HasPrecision(18, 2);
        }

        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Admin User",
                    Email = "admin@elearning.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEHYHjVJ4TzH2w8vVhJTF3Cq1v6q7ZxWkSAMPLEHASHVALUE12345=",
                    Role = "Admin"
                },
                new User
                {
                    Id = 2,
                    FullName = "Instructor Jane",
                    Email = "jane@elearning.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEHYHjVJ4TzH2w8vVhJTF3Cq1v6q7ZxWkSAMPLEHASHVALUE12345=",
                    Role = "Instructor"
                },
                new User
                {
                    Id = 3,
                    FullName = "Student John",
                    Email = "john@student.com",
                    PasswordHash = "AQAAAAIAAYagAAAAEHYHjVJ4TzH2w8vVhJTF3Cq1v6q7ZxWkSAMPLEHASHVALUE12345=",
                    Role = "Student"
                }
            );

            // Courses
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    Title = "Intro to C#",
                    Description = "Learn fundamentals of C# programming",
                    InstructorId = 2,
                    Price = 49.99m,
                    Level = "Beginner",
                    Language = "English"
                },
                new Course
                {
                    Id = 2,
                    Title = "Web Development Basics",
                    Description = "HTML, CSS, and JavaScript fundamentals",
                    InstructorId = 2,
                    Price = 59.99m,
                    Level = "Intermediate",
                    Language = "English"
                }
            );

            // Lessons
            modelBuilder.Entity<Lesson>().HasData(
                new Lesson
                {
                    Id = 1,
                    Title = "C# Syntax Basics",
                    Content = "Introduction to C# syntax and structure",
                    VideoUrl = "https://example.com/videos/csharp-basics",
                    CourseId = 1
                },
                new Lesson
                {
                    Id = 2,
                    Title = "Object-Oriented Programming",
                    Content = "Classes, objects, and inheritance in C#",
                    VideoUrl = "https://example.com/videos/csharp-oop",
                    CourseId = 1
                }
            );

            // Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                {
                    Id = 1,
                    UserId = 3,
                    CourseId = 1,
                    Progress = 30.0
                }
            );

            // Quizzes
            modelBuilder.Entity<Quiz>().HasData(
                new Quiz
                {
                    Id = 1,
                    Title = "C# Fundamentals Quiz",
                    CourseId = 1
                }
            );

            // Questions
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    Text = "What is the entry point of a C# program?",
                    OptionA = "Main()",
                    OptionB = "Start()",
                    OptionC = "Initialize()",
                    OptionD = "Begin()",
                    CorrectAnswer = "A",
                    QuizId = 1
                }
            );

            // Quiz Attempts (with static date)
            modelBuilder.Entity<QuizAttempt>().HasData(
                new QuizAttempt
                {
                    Id = 1,
                    UserId = 3,
                    QuizId = 1,
                    Score = 80,
                    AttemptDate = new DateTime(2023, 1, 1) // Fixed date
                }
            );
        }
    }
}