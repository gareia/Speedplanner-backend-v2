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
    /*
    public class LearningProgramCourseRepository: BaseRepository, ILearningProgramCourseRepository
    {
        public LearningProgramCourseRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<LearningProgramCourse>> ListAsync()
        {
            return await _context.LearningProgramCourses
                .Include(lpc => lpc.LearningProgram)
                .Include(lpc => lpc.Course)
                .ToListAsync();
        }

        public async Task<IEnumerable<LearningProgramCourse>> ListByCourseIdAsync(int courseId)
        {
            return await _context.LearningProgramCourses
                 .Where(lpc => lpc.CourseId == courseId)
                 .Include(lpc => lpc.LearningProgram)
                 .Include(lpc => lpc.Course)
                 .ToListAsync();
        }

        public async Task<IEnumerable<LearningProgramCourse>> ListByLearningProgramIdAsync(int learningProgramId)
        {
            return await _context.LearningProgramCourses
                 .Where(lpc => lpc.LearningProgramId == learningProgramId)
                 .Include(lpc => lpc.LearningProgram)
                 .Include(lpc => lpc.Course)
                 .ToListAsync();
        }

        public async Task<LearningProgramCourse> AssignLearningProgramCourse(int learningProgramId, int courseId)
        {
            LearningProgramCourse learningProgramCourse = await FindByLearningProgramIdAndCourseId(learningProgramId, courseId);
            if (learningProgramCourse == null)
            {
                learningProgramCourse = new LearningProgramCourse { LearningProgramId = learningProgramId, CourseId =courseId};
                await AddAsync(learningProgramCourse);
            }
            return learningProgramCourse;
        }

        public async Task<LearningProgramCourse> UnassignLearningProgramCourse(int learningProgramId, int courseId)
        {
            LearningProgramCourse learningProgramCourse = await FindByLearningProgramIdAndCourseId(learningProgramId, courseId);
            if (learningProgramCourse != null)
            {
                Remove(learningProgramCourse);
            }
            return learningProgramCourse;
        }



        public async Task<LearningProgramCourse> FindByLearningProgramIdAndCourseId(int learningProgramId, int courseId)
        {
            return await _context.LearningProgramCourses.FindAsync(learningProgramId, courseId);
        }
        public async Task AddAsync(LearningProgramCourse learningProgramCourse)
        {
            await _context.LearningProgramCourses.AddAsync(learningProgramCourse);
        }
        public void Remove(LearningProgramCourse learningProgramCourse)
        {
            _context.LearningProgramCourses.Remove(learningProgramCourse);
        }

       
    }
    */
}
