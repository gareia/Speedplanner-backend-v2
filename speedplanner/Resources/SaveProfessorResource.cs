using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SaveProfessorResource
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public long IdNumber { get; set; }
        [Required]
        public string Names { get; set; }
        [Required]
        public string LastNames { get; set; }
    }
}
