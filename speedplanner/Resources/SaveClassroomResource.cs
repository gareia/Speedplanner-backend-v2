using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class SaveClassroomResource
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public string ClassroomName { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int EducationProviderId { get; set; }
    }
}
