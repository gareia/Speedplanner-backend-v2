using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services.Communications
{
    public class SectionResponse : BaseResponse<Section>
    {
        public SectionResponse(Section resource) : base(resource) { }

        public SectionResponse(string message) : base(message) { }
    }
}
