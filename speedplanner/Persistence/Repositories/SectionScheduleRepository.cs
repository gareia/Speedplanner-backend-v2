using Microsoft.EntityFrameworkCore;
using speedplanner.Domain.Models;
using speedplanner.Domain.Persistence.Contexts;
using speedplanner.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Persistence.Repositories
{
    public class SectionScheduleRepository : BaseRepository, ISectionScheduleRepository
    {
        public SectionScheduleRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(int sectionId, SectionSchedule sectionSchedule)
        {
            sectionSchedule.SectionId = sectionId;
            await _context.SectionSchedules.AddAsync(sectionSchedule);
        }

        public async Task<SectionSchedule> FindById(int sectionScheduleId)
        {
            return await _context.SectionSchedules.FindAsync(sectionScheduleId);
        }

        public async Task<IEnumerable<SectionSchedule>> ListBySectionIdAsync(int sectionId) =>
            await _context.SectionSchedules
            .Where(p => p.SectionId == sectionId)
            .Include(p => p.Section)
            .ToListAsync();
    

        public void Remove(SectionSchedule sectionSchedule)
        {
            _context.SectionSchedules.Remove(sectionSchedule);
        }

        public void Update(SectionSchedule sectionSchedule)
        {
            _context.SectionSchedules.Update(sectionSchedule);
        }

    }
}
