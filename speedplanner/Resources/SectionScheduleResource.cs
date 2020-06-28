using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SectionScheduleResource
    {
        public int Id { get; set; }
        public string StartTime { get; set; } //HHMM
        public string EndTime { get; set; }//HHMM
        public int NumberOfHours { get; set; }
        public string Day { get; set; } //Lunes Martes Mier..
        public int SectionId { get; set; }
        public string ClassroomName { get; set; }
    }
}
