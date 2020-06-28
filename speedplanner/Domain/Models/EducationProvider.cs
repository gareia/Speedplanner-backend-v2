using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Models
{
    public class EducationProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfCareers { get; set; }
        public int CurrentPeriodId { get; set; }
        //public Period CurrentPeriod { get; set; } //maybe unnecessary

        public List<LearningProgram> Careers { get; set; }
        public List<Profile> Profiles { get; set; }
       // public List<Period> Periods { get; set; }
        
        public List<Course> Courses { get; set; }


        //public List<Classroom> Classrooms { get; set; }

        public Subscription Subscription { get; set; }


    }

}
