using speedplanner.Domain.Models;
using speedplanner.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services
{
    public interface ISectionService
    {
        Task<SectionResponse> GetByIdAndCourseIdAsync(int courseId, int id);
        Task<SectionResponse> SaveAsync(int courseId, Section section);
        Task<IEnumerable<Section>> ListByCourseIdAsync(int courseId);
        //Task<SectionResponse> UpdateAsync(int courseId, int id, Section section);
        //Task<SectionResponse> DeleteAsync(int courseId, int id);
        
    }
}
