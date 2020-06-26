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
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        public CourseRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(int inscriptionProcessId, Course course)
        {
            course.InscriptionProcessId = inscriptionProcessId;
            await _context.Courses.AddAsync(course);
        }

        public async Task<Course> FindByIdAsync(int courseId)
        {
            return await _context.Courses.FindAsync(courseId);
        }

        public async Task<IEnumerable<Course>> ListByInscriptionProcessIdAsync(int inscriptionProcessId)
        {
            return await _context.Courses
                .Where(c => c.InscriptionProcessId == inscriptionProcessId)
                .Include(c => c.InscriptionProcess)
                .ToListAsync();
        }

        public void Remove(Course course)
        {
            _context.Courses.Remove(course);
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
        }
    }
}
