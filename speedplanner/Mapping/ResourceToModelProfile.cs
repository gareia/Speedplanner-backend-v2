using speedplanner.Domain.Models;
using speedplanner.Resources; //
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Mapping
{
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveEducationProviderResource, EducationProvider>();
            CreateMap<SaveLearningProgramResource, LearningProgram>();
            CreateMap<SaveInscriptionProcessResource, InscriptionProcess>();
            CreateMap<SaveLearningProgramCourseResource, LearningProgramCourse>();
            CreateMap<SaveCourseResource, Course>();
            CreateMap<SaveUserResource, User>();
            

            /*
            CreateMap<SaveClassroomResource, Classroom>();
            CreateMap<SaveClassroomCourseResource, ClassroomCourse>();
            CreateMap<SaveConstraintResource, Constraint>();
            
            CreateMap<SaveCoursePossibleScheduleResource, CoursePossibleSchedule>();
            CreateMap<SaveDayConstraintResource, DayConstraint>();
            CreateMap<SaveHourRangeConstraintResource, HourRangeConstraint>();
            CreateMap<SavePeriodResource, Period>();
            CreateMap<SavePossibleScheduleResource, PossibleSchedule>();
            CreateMap<SaveProfessorResource, Professor>();
            CreateMap<SaveProfessorConstraintResource, ProfessorConstraint>();
            CreateMap<SaveProfileResource, Speedplanner.Domain.Models.Profile>();
            CreateMap<SaveRoleResource, Role>();
            CreateMap<SaveSectionResource, Section>();
            CreateMap<SaveSectionRequestResource, SectionRequest>();
            CreateMap<SaveSectionScheduleResource, SectionSchedule>();
            CreateMap<SaveStatisticResource, Statistic>();
            CreateMap<SaveSubscriptionResource, Subscription>();
            
            */
        }
    }
}
