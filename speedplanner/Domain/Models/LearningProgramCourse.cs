using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Models
{
    public class LearningProgramCourse
    {
        public int LProgramId { get; set; }
        public LearningProgram LProgram { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
        
    }
    
}
