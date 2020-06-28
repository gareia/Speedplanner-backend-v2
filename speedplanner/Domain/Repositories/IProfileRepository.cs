using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Repositories
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> ListAsync();

        Task AddAsync(int userId, Profile profile);

        Task<Profile> FindById(int id);

        Task<IEnumerable<Profile>> ListByUserIdAsync(int userId);

        Task<IEnumerable<Profile>> ListByLearningProgramIdAsync(int learningProgramId);

        Task<IEnumerable<Profile>> ListByEducationProviderIdAsync(int educationProviderId);

        void Remove(Profile profile);

        void Update(Profile profile);
    }
}
