
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Models
{
    public class LearningProgram
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public long NumberOfCourses { get; set; }
        //Por la relacion con EducationProvider---
        public int EducationProviderId { get; set; }
        public EducationProvider EducationProvider { get; set; }
        public List<LearningProgramCourse> LearningProgramCourses { get; set; }


        //public List<Period> Periods { get; set; }

       
        //Relacion con Profile
        //public Profile Profile { get; set; }
        //public int ProfileId { get; set; }
        //Relacion con Statistic
        //public Statistic Statistic { get; set; }
        //public int StatisticId { get; set; }
    }
    
}
