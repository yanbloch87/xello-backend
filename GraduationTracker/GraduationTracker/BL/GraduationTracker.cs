using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {   
        public Tuple<bool, STANDING>  HasGraduated(Diploma diploma, Student student)
        {
            var credits = 0;
            var sum = 0;
        
            for(int i = 0; i < diploma.Requirements.Length; i++)
            {
                var requirement = Repository.GetRequirement(diploma.Requirements[i]);
                for (int j = 0; j < student.Courses.Length; j++)
                {
                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k] == student.Courses[j].Id)
                        {
                            sum += student.Courses[j].Mark;
                            if (student.Courses[j].Mark > requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                        }
                    }
                }
            }

            var average = sum / student.Courses.Length;
            var hasEnoughCreadits = credits == diploma.Credits;

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
