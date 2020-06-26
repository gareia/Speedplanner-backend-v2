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
    public class LearningProgramRepository : BaseRepository, ILearningProgramRepository
    {
        public LearningProgramRepository(AppDbContext context) : base(context) { }
        public async Task AddAsync(int educationProviderId, LearningProgram learningProgram)
        {
            learningProgram.EducationProviderId = educationProviderId;
            await _context.LearningPrograms.AddAsync(learningProgram);
        }

        public async Task<LearningProgram> FindByIdAsync(int learningProgramId)
        {
            return await _context.LearningPrograms.FindAsync(learningProgramId);
        }

        public async Task<IEnumerable<LearningProgram>> ListByEducationProviderIdAsync(int educationProviderId)
        {
            return await _context.LearningPrograms
                .Where(lp => lp.EducationProviderId == educationProviderId)
                .Include(lp => lp.EducationProvider)
                .ToListAsync();
        }

        public void Remove(LearningProgram learningProgram)
        {
              _context.LearningPrograms.Remove(learningProgram);
        }

        public void Update(LearningProgram learningProgram)
        {
             _context.LearningPrograms.Update(learningProgram);
        }
    }
}
