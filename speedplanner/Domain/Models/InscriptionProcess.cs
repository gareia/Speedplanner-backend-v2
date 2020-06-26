using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Models
{
    public class InscriptionProcess
    {
        public int Id { get; set; }
        public List<Course> Courses { get; set; }

        //public List<PossibleSchedule> PossibleSchedules { get; set; } descomentar

        //public List<Constraint> Constraints { get; set; } descomentar

        //public List<SectionRequest> SectionRequests { get; set; } descomentar

        //por la relacion con user descomentar
        public User User { get; set; }
        public int UserId { get; set; }

        //por relacion con inscription process descomentar
        //public Period Period { get; set; }
        //public int PeriodId { get; set; }
    }
    
}
