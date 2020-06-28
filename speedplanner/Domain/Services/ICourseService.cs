using speedplanner.Domain.Models;
using speedplanner.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services
{
    public interface ICourseService
    {
        //Task<IEnumerable<Course>> ListByInscriptionProcessIdAsync(int inscriptionProcessId);

        Task<IEnumerable<Course>> ListByProfileIdAsync(int learningProgramId);

        Task<CourseResponse> SaveAsync(int educationProviderId, Course course);
        Task<IEnumerable<Course>> ListByEducationProviderIdAsync(int educationProviderId);
        Task<CourseResponse> GetByIdAndEducationProviderIdAsync(int educationProviderId, int courseId);
        Task<CourseResponse> UpdateAsync(int educationProviderId, int courseId, Course course);
        Task<CourseResponse> DeleteAsync(int educationProviderId, int courseId);
        
    }
}
