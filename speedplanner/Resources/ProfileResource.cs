using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class ProfileResource
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public bool Gender { get; set; } //false man true woman
        public int? Semester { get; set; }
        public long IdNumber { get; set; } //dni
        public int UserId { get; set; }
        public int EducationProviderId { get; set; }
        public int LearningProgramId { get; set; }
    }
}
