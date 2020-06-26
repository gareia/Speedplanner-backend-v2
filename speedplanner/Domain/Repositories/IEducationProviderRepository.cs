using speedplanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace speedplanner.Domain.Repositories
{
    public interface IEducationProviderRepository
    {
        Task AddAsync(EducationProvider educationProvider);
        Task<IEnumerable<EducationProvider>> ListAsync();
        
        Task<EducationProvider> FindById(int id);
        void Update(EducationProvider educationProvider);
        void Remove(EducationProvider educationProvider);
        
    }
}
