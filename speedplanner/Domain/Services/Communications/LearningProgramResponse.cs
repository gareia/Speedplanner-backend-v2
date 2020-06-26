using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services.Communications
{
    public class LearningProgramResponse: BaseResponse<LearningProgram>
    {
        public LearningProgramResponse(LearningProgram resource) : base(resource) { }

        public LearningProgramResponse(string message) : base(message) { }
    
    }
}
