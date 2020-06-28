using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public bool Gender { get; set; } //false man true woman
        public int? Semester { get; set; }
        public long IdNumber { get; set; } //dni


        public User User { get; set; }
        public int UserId { get; set; }
        public EducationProvider EducationProvider { get; set; }
        public int EducationProviderId { get; set; }
        public LearningProgram LearningProgram { get; set; }
        public int LearningProgramId { get; set; }
    }
}
