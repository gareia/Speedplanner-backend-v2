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
		
        //public Period AcademicPeriod { get; set; }
		
        public int NumberOfCareers { get; set; }

        public List<LearningProgram> Careers { get; set; }

        //public List<Classroom> Classrooms { get; set; }

		//public Subscription Subscription { get; set; }
        //Relacion con Profile
        //public Profile Profile { get; set; }
        //public int ProfileId { get; set; }

    }
  
}
