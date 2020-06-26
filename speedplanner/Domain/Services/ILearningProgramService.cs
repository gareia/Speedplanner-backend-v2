using speedplanner.Domain.Models;
using speedplanner.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services
{
    public interface ILearningProgramService
    {
        Task<IEnumerable<LearningProgram>> ListByEducationProviderIdAsync(int educationProviderId);
        Task<LearningProgramResponse> SaveAsync(int educationProviderId, LearningProgram learningProgram);
        Task<LearningProgramResponse> GetByIdAndEducationProviderIdAsync(int educationProviderId, int learningProgramId);
        Task<LearningProgramResponse> UpdateAsync(int educationProviderId, int learningProgramId, LearningProgram learningProgram);
        Task<LearningProgramResponse> DeleteAsync(int educationProviderId, int learningProgramId);
       
    } 
}
