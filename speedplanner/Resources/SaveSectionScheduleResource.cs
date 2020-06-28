using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SaveSectionScheduleResource
    {
        [Required]
        public string StartTime { get; set; } //HHMM
        [Required]
        public string EndTime { get; set; }//HHMM
        [Required]
        public int NumberOfHours { get; set; }
        [Required]
        public string Day { get; set; } //Lunes Martes Mier..
        [Required]
        public int SectionId { get; set; }
        [Required]
        public string ClassroomName { get; set; }
    }
}
