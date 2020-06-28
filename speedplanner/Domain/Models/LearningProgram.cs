
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Models
{
    public class LearningProgram
    {
        public int Id { get; set; }
        public string Type { get; set; } //career
        public string Name { get; set; }
        public long NumberOfCourses { get; set; }
        

        public EducationProvider EducationProvider { get; set; }
        public int EducationProviderId { get; set; }
        public List<LearningProgramCourse> LearningProgramCourses { get; set; }
        public List<Profile> Profiles { get; set; }

        //Relacion con Statistic
        //public Statistic Statistic { get; set; }
        //public int StatisticId { get; set; }
    }
    
}
