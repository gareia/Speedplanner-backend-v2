using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services.Communications
{
    public class LearningProgramCourseResponse : BaseResponse<LearningProgramCourse>
    {
        public LearningProgramCourseResponse(LearningProgramCourse resource) : base(resource) { }

        public LearningProgramCourseResponse(string message) : base(message) { }
    
    }
}
