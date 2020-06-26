using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Repositories
{
    public interface ILearningProgramRepository
    {
        
        Task AddAsync(int educationProviderId, LearningProgram learningProgram);
        Task<IEnumerable<LearningProgram>> ListByEducationProviderIdAsync(int educationProviderId);
        Task<LearningProgram> FindByIdAsync(int learningProgramId);
        void Update(LearningProgram learningProgram);
        void Remove(LearningProgram learningProgram);
        
    }
}
