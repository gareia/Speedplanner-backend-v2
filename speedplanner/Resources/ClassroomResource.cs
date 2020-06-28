using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class ClassroomResource
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string ClassroomName { get; set; }
        public int Capacity { get; set; }
        public int EducationProviderId { get; set; }
    }
}
