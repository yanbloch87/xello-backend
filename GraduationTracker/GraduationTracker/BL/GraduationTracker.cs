using System;
using GraduationTracker.DAL;
using GraduationTracker.Models;

namespace GraduationTracker.BL
{
    public class GraduationTracker
    {   
        public Tuple<bool, STANDING>  HasGraduated(Diploma diploma, Student student)
        {
            if (diploma == null)
            {
                throw new Exception("missing diploma");
            }
            if (student == null)
            {
                throw new Exception("missing student");
            }
            var creadisAndSum = GetCreditsAndSum(diploma, student);
            var credits = creadisAndSum.Item1;
            var sum = creadisAndSum.Item2;
            var average = sum / student.Courses.Length;
            var hasEnoughCreadits = credits >= diploma.Credits;
            var standing = GetStanding(average);
            var hasGraduated = hasEnoughCreadits && standing != STANDING.Remedial;
            return new Tuple<bool, STANDING>(hasGraduated, standing);
        }

        private static Tuple<int, int> GetCreditsAndSum(Diploma diploma, Student student)
        {
            var credits = 0;
            var sum = 0;

            Array.ForEach(diploma.Requirements, requirementId => {
                var requirement = Repository.GetRequirement(requirementId);

                Array.ForEach(requirement.Courses, courseId => {
                    var course = Array.Find(student.Courses, c => c.Id == courseId);
                    sum += course.Mark;
                    if (course.Mark > requirement.MinimumMark)
                    {
                        credits += requirement.Credits;
                    }
                });
            });

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
