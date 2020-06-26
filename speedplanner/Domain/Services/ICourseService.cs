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
        Task<IEnumerable<Course>> ListByInscriptionProcessIdAsync(int inscriptionProcessId);
        Task<CourseResponse> SaveAsync(int inscriptionProcessId, Course course);
        Task<CourseResponse> GetByIdAndInscriptionProcessIdAsync(int inscriptionProcessId, int courseId);
        Task<CourseResponse> UpdateAsync(int inscriptionProcessId, int courseId, Course course);
        Task<CourseResponse> DeleteAsync(int inscriptionProcessId, int courseId);
    }
}
