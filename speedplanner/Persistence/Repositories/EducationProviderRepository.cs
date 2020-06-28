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
    public class EducationProviderRepository : BaseRepository, IEducationProviderRepository
    {
        public EducationProviderRepository(AppDbContext context) : base(context){}
        
        
        public async Task AddAsync(EducationProvider educationProvider)
        {
            await _context.EducationProviders.AddAsync(educationProvider);

        }
        public async Task<EducationProvider> FindById(int id)
        {
            return await _context.EducationProviders.FindAsync(id);
        }
        
        public async Task<IEnumerable<EducationProvider>> ListAsync()
        {
            return await _context.EducationProviders.ToListAsync();
        }
        
        public void Remove(EducationProvider educationProvider)
        {
            _context.EducationProviders.Remove(educationProvider);
        }

        public void Update(EducationProvider educationProvider)
        {
            _context.EducationProviders.Update(educationProvider);
        }
        
    }
}
