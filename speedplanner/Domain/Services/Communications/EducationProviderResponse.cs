using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services.Communications
{
    public class EducationProviderResponse: BaseResponse<EducationProvider>
    {
        public EducationProviderResponse(string message) : base(message) { }

        public EducationProviderResponse(EducationProvider educationProvider) : base(educationProvider) { }
    }
}
