using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public string StartDate { get; set; } //DDMMAAAA
        public string EndDate { get; set; }//DDMMAAAA

        public int EducationProviderId { get; set; }
        public EducationProvider EducationProvider { get; set; }
    }
}
