using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SectionResource
    {
        public int Id { get; set; }

        public string SectionName { get; set; }

        public string Venue { get; set; }

        public int Vacancy { get; set; }

        public int RegisteredStudents { get; set; }

        public int NumberOfHours { get; set; }

        public int CourseId { get; set; }
        public int ProfessorId { get; set; }

        public string ProfessorName { get; set; }
    }
}
