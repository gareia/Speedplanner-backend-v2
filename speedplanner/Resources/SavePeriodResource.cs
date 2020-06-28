using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SavePeriodResource
    {
        [Required]
        [MaxLength(10)]
        public string Code { get; set; }
        [Required]
        [MaxLength(8)]
        public string StartDate { get; set; }//DDMMAAAA
        [Required]
        [MaxLength(8)]
        public string EndDate { get; set; }//DDMMAAAA
        [Required]
        public int EducationProviderId { get; set; }
    }
}
