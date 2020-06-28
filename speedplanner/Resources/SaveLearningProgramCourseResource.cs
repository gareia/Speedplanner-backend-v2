using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SaveLearningProgramCourseResource
    {
        public int LProgramId { get; set; }
        public int CourseId { get; set; }
    }

}