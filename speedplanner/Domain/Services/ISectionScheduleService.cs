using speedplanner.Domain.Models;
using speedplanner.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services
{
    public interface ISectionScheduleService
    {
        Task<IEnumerable<SectionSchedule>> ListBySectionIdAsync(int sectionId);
        Task<SectionScheduleResponse> SaveAsync(int sectionId, SectionSchedule sectionSchedule);
        Task<SectionScheduleResponse> GetByIdAndSectionIdAsync(int sectionId, int id);
        /*
        Task<SectionScheduleResponse> UpdateAsync(int id, SectionSchedule sectionSchedule, int SectionId);
        Task<SectionScheduleResponse> DeleteAsync(int id, int sectionid);*/
    }
}
