﻿// <auto-generated />
using System;
using ELearningAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Learning_API.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250318201137_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_Learning_API.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Learn fundamentals of C# programming",
                            InstructorId = 2,
                            Language = "English",
                            Level = "Beginner",
                            Price = 49.99m,
                            Title = "Intro to C#"
                        },
                        new
                        {
                            Id = 2,
                            Description = "HTML, CSS, and JavaScript fundamentals",
                            InstructorId = 2,
                            Language = "English",
                            Level = "Intermediate",
                            Price = 59.99m,
                            Title = "Web Development Basics"
                        });
                });

            modelBuilder.Entity("E_Learning_API.Models.Enrollment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<double>("Progress")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Progress = 30.0,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("E_Learning_API.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Introduction to C# syntax and structure",
                            CourseId = 1,
                            Title = "C# Syntax Basics",
                            VideoUrl = "https://example.com/videos/csharp-basics"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Classes, objects, and inheritance in C#",
                            CourseId = 1,
                            Title = "Object-Oriented Programming",
                            VideoUrl = "https://example.com/videos/csharp-oop"
                        });
                });

            modelBuilder.Entity("E_Learning_API.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CorrectAnswer = "A",
                            OptionA = "Main()",
                            OptionB = "Start()",
                            OptionC = "Initialize()",
                            OptionD = "Begin()",
                            QuizId = 1,
                            Text = "What is the entry point of a C# program?"
                        });
                });

            modelBuilder.Entity("E_Learning_API.Models.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Quizzes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Title = "C# Fundamentals Quiz"
                        });
                });

            modelBuilder.Entity("E_Learning_API.Models.QuizAttempt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AttemptDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.HasIndex("UserId");

                    b.ToTable("QuizAttempts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AttemptDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            QuizId = 1,
                            Score = 80,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("E_Learning_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@elearning.com",
                            FullName = "Admin User",
                            PasswordHash = "AQAAAAIAAYagAAAAEHYHjVJ4TzH2w8vVhJTF3Cq1v6q7ZxWkSAMPLEHASHVALUE12345=",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jane@elearning.com",
                            FullName = "Instructor Jane",
                            PasswordHash = "AQAAAAIAAYagAAAAEHYHjVJ4TzH2w8vVhJTF3Cq1v6q7ZxWkSAMPLEHASHVALUE12345=",
                            Role = "Instructor"
                        },
                        new
                        {
                            Id = 3,
                            Email = "john@student.com",
                            FullName = "Student John",
                            PasswordHash = "AQAAAAIAAYagAAAAEHYHjVJ4TzH2w8vVhJTF3Cq1v6q7ZxWkSAMPLEHASHVALUE12345=",
                            Role = "Student"
                        });
                });

            modelBuilder.Entity("E_Learning_API.Models.Course", b =>
                {
                    b.HasOne("E_Learning_API.Models.User", "Instructor")
                        .WithMany("CreatedCourses")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("E_Learning_API.Models.Enrollment", b =>
                {
                    b.HasOne("E_Learning_API.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("E_Learning_API.Models.User", "User")
                        .WithMany("Enrollments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("E_Learning_API.Models.Lesson", b =>
                {
                    b.HasOne("E_Learning_API.Models.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("E_Learning_API.Models.Question", b =>
                {
                    b.HasOne("E_Learning_API.Models.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("E_Learning_API.Models.Quiz", b =>
                {
                    b.HasOne("E_Learning_API.Models.Course", "Course")
                        .WithMany("Quizzes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("E_Learning_API.Models.QuizAttempt", b =>
                {
                    b.HasOne("E_Learning_API.Models.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Learning_API.Models.User", "User")
                        .WithMany("QuizAttempts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Quiz");

                    b.Navigation("User");
                });

            modelBuilder.Entity("E_Learning_API.Models.Course", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("Lessons");

                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("E_Learning_API.Models.Quiz", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("E_Learning_API.Models.User", b =>
                {
                    b.Navigation("CreatedCourses");

                    b.Navigation("Enrollments");

                    b.Navigation("QuizAttempts");
                });
#pragma warning restore 612, 618
        }
    }
}
