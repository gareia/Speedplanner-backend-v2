using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Models
{
    public class SectionSchedule
    {
        public int Id { get; set; }
        public string StartTime { get; set; } //HHMM
        public string EndTime { get; set; }//HHMM
        public int NumberOfHours { get; set; }
        public string Day { get; set; } //Lunes Martes Mier..

        public string ClassroomName { get; set; }

        //public List<ClassroomSectionSchedule> ClassroomSectionSchedules { get; set; }

        //por la relacion con Section
        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}
