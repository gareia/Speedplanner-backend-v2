using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SaveSubscriptionResource
    {
        public double Cost { get; set; }
        public string StartDate { get; set; } //DDMMAAAA
        public string EndDate { get; set; }//DDMMAAAA

        public int EducationProviderId { get; set; }
    }
}
