using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Models
{
    public class Constraint
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int NumberOfHours { get; set; }
        public string Days { get; set; }
        //public Professor Professor { get; set; }
        
    }
}
