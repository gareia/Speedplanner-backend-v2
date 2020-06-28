using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services.Communications
{
    public class SectionScheduleResponse : BaseResponse<SectionSchedule>
    {
        public SectionScheduleResponse(SectionSchedule resource) : base(resource) { }

        public SectionScheduleResponse(string message) : base(message) { }
    }
}
