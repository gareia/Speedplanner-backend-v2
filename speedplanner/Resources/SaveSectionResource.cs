using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SaveSectionResource
    {
        [Required]
        public string SectionName { get; set; }
        [Required]
        public string Venue { get; set; }
        [Required]
        public int Vacancy { get; set; }
        [Required]
        public int RegisteredStudents { get; set; }
        [Required]
        public int NumberOfHours { get; set; }
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int ProfessorId { get; set; }
        [Required]
        public string ProfessorName { get; set; }
    }

}
