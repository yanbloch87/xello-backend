using System;
using GraduationTracker.Models;

namespace GraduationTracker.BL
{
    interface IGraduationTracker
    {
        Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student);
    }
}
