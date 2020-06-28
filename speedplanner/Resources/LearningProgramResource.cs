using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class LearningProgramResource
    {
        public int Id { get; set; }
        public string Type { get; set; } //career
        public string Name { get; set; }
        public long NumberOfCourses { get; set; }
        public int EducationProviderId { get; set; }
    }
}
