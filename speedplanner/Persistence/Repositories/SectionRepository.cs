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
    public class SectionRepository : BaseRepository, ISectionRepository
    {
        public SectionRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(int courseId, Section section)
        {
            section.CourseId = courseId;
            await _context.Sections.AddAsync(section);
        }

        public async Task<Section> FindById(int id)
        {

            return await _context.Sections.FindAsync(id);
        }

        public async Task<IEnumerable<Section>> ListByCourseAsync(int courseId)
        {

            return await _context.Sections.
                Where(s => s.CourseId == courseId)
                .Include(s => s.Course)
                .ToListAsync();
        }

        /*
        public async Task<IEnumerable<Section>> ListByProfessorIdAsync(int professorId) =>
            await _context.Sections
            .Where(p => p.ProfessorId == professorId)
            .Include(p => p.Professor)
            .ToListAsync();*/

        public void Remove(Section section)
        {
            _context.Sections.Remove(section);
        }

        public void Update(Section section)
        {
            _context.Sections.Remove(section);
        }
    }
}
