using System;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {   
        public Tuple<bool, STANDING>  HasGraduated(Diploma diploma, Student student)
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

            var average = sum / student.Courses.Length;
            var hasEnoughCreadits = credits >= diploma.Credits;

            if (average < 50)
                return new Tuple<bool, STANDING>(hasEnoughCreadits, STANDING.Remedial);
            else if (average < 80)
                return new Tuple<bool, STANDING>(hasEnoughCreadits, STANDING.Average);
            else if (average < 95)
                return new Tuple<bool, STANDING>(hasEnoughCreadits, STANDING.MagnaCumLaude);
            else
                return new Tuple<bool, STANDING>(hasEnoughCreadits, STANDING.SumaCumLaude);
        }
    }
}
