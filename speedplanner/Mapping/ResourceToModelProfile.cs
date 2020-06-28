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
            //CreateMap<SaveInscriptionProcessResource, InscriptionProcess>();
            CreateMap<SaveCourseResource, Course>();
            CreateMap<SaveLearningProgramCourseResource, LearningProgramCourse>();
            
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveProfileResource, speedplanner.Domain.Models.Profile>();
            CreateMap<SaveRoleResource, Role>();
            //CreateMap<SavePeriodResource, Period>();
            CreateMap<SaveSectionResource, Section>();
            CreateMap<SaveSectionScheduleResource, SectionSchedule>();
            CreateMap<SaveSubscriptionResource, Subscription>();

            /*
             * CreateMap<SaveProfessorResource, Professor>();
             *  CreateMap<SaveClassroomResource, Classroom>();
            CreateMap<SaveSectionScheduleResource, ClassroomSectionSchedule>();
           
             * 
            CreateMap<SaveConstraintResource, Constraint>();
            CreateMap<SaveCoursePossibleScheduleResource, CoursePossibleSchedule>();
            CreateMap<SavePossibleScheduleResource, PossibleSchedule>();
            CreateMap<SaveSectionRequestResource, SectionRequest>();
            CreateMap<SaveStatisticResource, Statistic>();

             CreateMap<SaveDayConstraintResource, DayConstraint>();
            CreateMap<SaveHourRangeConstraintResource, HourRangeConstraint>();
            CreateMap<SaveProfessorConstraintResource, ProfessorConstraint>();
            
            
            */
        }
    }
}
