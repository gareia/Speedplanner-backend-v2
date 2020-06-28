using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class PeriodResource
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int EducationProviderId { get; set; }
    }
}
