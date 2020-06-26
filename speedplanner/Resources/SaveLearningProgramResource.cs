using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SaveLearningProgramResource
    {
        [Required]
        public string Type { get; set; }
        [Required]
        [Key]
        public string Name { get; set; }
        [Required]
        public long NumberOfCourses { get; set; }
       
    }
}
