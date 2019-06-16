namespace GraduationTracker.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class GraduationTrackerTests
    {
        private readonly GraduationTracker tracker = new GraduationTracker();
        private readonly Diploma diploma = new Diploma()
        {
            Id = 1,
            Credits = 4,
            Requirements = new int[] { 100, 102, 103, 104 }
        };

        [TestMethod]
        public void TestHasCredits()
        {

            var students = new[]
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

            var graduated = new List<Tuple<bool, STANDING>>();

            foreach (var student in students)
            {
                var hasRemedial = tracker.HasGraduated(diploma, student);
                if (hasRemedial.Item1 == true)
                {
                    graduated.Add(hasRemedial);
                }
            }

            Assert.IsFalse(graduated.Count == students.Length);
        }

        [TestMethod]
        public void TestHasRemedial()
        {
            var student = new Student
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

            var hasRemedial = tracker.HasGraduated(diploma, student);

            Assert.IsTrue(hasRemedial.Item1 == false && hasRemedial.Item2 == STANDING.Remedial);
        }

        [TestMethod]
        public void TestHasAverage()
        {
            var student = new Student
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

            var hasRemedial = tracker.HasGraduated(diploma, student);

            Assert.IsTrue(hasRemedial.Item1 == true && hasRemedial.Item2 == STANDING.Average);
        }

        [TestMethod]
        public void TestHasMagnaCumLaude()
        {
            var student = new Student
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

            var hasRemedial = tracker.HasGraduated(diploma, student);

            Assert.IsTrue(hasRemedial.Item1 == true && hasRemedial.Item2 == STANDING.MagnaCumLaude);
        }

        [TestMethod]
        public void TestHasSumaCumLaude()
        {
            var student = new Student
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

            var hasRemedial = tracker.HasGraduated(diploma, student);

            Assert.IsTrue(hasRemedial.Item1 == true && hasRemedial.Item2 == STANDING.SumaCumLaude);
        }

        [TestMethod]
        public void TestHasStudent()
        {
            try
            {
                tracker.HasGraduated(diploma, null);
            }
            catch (NullReferenceException e)
            {
                Assert.IsTrue(e != null);
            }
        }

        [TestMethod]
        public void TestHasDiploma()
        {
            var student = new Student
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
            try
            {
                tracker.HasGraduated(null, student);
            }
            catch (NullReferenceException e)
            {
                Assert.IsTrue(e != null);
            }
        }
    }
}
