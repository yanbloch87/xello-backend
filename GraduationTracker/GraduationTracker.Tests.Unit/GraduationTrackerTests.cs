namespace GraduationTracker.Tests.Unit
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using GraduationTracker.BL;
    using GraduationTracker.DAL;
    using GraduationTracker.Models;

    [TestClass]
    public class GraduationTrackerTests
    {
        private readonly GraduationTracker tracker = new GraduationTracker(new Repository());
        private readonly Diploma diploma = new Diploma()
        {
            Id = 1,
            Credits = 4,
            Requirements = new int[] { 100, 102, 103, 104 }
        };

        [TestMethod]
        public void TestHasCredits()
        {

            var students = GraduationTrackerTestsMock.GetTestHasCreditsStudents();
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
            var student = GraduationTrackerTestsMock.GetTestHasRemedialStudent();
            var hasRemedial = tracker.HasGraduated(diploma, student);

            Assert.IsTrue(hasRemedial.Item1 == false && hasRemedial.Item2 == STANDING.Remedial);
        }

        [TestMethod]
        public void TestHasAverage()
        {
            var student = GraduationTrackerTestsMock.GetTestHasAverageStudent();
            var hasRemedial = tracker.HasGraduated(diploma, student);

            Assert.IsTrue(hasRemedial.Item1 == true && hasRemedial.Item2 == STANDING.Average);
        }

        [TestMethod]
        public void TestHasMagnaCumLaude()
        {
            var student = GraduationTrackerTestsMock.GetTestHasMagnaCumLaudeStudent();
            var hasRemedial = tracker.HasGraduated(diploma, student);

            Assert.IsTrue(hasRemedial.Item1 == true && hasRemedial.Item2 == STANDING.MagnaCumLaude);
        }

        [TestMethod]
        public void TestHasSumaCumLaude()
        {
            var student = GraduationTrackerTestsMock.GetTestHasSumaCumLaudeStudent();
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
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(e != null);
                Assert.IsTrue(e.ParamName == "missing student");
            }
        }

        [TestMethod]
        public void TestHasDiploma()
        {
            var student = GraduationTrackerTestsMock.GetTestHasSumaCumLaudeStudent();
            try
            {
                tracker.HasGraduated(null, student);
            }
            catch (ArgumentNullException e)
            {
                Assert.IsTrue(e != null);
                Assert.IsTrue(e.ParamName == "missing diploma");
            }
        }
    }
}
