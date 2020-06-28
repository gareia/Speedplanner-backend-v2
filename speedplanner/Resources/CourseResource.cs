using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Resources
{
    public class CourseResource
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsOptional { get; set; }
        public bool IsVirtual { get; set; }
        public int Semester { get; set; }
        public int Credits { get; set; }
        public long TotalNumberOfStudents { get; set; } //to find later with sum
        public int? HigherCourseId { get; set; }
        public int EducationProviderId { get; set; }

    }
}
