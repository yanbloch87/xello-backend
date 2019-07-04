using GraduationTracker.Models;

namespace GraduationTracker.Tests.Unit
{
    public static class GraduationTrackerTestsMock
    {
        public static Student[] GetTestHasCreditsStudents()
        {
            return new[]
            {
               new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }
               },
               new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },
                new Student
                {
                    Id = 3,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=50 },
                        new Course{Id = 2, Name = "Science", Mark=50 },
                        new Course{Id = 3, Name = "Literature", Mark=50 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                    }
                },
                new Student
                {
                    Id = 4,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=40 },
                        new Course{Id = 2, Name = "Science", Mark=40 },
                        new Course{Id = 3, Name = "Literature", Mark=40 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                    }
                }
            };
        }
        public static Student GetTestHasRemedialStudent()
        {
            return new Student
            {
                Id = 1,
                Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=49 },
                        new Course{Id = 2, Name = "Science", Mark=49 },
                        new Course{Id = 3, Name = "Literature", Mark=49 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=49 }
                   }
            };
        }
        public static Student GetTestHasAverageStudent()
        {
            return new Student
            {
                Id = 1,
                Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=79 },
                        new Course{Id = 2, Name = "Science", Mark=79 },
                        new Course{Id = 3, Name = "Literature", Mark=79 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=79 }
                   }
            };
        }
        public static Student GetTestHasMagnaCumLaudeStudent()
        {
            return new Student
            {
                Id = 1,
                Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=94 },
                        new Course{Id = 2, Name = "Science", Mark=94 },
                        new Course{Id = 3, Name = "Literature", Mark=94 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=94 }
                   }
            };
        }
        public static Student GetTestHasSumaCumLaudeStudent()
        {
            return new Student
            {
                Id = 1,
                Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=100 },
                        new Course{Id = 2, Name = "Science", Mark=100 },
                        new Course{Id = 3, Name = "Literature", Mark=100 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=100 }
                   }
            };
        }
    }
}
