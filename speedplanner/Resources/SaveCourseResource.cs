using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SaveCourseResource
    {
        [Required]
        [MaxLength(10)]
        [Key]
        public string Code { get; set; }
        [Required]
        [MaxLength(30)]
        [Key]
        public string Name { get; set; }
        [Required]
        public bool IsOptional { get; set; }
        [Required]
        public bool IsVirtual { get; set; }
        [Required]
        public int Semester { get; set; }
        [Required]
        public int Credits { get; set; }
        public int? HigherCourseId { get; set; }
        [Required]
        public int EducationProviderId { get; set; }

    }
}
