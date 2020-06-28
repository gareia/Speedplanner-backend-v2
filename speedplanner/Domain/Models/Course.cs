using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Models
{
    public class Course
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
        public Course HigherCourse { get; set; }
        public EducationProvider EducationProvider { get; set; }
        public int EducationProviderId { get; set; }
        public List<Course> Requisites { get; set; }
        public List<LearningProgramCourse> LearningProgramCourses { get; set; }
        //public List<InscriptionProcessCourse> InscriptionProcessCourses { get; set; }

        public List<Section> Sections {get; set;}



        //PROBABLY NOT HERE
        //public int EducationProviderId { get; set; }
        //public EducationProvider EducationProvider { get; set; }




        //public List<CoursePossibleSchedule> CoursePossibleSchedules { get; set; }

    }
}
