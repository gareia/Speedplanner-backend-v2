using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SaveProfileResource
    {
        [Required]
        [MaxLength(30)]
        public string Names { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastNames { get; set; }
        [Required]
        public bool Gender { get; set; } //false man true woman
        public int? Semester { get; set; }
        [Required]
        public long IdNumber { get; set; } //dni


        [Required]
        public int UserId { get; set; }
        [Required]
        public int EducationProviderId { get; set; }
        [Required]
        public int LearningProgramId { get; set; }
    }
}
