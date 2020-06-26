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
            CreateMap<InscriptionProcess, InscriptionProcessResource>();
            CreateMap<LearningProgramCourse, LearningProgramCourseResource>();
            CreateMap<Course, CourseResource>();
            CreateMap<User, UserResource>();

            /*
            CreateMap<Classroom, ClassroomResource>();
            CreateMap<ClassroomCourse, ClassroomCourseResource>();
            CreateMap<Constraint, ConstraintResource>();
            
            CreateMap<CoursePossibleSchedule, CoursePossibleScheduleResource>();
            CreateMap<DayConstraint, DayConstraintResource>();
            CreateMap<HourRangeConstraint, HourRangeConstraintResource>();
            CreateMap<Period, PeriodResource>();
            CreateMap<PossibleSchedule, PossibleScheduleResource>();
            CreateMap<Professor, ProfessorResource>();
            CreateMap<ProfessorConstraint, ProfessorConstraintResource>();
            CreateMap<Speedplanner.Domain.Models.Profile, ProfileResource>();
            CreateMap<Role, RoleResource>();
            CreateMap<Section, SectionResource>();
            CreateMap<SectionRequest, SectionRequestResource>();
            CreateMap<SectionSchedule, SectionScheduleResource>();
            CreateMap<Statistic, StatisticResource>();
            CreateMap<Subscription, SubscriptionResource>();
            
            //*/
        }
    }
}
