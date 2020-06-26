using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services.Communications
{
    public class CourseResponse: BaseResponse<Course>
    {
        public CourseResponse(Course resource) : base(resource) { }

        public CourseResponse(string message) : base(message) { }
    }
}
