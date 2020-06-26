using speedplanner.Domain.Models;
using speedplanner.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Services
{
    public interface IEducationProviderService
    {
        
        Task<EducationProviderResponse> SaveAsync(EducationProvider educationProvider);
        Task<IEnumerable<EducationProvider>> ListAsync();
        
        Task<EducationProviderResponse> GetByIdAsync(int id);
        Task<EducationProviderResponse> UpdateAsync(int id, EducationProvider educationProvider);
        Task<EducationProviderResponse> DeleteAsync(int id);

    }
}
