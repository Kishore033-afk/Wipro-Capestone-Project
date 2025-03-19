-- Clear existing data
DELETE FROM QuizAttempts;
DELETE FROM Questions;
DELETE FROM Quizzes;
DELETE FROM Lessons;
DELETE FROM Enrollments;
DELETE FROM Courses;
DELETE FROM Users;

-- Reset identity counters
DBCC CHECKIDENT ('Users', RESEED, 0);
DBCC CHECKIDENT ('Courses', RESEED, 0);
DBCC CHECKIDENT ('Lessons', RESEED, 0);
DBCC CHECKIDENT ('Enrollments', RESEED, 0);
DBCC CHECKIDENT ('Quizzes', RESEED, 0);
DBCC CHECKIDENT ('Questions', RESEED, 0);
DBCC CHECKIDENT ('QuizAttempts', RESEED, 0);

-- Users
INSERT INTO Users (FullName, Email, PasswordHash, Role) VALUES
('Admin User', 'admin@elearning.com', 'admin', 'Admin'),
('Instructor Jane', 'jane@elearning.com', 'instructor', 'Instructor'),
('Student John', 'john@student.com', 'student', 'Student');

-- Courses (6 total)
INSERT INTO Courses (Title, Description, Price, Level, Language, InstructorId) VALUES
('Intro to C#', 'Learn fundamentals of C# programming', 49.99, 'Beginner', 'English', 2),
('Web Development Basics', 'HTML, CSS, and JavaScript fundamentals', 59.99, 'Intermediate', 'English', 2),
('Python for Data Science', 'Python programming and data analysis', 79.99, 'Advanced', 'English', 2),
('JavaScript Fundamentals', 'Modern JavaScript programming', 54.99, 'Intermediate', 'English', 2),
('React Masterclass', 'Build modern web apps with React', 64.99, 'Advanced', 'English', 2),
('Node.js Backend Development', 'Server-side JavaScript development', 69.99, 'Advanced', 'English', 2);

-- Lessons (3 per course)
INSERT INTO Lessons (Title, Content, VideoUrl, CourseId) VALUES
-- Course 1: C#
('C# Basics', 'Introduction to C# syntax', 'https://www.youtube.com/embed/gfkTfcpWqAY', 1),
('OOP in C#', 'Classes and inheritance', 'https://www.youtube.com/embed/4vqALX4Avnc', 1),
('C# Advanced Features', 'LINQ and async programming', 'https://www.youtube.com/embed/7GJuww6i3Tk', 1),

-- Course 2: Web Dev
('HTML Essentials', 'Core HTML elements', 'https://www.youtube.com/embed/qz0aGYrrlhU', 2),
('CSS Fundamentals', 'Styling web pages', 'https://www.youtube.com/embed/1PnVor36_40', 2),
('JavaScript Basics', 'Client-side scripting', 'https://www.youtube.com/embed/W6NZfCO5SIk', 2),

-- Course 3: Python
('Python Setup', 'Installation and tools', 'https://www.youtube.com/embed/YYXdXT2l-Gg', 3),
('Data Analysis', 'Pandas and NumPy basics', 'https://www.youtube.com/embed/zZDu8xcRl5w', 3),
('Data Visualization', 'Matplotlib and Seaborn', 'https://www.youtube.com/embed/DAQNHzOcO5A', 3),

-- Course 4: JavaScript
('Modern JS Syntax', 'ES6+ features', 'https://www.youtube.com/embed/NCwa_xi0Uuc', 4),
('DOM Manipulation', 'Working with web pages', 'https://www.youtube.com/embed/0ik6X4DJKCc', 4),
('Async Programming', 'Promises and async/await', 'https://www.youtube.com/embed/DHvZLI7Db8E', 4),

-- Course 5: React
('React Components', 'Building UI components', 'https://www.youtube.com/embed/w7ejDZ8SWv8', 5),
('State Management', 'Using React hooks', 'https://www.youtube.com/embed/O6P86uwfdR0', 5),
('React Router', 'Navigation in React apps', 'https://www.youtube.com/embed/Law7wfdg_ls', 5),

-- Course 6: Node.js
('Node Setup', 'NPM and package.json', 'https://www.youtube.com/embed/JINE4D0Syqw', 6),
('Express Framework', 'Building REST APIs', 'https://www.youtube.com/embed/L72fhGm1tfE', 6),
('Database Integration', 'MongoDB with Mongoose', 'https://www.youtube.com/embed/fbYExfeFsI0', 6);

-- Quizzes (1 per course)
INSERT INTO Quizzes (Title, CourseId) VALUES
('C# Fundamentals', 1),
('Web Basics Quiz', 2),
('Python Data Quiz', 3),
('JavaScript Quiz', 4),
('React Quiz', 5),
('Node.js Quiz', 6);

-- Questions (3 per quiz)
INSERT INTO Questions (Text, OptionA, OptionB, OptionC, OptionD, CorrectAnswer, QuizId) VALUES
-- Quiz 1: C#
('What is the entry point of a C# program?', 'Main()', 'Start()', 'Initialize()', 'Begin()', 'A', 1),
('Which keyword is used for inheritance?', 'extends', 'inherits', 'colon', 'derives', 'C', 1),
('What is LINQ used for?', 'Database access', 'Data querying', 'Networking', 'Graphics', 'B', 1),

-- Quiz 2: Web
('HTML stands for?', 'Hyper Trainer', 'Hyper Text', 'Hyperlinks', 'Home Tool', 'B', 2),
('CSS property for text color?', 'font-color', 'text-color', 'color', 'font-style', 'C', 2),
('JavaScript is a ___ language?', 'compiled', 'interpreted', 'assembly', 'binary', 'B', 2),

-- Quiz 3: Python
('Popular Python data library?', 'Pandas', 'Requests', 'React', 'jQuery', 'A', 3),
('Used for visualization?', 'NumPy', 'Matplotlib', 'Express', 'Mongoose', 'B', 3),
('Python package manager?', 'npm', 'pip', 'yarn', 'composer', 'B', 3),

-- Quiz 4: JavaScript
('ES6 introduced?', 'classes', 'var', 'alert', 'XML', 'A', 4),
('Document Object Model?', 'DOM', 'Window', 'Console', 'HTML', 'A', 4),
('Promises handle?', 'synchronous', 'asynchronous', 'variables', 'loops', 'B', 4),

-- Quiz 5: React
('React is maintained by?', 'Google', 'Facebook', 'Amazon', 'Microsoft', 'B', 5),
('Hook for state?', 'useEffect', 'useState', 'useContext', 'useRef', 'B', 5),
('React Router component?', '<Link>', '<Div>', '<Img>', '<Meta>', 'A', 5),

-- Quiz 6: Node.js
('Node.js runtime uses?', 'Java', 'JavaScript', 'Python', 'C#', 'B', 6),
('Popular Node framework?', 'Django', 'Laravel', 'Express', 'Spring', 'C', 6),
('Mongoose works with?', 'MySQL', 'MongoDB', 'Postgres', 'SQLite', 'B', 6);

-- Enrollments (Student John in all courses)
INSERT INTO Enrollments (UserId, CourseId, Progress) VALUES
(3, 1, 30.0),
(3, 2, 15.5),
(3, 3, 0.0),
(3, 4, 0.0),
(3, 5, 0.0),
(3, 6, 0.0);

-- QuizAttempts (Example attempts)
INSERT INTO QuizAttempts (UserId, QuizId, Score, AttemptDate) VALUES
(3, 1, 80, '2023-01-01'),
(3, 2, 90, '2023-02-15'),
(3, 4, 85, '2023-03-01');