using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Repositories
{
    public interface ISectionScheduleRepository
    {
        Task AddAsync(int sectionId, SectionSchedule sectionSchedule);
        Task<IEnumerable<SectionSchedule>> ListBySectionIdAsync(int sectionId);
        Task<SectionSchedule> FindById(int sectionScheduleId);
        void Update(SectionSchedule sectionSchedule);
        void Remove(SectionSchedule sectionSchedule);
    }
}
