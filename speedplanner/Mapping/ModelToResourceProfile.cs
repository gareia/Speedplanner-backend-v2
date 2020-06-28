using speedplanner.Domain.Models;
using speedplanner.Resources; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace speedplanner.Mapping
{
    public class ModelToResourceProfile: AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<EducationProvider, EducationProviderResource>();
            CreateMap<LearningProgram, LearningProgramResource>();
            //CreateMap<InscriptionProcess, InscriptionProcessResource>();
            CreateMap<Course, CourseResource>();
            CreateMap<LearningProgramCourse, LearningProgramCourseResource>();
            
            CreateMap<User, UserResource>();
            CreateMap<speedplanner.Domain.Models.Profile, ProfileResource>();
            CreateMap<Role, RoleResource>();
            //CreateMap<Period, PeriodResource>();
             CreateMap<Section, SectionResource>();
            CreateMap<SectionSchedule, SectionScheduleResource>();
            CreateMap<Subscription, SubscriptionResource>();


            /*
            
            CreateMap<Classroom, ClassroomResource>();
            CreateMap<ClassroomSectionSchedule, ClassroomSectionScheduleResource>();
           
            CreateMap<Professor, ProfessorResource>();

            CreateMap<Constraint, ConstraintResource>();
            CreateMap<CoursePossibleSchedule, CoursePossibleScheduleResource>();
            CreateMap<PossibleSchedule, PossibleScheduleResource>();
            CreateMap<SectionRequest, SectionRequestResource>();
            CreateMap<Statistic, StatisticResource>();

            CreateMap<ProfessorConstraint, ProfessorConstraintResource>();
            CreateMap<DayConstraint, DayConstraintResource>();
            CreateMap<HourRangeConstraint, HourRangeConstraintResource>();
            
            
            //*/
        }
    }
}
