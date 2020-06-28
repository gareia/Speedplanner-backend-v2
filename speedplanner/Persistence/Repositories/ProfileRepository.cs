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
    public class ProfileRepository: BaseRepository, IProfileRepository
    {
        public ProfileRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(int userId, Profile profile)
        {
            profile.UserId = userId;
            await _context.Profiles.AddAsync(profile);
        }

        public async Task<Profile> FindById(int id)
        {
            return await _context.Profiles.FindAsync(id);
        }

        public async Task<IEnumerable<Profile>> ListAsync()
        {
            return await _context.Profiles.ToListAsync();
        }


        public async Task<IEnumerable<Profile>> ListByEducationProviderIdAsync(int educationProviderId) =>
            await _context.Profiles
            .Where(p => p.EducationProvider.Id == educationProviderId)
            .Include(p => p.EducationProvider)
            .ToListAsync();

        public async Task<IEnumerable<Profile>> ListByLearningProgramIdAsync(int learningProgramId) =>
            await _context.Profiles
            .Where(p => p.LearningProgram.Id == learningProgramId)
            .Include(p => p.LearningProgram)
            .ToListAsync();

        public async Task<IEnumerable<Profile>> ListByUserIdAsync(int userId) =>
            await _context.Profiles
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();

        public void Remove(Profile profile)
        {
            _context.Profiles.Remove(profile);
        }

        public void Update(Profile profile)
        {
            _context.Profiles.Update(profile);
        }
    }
}
