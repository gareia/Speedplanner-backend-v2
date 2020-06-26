using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Models
{
    public class LearningProgramCourse
    {
        public int LearningProgId { get; set; }
        public LearningProgram LearningProgram { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
    
}
