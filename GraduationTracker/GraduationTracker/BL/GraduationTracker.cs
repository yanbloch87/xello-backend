using System;
using System.Linq;
using GraduationTracker.DAL;
using GraduationTracker.Models;

namespace GraduationTracker.BL
{
    public class GraduationTracker : IGraduationTracker
    {
        private readonly IRepository _repository;

        public GraduationTracker(IRepository _repository)
        {
            this._repository = _repository;
        }

        public Tuple<bool, STANDING>  HasGraduated(Diploma diploma, Student student)
        {
            if (diploma == null)
            {
                throw new ArgumentNullException("missing argument diploma");
            }
            if (student == null)
            {
                throw new ArgumentNullException("missing argument student");
            }
            var requirements = diploma.Requirements.Select(_repository.GetRequirement).ToArray();
            var creditsAndSum = GetCreditsAndSum(requirements, student);
            var credits = creditsAndSum.Item1;
            var sum = creditsAndSum.Item2;
            var average = sum / student.Courses.Length;
            var hasEnoughCreadits = credits >= diploma.Credits;
            var standing = GetStanding(average);
            var hasGraduated = hasEnoughCreadits && standing != STANDING.Remedial;
            return new Tuple<bool, STANDING>(hasGraduated, standing);
        }

        private static Tuple<int, int> GetCreditsAndSum(Requirement[] requirements, Student student)
        {
            var credits = 0;
            var sum = 0;

            foreach(var requirement in requirements)
            {
                foreach (var courseId in requirement.Courses) {
                    var course = student.Courses.First(c => c.Id == courseId);
                    sum += course.Mark;
                    if (course.Mark > requirement.MinimumMark)
                    {
                        credits += requirement.Credits;
                    }
                }
            }

            return new Tuple<int, int>(credits, sum);
        }

        private static STANDING GetStanding(int average)
        {
            if (average < 50)
            {
                return STANDING.Remedial;
            }
            if (average < 80)
            {
                return STANDING.Average;
            }
            if (average < 95)
            {
                return STANDING.MagnaCumLaude;
            }

            return STANDING.SumaCumLaude;
        }
    }
}
